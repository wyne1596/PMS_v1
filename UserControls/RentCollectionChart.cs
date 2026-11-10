using System.Drawing.Drawing2D;
using System.ComponentModel;

namespace PMS_v1.UserControls
{
    public sealed class RentCollectionChart : Control
    {
        private static readonly string[] MonthNames =
        {
            "Jan", "Feb", "Mar", "Apr", "May", "Jun",
            "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
        };

        private static readonly decimal[] EmptyValues =
        {
            0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0
        };

        private IReadOnlyList<decimal>? monthlyValues;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IReadOnlyList<decimal>? MonthlyValues
        {
            get => monthlyValues;
            set
            {
                monthlyValues = value;
                Invalidate();
            }
        }

        public RentCollectionChart()
        {
            SetStyle(ControlStyles.UserPaint |
                     ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw, true);
            BackColor = Color.White;
            ForeColor = Color.FromArgb(95, 101, 107);
            MinimumSize = new Size(280, 150);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics graphics = e.Graphics;
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(BackColor);

            Rectangle plot = new(58, 12, Math.Max(1, Width - 78), Math.Max(1, Height - 43));
            IReadOnlyList<decimal> values = monthlyValues ?? EmptyValues;
            int count = Math.Min(12, values.Count);
            decimal maxValue = 150m;

            using var axisFont = new Font("Segoe UI", 7.5F);
            using var gridPen = new Pen(Color.FromArgb(232, 235, 238));
            using var barBrush = new SolidBrush(Color.FromArgb(202, 225, 148));

            for (int tick = 0; tick <= 3; tick++)
            {
                int y = plot.Bottom - (int)(plot.Height * tick / 3F);
                graphics.DrawLine(gridPen, plot.Left, y, plot.Right, y);
                string label = $"₱{tick * 50}k";
                TextRenderer.DrawText(graphics, label, axisFont,
                    new Rectangle(0, y - 8, plot.Left - 8, 16), ForeColor,
                    TextFormatFlags.Right | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            }

            if (count == 0)
            {
                TextRenderer.DrawText(graphics, "No collection values", Font, plot, ForeColor,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                return;
            }

            float slotWidth = (float)plot.Width / count;
            int barWidth = Math.Max(8, (int)(slotWidth * 0.48F));
            for (int i = 0; i < count; i++)
            {
                decimal amount = Math.Max(0, values[i]);
                float heightRatio = Math.Min(1F, (float)(amount / maxValue));
                int barHeight = (int)(plot.Height * heightRatio);
                int x = plot.Left + (int)(i * slotWidth + (slotWidth - barWidth) / 2F);
                int y = plot.Bottom - barHeight;

                using var barPath = CreateRoundedBar(new Rectangle(x, y, barWidth, barHeight), 4);
                graphics.FillPath(barBrush, barPath);

                if (count <= 12)
                {
                    TextRenderer.DrawText(graphics, MonthNames[i], axisFont,
                        new Rectangle(plot.Left + (int)(i * slotWidth), plot.Bottom + 5,
                            (int)slotWidth, 16), ForeColor,
                        TextFormatFlags.HorizontalCenter | TextFormatFlags.NoPadding);
                }
            }

        }

        private static GraphicsPath CreateRoundedBar(Rectangle bounds, int radius)
        {
            var path = new GraphicsPath();
            if (bounds.Height <= 0)
                return path;

            int diameter = Math.Min(radius * 2, Math.Min(bounds.Width, bounds.Height));
            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            path.AddArc(bounds.Right - diameter, bounds.Top, diameter, diameter, 270, 90);
            path.AddLine(bounds.Right, bounds.Top + diameter / 2, bounds.Right, bounds.Bottom);
            path.AddLine(bounds.Right, bounds.Bottom, bounds.Left, bounds.Bottom);
            path.AddLine(bounds.Left, bounds.Bottom, bounds.Left, bounds.Top + diameter / 2);
            path.CloseFigure();
            return path;
        }
    }
}
