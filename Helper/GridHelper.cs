using System;
using System.Drawing;
using System.Windows.Forms;

namespace PMS_v1.UserControls
{
    /// <summary>Small grid fixes shared by the module pages.</summary>
    public static class GridHelper
    {
        private static readonly Color SelectionBack = Color.FromArgb(232, 243, 250);

        /// <summary>
        /// The pages paint selected rows white, so the chosen row is invisible.
        /// Call this after the grid's styles are set to give it a light-blue highlight.
        /// </summary>
        public static void ShowSelection(DataGridView grid)
        {
            grid.DefaultCellStyle.SelectionBackColor = SelectionBack;
            grid.AlternatingRowsDefaultCellStyle.SelectionBackColor = SelectionBack;
        }

        /// <summary>
        /// Shows only the rows that pass <paramref name="keep"/>.
        /// A grid throws if you hide the row that holds the current cell, so the current cell is cleared first.
        /// </summary>
        public static void Filter(DataGridView grid, Func<DataGridViewRow, bool> keep)
        {
            grid.CurrentCell = null;
            foreach (DataGridViewRow row in grid.Rows)
                row.Visible = keep(row);
        }

        /// <summary>True when the cell's text contains <paramref name="text"/> (case-insensitive).</summary>
        public static bool Has(DataGridViewRow row, string column, string text) =>
            row.Cells[column].Value?.ToString()?.Contains(text, StringComparison.OrdinalIgnoreCase) == true;
    }
}
