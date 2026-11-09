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
            pageLayout.Padding = new Padding(42, 18, 42, 12);
            pageLayout.ColumnCount = 1;
            pageLayout.RowCount = 4;
            pageLayout.ColumnStyles.Clear();
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.RowStyles.Clear();
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            header.Dock = DockStyle.Fill;
            header.Margin = new Padding(3);
            metrics.Dock = DockStyle.Fill;
            metrics.Margin = Padding.Empty;
            metrics.ColumnCount = metrics.Controls.Count;
            metrics.ColumnStyles.Clear();

            if (metrics.ColumnCount > 0)
            {
                float columnWidth = 100F / metrics.ColumnCount;
                for (int i = 0; i < metrics.ColumnCount; i++)
                    metrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, columnWidth));
            }

            foreach (Control card in metrics.Controls)
            {
                card.Dock = DockStyle.Fill;
                card.Margin = new Padding(8, 0, 8, 0);
            }

            actions.Dock = DockStyle.Fill;
            actions.Margin = new Padding(3);
            content.Dock = DockStyle.Fill;
            content.Margin = new Padding(8);

            metrics.ResumeLayout(true);
            pageLayout.ResumeLayout(true);
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
