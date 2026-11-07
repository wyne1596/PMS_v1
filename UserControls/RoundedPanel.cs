using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;


namespace PMS_v1
{
    /// <summary>
    /// A panel with rounded corners and a soft drop shadow.
    /// The shadow + body are rendered once into a cached bitmap and re-used on
    /// every paint. The cache is rebuilt lazily only when the size or a visual
    /// property changes, so ordinary repaints (page switches, hover, scrolling)
    /// cost a single bitmap blit instead of several anti-aliased path fills.
    /// </summary>
    public class RoundedPanel : Panel
    {
        private int borderRadius = 20;
        private Color borderColor = Color.Transparent;
        private int borderThickness = 0;

        private int shadowSize = 6;
        private int shadowOffsetX = 0;
        private int shadowOffsetY = 2;
        private int shadowOpacity = 60;          // 0-255
        private Color shadowColor = Color.Black;

        private bool paintParentContent = false;

        // Cached render of shadow + body (transparent outside the shape)
        private Bitmap? cache;
        private bool cacheDirty = true;

        // ---------- Shape ----------

        [Category("Appearance")]
        [DefaultValue(20)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = Math.Max(0, value); InvalidateCache(); }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; InvalidateCache(); }
        }

        [Category("Appearance")]
        [DefaultValue(0)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderThickness
        {
            get { return borderThickness; }
            set { borderThickness = Math.Max(0, value); InvalidateCache(); }
        }

        // ---------- Shadow ----------

        [Category("Appearance")]
        [DefaultValue(6)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ShadowSize
        {
            get { return shadowSize; }
            set { shadowSize = Math.Max(0, value); PerformLayout(); InvalidateCache(); }
        }

        [Category("Appearance")]
        [DefaultValue(0)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ShadowOffsetX
        {
            get { return shadowOffsetX; }
            set { shadowOffsetX = value; PerformLayout(); InvalidateCache(); }
        }

        [Category("Appearance")]
        [DefaultValue(2)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ShadowOffsetY
        {
            get { return shadowOffsetY; }
            set { shadowOffsetY = value; PerformLayout(); InvalidateCache(); }
        }

        [Category("Appearance")]
        [DefaultValue(60)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ShadowOpacity
        {
            get { return shadowOpacity; }
            set { shadowOpacity = Math.Max(0, Math.Min(255, value)); InvalidateCache(); }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ShadowColor
        {
            get { return shadowColor; }
            set { shadowColor = value; InvalidateCache(); }
        }

        /// <summary>
        /// When true, the parent's Paint handlers also run behind this panel
        /// (the old behaviour). Leave false unless the parent draws custom
        /// graphics in its Paint event that must show through the corners and
        /// shadow - it is much more expensive.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(false)]
        public bool PaintParentContent
        {
            get { return paintParentContent; }
            set { paintParentContent = value; Invalidate(); }
        }

        public RoundedPanel()
        {
            BackColor = Color.White;
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
        }

        // Margin reserved around the panel for the shadow
        private int PadX
        {
            get { return ShadowSize > 0 ? ShadowSize + Math.Abs(ShadowOffsetX) : 0; }
        }

        private int PadY
        {
            get { return ShadowSize > 0 ? ShadowSize + Math.Abs(ShadowOffsetY) : 0; }
        }

        // Keeps docked/filled child controls inside the visible panel, not on the shadow
        public override Rectangle DisplayRectangle
        {
            get
            {
                Rectangle r = base.DisplayRectangle;
                int w = Math.Max(0, r.Width - PadX * 2);
                int h = Math.Max(0, r.Height - PadY * 2);
                return new Rectangle(r.X + PadX, r.Y + PadY, w, h);
            }
        }

        // ---------- Cache ----------

        private void InvalidateCache()
        {
            cacheDirty = true;
            Invalidate();
        }

        private void EnsureCache()
        {
            if (cache != null && !cacheDirty &&
                cache.Width == Width && cache.Height == Height)
                return;

            cache?.Dispose();
            cache = null;

            if (Width <= 0 || Height <= 0)
            {
                cacheDirty = false;
                return;
            }

            // Premultiplied ARGB is the fastest format to blit with GDI+
            cache = new Bitmap(Width, Height, PixelFormat.Format32bppPArgb);
            using (var g = Graphics.FromImage(cache))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                RenderShape(g);
            }
            cacheDirty = false;
        }

        private GraphicsPath GetPath(RectangleF rect, float radius)
        {
            float maxRadius = Math.Min(rect.Width, rect.Height) / 2f;
            radius = Math.Min(radius, maxRadius);

            var path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(rect);
                return path;
            }

            float d = radius * 2;
            path.AddArc(rect.X, rect.Y, d, d, 180, 90);
            path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
            path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
            path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        // The expensive part: runs only when the cache is rebuilt
        private void RenderShape(Graphics g)
        {
            float inset = BorderThickness / 2f;
            var rect = new RectangleF(
                PadX + inset,
                PadY + inset,
                Width - 1 - PadX * 2 - BorderThickness,
                Height - 1 - PadY * 2 - BorderThickness);
            if (rect.Width <= 0 || rect.Height <= 0) return;

            // Shadow: stacked, translucent, growing rounded shapes
            if (ShadowSize > 0 && ShadowOpacity > 0)
            {
                int alpha = Math.Max(1, ShadowOpacity / ShadowSize);
                for (int i = ShadowSize; i >= 1; i--)
                {
                    var r = new RectangleF(
                        rect.X + ShadowOffsetX - i,
                        rect.Y + ShadowOffsetY - i,
                        rect.Width + i * 2,
                        rect.Height + i * 2);

                    using (var p = GetPath(r, BorderRadius + i))
                    using (var b = new SolidBrush(Color.FromArgb(alpha, ShadowColor)))
                        g.FillPath(b, p);
                }
            }

            // Panel body
            using (var path = GetPath(rect, BorderRadius))
            using (var brush = new SolidBrush(BackColor))
            {
                g.FillPath(brush, path);

                if (BorderThickness > 0)
                {
                    using (var pen = new Pen(BorderColor, BorderThickness))
                        g.DrawPath(pen, path);
                }
            }
        }

        // ---------- Painting ----------

        // Paint the parent's background so corners and shadow blend in
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (Parent == null)
            {
                base.OnPaintBackground(e);
                return;
            }

            var state = e.Graphics.Save();
            e.Graphics.TranslateTransform(-Left, -Top);
            var pe = new PaintEventArgs(e.Graphics, new Rectangle(Location, Size));
            InvokePaintBackground(Parent, pe);
            if (PaintParentContent)
                InvokePaint(Parent, pe);
            e.Graphics.Restore(state);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            EnsureCache();

            if (cache != null)
            {
                // Explicit destination size avoids DPI-based scaling of the bitmap
                e.Graphics.DrawImage(cache, 0, 0, cache.Width, cache.Height);
            }

            base.OnPaint(e);   // keep the Paint event working for subscribers
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            base.OnBackColorChanged(e);
            InvalidateCache();
        }

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
            Invalidate();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                cache?.Dispose();
                cache = null;
            }
            base.Dispose(disposing);
        }
    }

}