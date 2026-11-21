using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PMS_v1.UserControls
{
    /// <summary>
    /// Paints a status cell as a colored badge. One palette for every page, so a status
    /// looks the same everywhere (Paid and Completed are green, Overdue and Failed are red, and so on).
    ///
    /// Usage, either:
    ///   StatusBadge.Attach(dgv, "Status");                       // wires the grid's CellPainting for you
    ///   StatusBadge.Paint(dgv, e, "Status");                     // from your own CellPainting handler
    /// </summary>
    public static class StatusBadge
    {
        private static readonly (Color Back, Color Fore) Green  = (Color.FromArgb(222, 241, 214), Color.FromArgb(52, 105, 30));
        private static readonly (Color Back, Color Fore) Blue   = (Color.FromArgb(218, 237, 248), Color.FromArgb(45, 93, 120));
        private static readonly (Color Back, Color Fore) Amber  = (Color.FromArgb(255, 243, 205), Color.FromArgb(133, 100, 4));
        private static readonly (Color Back, Color Fore) Orange = (Color.FromArgb(255, 226, 204), Color.FromArgb(153, 76, 0));
        private static readonly (Color Back, Color Fore) Red    = (Color.FromArgb(248, 215, 218), Color.FromArgb(132, 32, 41));
        private static readonly (Color Back, Color Fore) Gray   = (Color.FromArgb(233, 236, 239), Color.FromArgb(95, 102, 108));
        private static readonly (Color Back, Color Fore) Purple = (Color.FromArgb(232, 222, 248), Color.FromArgb(76, 43, 128));

        private static readonly Dictionary<string, (Color Back, Color Fore)> Palette =
            new Dictionary<string, (Color, Color)>(StringComparer.OrdinalIgnoreCase)
        {
            // good / done
            ["Paid"] = Green, ["Completed"] = Green, ["Active"] = Green, ["Resolved"] = Green, ["Vacant"] = Green,
            // in progress
            ["Partially Paid"] = Blue, ["In Progress"] = Blue, ["Occupied"] = Blue,
            // waiting
            ["Pending"] = Amber, ["Scheduled"] = Amber, ["Open"] = Amber,
            // needs attention
            ["Unpaid"] = Orange, ["Expired"] = Orange, ["Under Maintenance"] = Orange,
            // bad
            ["Overdue"] = Red, ["Failed"] = Red, ["Terminated"] = Red,
            // inactive
            ["Canceled"] = Gray, ["Cancelled"] = Gray, ["Closed"] = Gray, ["None"] = Gray, ["No lease"] = Gray,
            // money going back
            ["Refunded"] = Purple
        };

        public static (Color Back, Color Fore) ColorsFor(string status) =>
            Palette.TryGetValue((status ?? string.Empty).Trim(), out var c) ? c : Blue;

        public static void Attach(DataGridView grid, string columnName, Func<string, string>? displayText = null)
        {
            grid.CellPainting += (_, e) => Paint(grid, e, columnName, displayText);
        }

        /// <param name="displayText">Optional: show different text than the cell value (for example "None" as "No lease").</param>
        public static void Paint(DataGridView grid, DataGridViewCellPaintingEventArgs e, string columnName,
            Func<string, string>? displayText = null)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0 || grid.Columns[e.ColumnIndex].Name != columnName)
                return;

            string status = Convert.ToString(e.FormattedValue) ?? string.Empty;
            if (status.Length == 0)
                return;   // nothing to badge: normal painting

            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            var (back, fore) = ColorsFor(status);
            string text = displayText != null ? displayText(status) : status;

            Font font = e.CellStyle.Font ?? grid.Font;
            Size textSize = TextRenderer.MeasureText(text, font);
            int w = Math.Min(e.CellBounds.Width - 8, textSize.Width + 14);
            int h = Math.Min(24, e.CellBounds.Height - 8);
            var bounds = new Rectangle(
                e.CellBounds.Left + (e.CellBounds.Width - w) / 2,
                e.CellBounds.Top + (e.CellBounds.Height - h) / 2, w, h);

            using (var brush = new SolidBrush(back))
                e.Graphics.FillRectangle(brush, bounds);

            TextRenderer.DrawText(e.Graphics, text, font, bounds, fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
            e.Handled = true;
        }
    }
}
