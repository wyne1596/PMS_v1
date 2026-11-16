using System.Drawing.Drawing2D;

namespace PMS_v1.UserControls
{
    /// <summary>Small line icons for the search / filter / action row, drawn in code so no image files are needed.</summary>
    internal static class ActionIcons
    {
        public static Bitmap Search(Color color, int size) => Draw(color, size, 0.1f, (g, p, s) =>
        {
            g.DrawEllipse(p, s * 0.12f, s * 0.12f, s * 0.54f, s * 0.54f);
            g.DrawLine(p, s * 0.60f, s * 0.60f, s * 0.88f, s * 0.88f);
        });

        public static Bitmap Plus(Color color, int size) => Draw(color, size, 0.12f, (g, p, s) =>
        {
            g.DrawLine(p, s * 0.2f, s * 0.5f, s * 0.8f, s * 0.5f);
            g.DrawLine(p, s * 0.5f, s * 0.2f, s * 0.5f, s * 0.8f);
        });

        public static Bitmap Chevron(Color color, int size) => Draw(color, size, 0.1f, (g, p, s) =>
        {
            g.DrawLines(p, new[]
            {
                new PointF(s * 0.2f, s * 0.36f),
                new PointF(s * 0.5f, s * 0.64f),
                new PointF(s * 0.8f, s * 0.36f)
            });
        });

        public static Bitmap Filter(Color color, int size) => Draw(color, size, 0.09f, (g, p, s) =>
        {
            g.DrawLine(p, s * 0.12f, s * 0.28f, s * 0.88f, s * 0.28f);
            g.DrawLine(p, s * 0.28f, s * 0.50f, s * 0.72f, s * 0.50f);
            g.DrawLine(p, s * 0.42f, s * 0.72f, s * 0.58f, s * 0.72f);
        });

        private static Bitmap Draw(Color color, int size, float penFactor, Action<Graphics, Pen, float> paint)
        {
            size = Math.Max(8, size);
            var bmp = new Bitmap(size, size);
            using (var g = Graphics.FromImage(bmp))
            using (var pen = new Pen(color, Math.Max(1.2f, size * penFactor)))
            {
                g.SmoothingMode = SmoothingMode.AntiAlias;
                pen.StartCap = LineCap.Round;
                pen.EndCap = LineCap.Round;
                pen.LineJoin = LineJoin.Round;
                paint(g, pen, size);
            }
            return bmp;
        }
    }
}
