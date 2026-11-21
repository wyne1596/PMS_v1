using System;
using System.Drawing;
using System.Windows.Forms;

namespace PMS_v1.UserControls
{
    /// <summary>
    /// Action-row layout shared by the module pages.
    /// The filter and buttons are packed against the right edge and the search box
    /// takes whatever width is left, so adding another button never needs manual resizing.
    ///
    /// Usage (list the buttons left to right):
    ///   ActionRowLayout.PackRight(pnlActions, txtSearch, cmbFilter, btnEdit, btnDelete, btnNew);
    /// </summary>
    public static class ActionRowLayout
    {
        private const int Gap = 12;
        private const int MinSearchWidth = 180;

        public static void PackRight(Control panel, Control search, Control? filter, params Control[] buttons)
        {
            if (panel.ClientSize.Width <= 0) return;   // not laid out yet

            int right = panel.ClientSize.Width;
            int centerY = panel.ClientSize.Height / 2;

            void PlaceRight(Control c)
            {
                if (c == null || !c.Visible) return;
                right -= c.Width;
                c.Location = new Point(right, centerY - c.Height / 2);
                right -= Gap;
            }

            for (int i = buttons.Length - 1; i >= 0; i--)
                PlaceRight(buttons[i]);
            if (filter != null)
                PlaceRight(filter);

            search.Width = Math.Max(MinSearchWidth, right);
            search.Location = new Point(0, centerY - search.Height / 2);
        }
    }
}
