using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;


namespace PMS_v1
{
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

        // ---------- Shape ----------

        [Category("Appearance")]
        [DefaultValue(20)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderRadius
        {
            get { return borderRadius; }
            set { borderRadius = Math.Max(0, value); Invalidate(); }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color BorderColor
        {
            get { return borderColor; }
            set { borderColor = value; Invalidate(); }
        }

        [Category("Appearance")]
        [DefaultValue(0)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int BorderThickness
        {
            get { return borderThickness; }
            set { borderThickness = Math.Max(0, value); Invalidate(); }
        }

        // ---------- Shadow ----------

        [Category("Appearance")]
        [DefaultValue(6)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ShadowSize
        {
            get { return shadowSize; }
            set { shadowSize = Math.Max(0, value); PerformLayout(); Invalidate(); }
        }

        [Category("Appearance")]
        [DefaultValue(0)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ShadowOffsetX
        {
            get { return shadowOffsetX; }
            set { shadowOffsetX = value; PerformLayout(); Invalidate(); }
        }

        [Category("Appearance")]
        [DefaultValue(2)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ShadowOffsetY
        {
            get { return shadowOffsetY; }
            set { shadowOffsetY = value; PerformLayout(); Invalidate(); }
        }

        [Category("Appearance")]
        [DefaultValue(60)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int ShadowOpacity
        {
            get { return shadowOpacity; }
            set { shadowOpacity = Math.Max(0, Math.Min(255, value)); Invalidate(); }
        }

        [Category("Appearance")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ShadowColor
        {
            get { return shadowColor; }
            set { shadowColor = value; Invalidate(); }
        }

        public RoundedPanel()
        {
            BackColor = Color.White;
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
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
            InvokePaint(Parent, pe);
            e.Graphics.Restore(state);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            var g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

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

        protected override void OnParentBackColorChanged(EventArgs e)
        {
            base.OnParentBackColorChanged(e);
            Invalidate();
        }
    }

}