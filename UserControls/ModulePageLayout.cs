namespace PMS_v1.UserControls
{
    internal static class ModulePageLayout
    {
        private const int ActionGap = 14;
        private const int MinimumSearchWidth = 120;
        private const int MinimumFilterWidth = 96;
        private const int MaximumFilterWidth = 150;
        private const int MinimumActionWidth = 110;
        private const int MaximumActionWidth = 172;
        private const int ActionHeight = 40;
        private const int SearchAndFilterHeight = 34;

        internal static void ApplyStandardLayout(
            TableLayoutPanel pageLayout,
            Control header,
            TableLayoutPanel metrics,
            Control actions,
            Control content)
        {
            pageLayout.SuspendLayout();
            metrics.SuspendLayout();

            pageLayout.Dock = DockStyle.Fill;
            pageLayout.Padding = Padding.Empty;
            pageLayout.Margin = new Padding(3, 2, 3, 2);
            pageLayout.ColumnCount = 1;
            pageLayout.RowCount = 4;
            pageLayout.ColumnStyles.Clear();
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.RowStyles.Clear();
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 18.5542164F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 13.6144581F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 67.83132F));

            header.Dock = DockStyle.Fill;
            header.Margin = new Padding(3, 2, 3, 2);
            metrics.Dock = DockStyle.Fill;
            metrics.Margin = new Padding(3, 2, 3, 2);
            metrics.ColumnCount = metrics.Controls.Count;
            metrics.ColumnStyles.Clear();

            if (metrics.ColumnCount > 0)
            {
                float columnWidth = 100F / metrics.ColumnCount;
                for (int i = 0; i < metrics.ColumnCount; i++)
                    metrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, columnWidth));
            }

            int cardCount = metrics.Controls.Count;
            for (int i = 0; i < cardCount; i++)
            {
                Control card = metrics.GetControlFromPosition(i, 0) ?? metrics.Controls[i];
                card.Dock = DockStyle.Fill;
                card.Margin = new Padding(i == 0 ? 13 : 6, 0, i == cardCount - 1 ? 13 : 6, 0);
            }

            actions.Dock = DockStyle.Fill;
            actions.Margin = new Padding(13, 2, 13, 2);
            content.Dock = DockStyle.Fill;
            content.Margin = new Padding(13, 2, 13, 2);

            if (content is RoundedPanel roundedContent)
            {
                foreach (Control child in roundedContent.Controls)
                {
                    if (child is DataGridView grid)
                        FitGridToRoundedPanel(roundedContent, grid);
                }
            }

            metrics.ResumeLayout(true);
            pageLayout.ResumeLayout(true);
        }

        // For DataGridViews: fills the rounded panel and clips the grid corners so the header follows the curve.
        internal static void FitGridToRoundedPanel(RoundedPanel panel, DataGridView grid)
        {
            panel.Padding = Padding.Empty;
            grid.Dock = DockStyle.Fill;

            void ClipCorners()
            {
                if (grid.Width <= 0 || grid.Height <= 0) return;

                int d = Math.Max(1, panel.BorderRadius * 2);
                d = Math.Min(d, Math.Min(grid.Width, grid.Height));
                using var path = new System.Drawing.Drawing2D.GraphicsPath();
                path.AddArc(0, 0, d, d, 180, 90);
                path.AddArc(grid.Width - d, 0, d, d, 270, 90);
                path.AddArc(grid.Width - d, grid.Height - d, d, d, 0, 90);
                path.AddArc(0, grid.Height - d, d, d, 90, 90);
                path.CloseFigure();

                Region? old = grid.Region;
                grid.Region = new Region(path);
                old?.Dispose();
            }

            grid.SizeChanged += (_, _) => ClipCorners();
            ClipCorners();
        }

        internal static void LayoutActions(Control actionRow, Control search, Control filter, Control action)
        {
            int width = actionRow.ClientSize.Width;
            int actionWidth = Math.Min(MaximumActionWidth, Math.Max(MinimumActionWidth, (int)(width * 0.18)));
            int filterWidth = Math.Min(MaximumFilterWidth, Math.Max(MinimumFilterWidth, (int)(width * 0.16)));
            int searchWidth = Math.Max(MinimumSearchWidth, width - actionWidth - filterWidth - ActionGap * 2);
            int top = Math.Max(0, (actionRow.ClientSize.Height - ActionHeight) / 2);

            search.SetBounds(0, top + 3, searchWidth, SearchAndFilterHeight);
            filter.SetBounds(searchWidth + ActionGap, top + 3, filterWidth, SearchAndFilterHeight);
            action.SetBounds(searchWidth + ActionGap * 2 + filterWidth, top, actionWidth, ActionHeight);
        }
    }
}
