using System.Runtime.CompilerServices;

namespace PMS_v1.UserControls
{
    internal static class ModulePageLayout
    {
        private static readonly ConditionalWeakTable<Control, RoundedPanel> ActionSurfaces = new();
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
            ConfigureActionControls(search, filter, action);

            int width = actionRow.ClientSize.Width;
            int actionWidth = Math.Min(MaximumActionWidth, Math.Max(MinimumActionWidth, (int)(width * 0.18)));
            int filterWidth = Math.Min(MaximumFilterWidth, Math.Max(MinimumFilterWidth, (int)(width * 0.16)));
            int searchWidth = Math.Max(MinimumSearchWidth, width - actionWidth - filterWidth - ActionGap * 2);
            int top = Math.Max(0, (actionRow.ClientSize.Height - ActionHeight) / 2);

            search.SetBounds(0, top + 3, searchWidth, SearchAndFilterHeight);
            filter.SetBounds(searchWidth + ActionGap, top + 3, filterWidth, SearchAndFilterHeight);
            action.SetBounds(searchWidth + ActionGap * 2 + filterWidth, top, actionWidth, ActionHeight);

            LayoutActionSurface(actionRow, search);
            LayoutActionSurface(actionRow, filter);
            search.BringToFront();
            filter.BringToFront();
            action.BringToFront();
        }

        private static void ConfigureActionControls(Control search, Control filter, Control action)
        {
            if (search is Krypton.Toolkit.KryptonTextBox searchBox)
            {
                searchBox.StateCommon.Back.Color1 = Color.White;
                searchBox.StateCommon.Border.Color1 = Color.FromArgb(224, 227, 229);
                searchBox.StateCommon.Border.Rounding = 10F;
                searchBox.StateCommon.Content.Font = new Font("Segoe UI", 8.5F);
                searchBox.StateCommon.Content.Color1 = Color.FromArgb(125, 130, 134);
            }

            if (filter is Krypton.Toolkit.KryptonComboBox filterBox)
            {
                filterBox.StateCommon.ComboBox.Back.Color1 = Color.White;
                filterBox.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(224, 227, 229);
                filterBox.StateCommon.ComboBox.Border.Rounding = 10F;
                filterBox.StateCommon.ComboBox.Content.Font = new Font("Segoe UI", 8.5F);
                filterBox.StateCommon.ComboBox.Content.Color1 = Color.FromArgb(125, 130, 134);
            }

            if (action is Krypton.Toolkit.KryptonButton button)
            {
                button.StateCommon.Border.Rounding = 10F;
            }
        }

        private static void LayoutActionSurface(Control actionRow, Control control)
        {
            RoundedPanel surface = ActionSurfaces.GetValue(control, key =>
            {
                var panel = new RoundedPanel
                {
                    BackColor = Color.White,
                    BorderColor = Color.Transparent,
                    BorderRadius = 10,
                    BorderThickness = 0,
                    ShadowColor = Color.Black,
                    ShadowOffsetY = 2,
                    ShadowOpacity = 32,
                    ShadowSize = 4,
                    TabStop = false
                };
                actionRow.Controls.Add(panel);
                panel.SendToBack();
                return panel;
            });

            if (surface.Parent != actionRow)
            {
                surface.Parent?.Controls.Remove(surface);
                actionRow.Controls.Add(surface);
            }

            surface.SetBounds(control.Left - 8, control.Top - 8,
                control.Width + 16, control.Height + 16);
            surface.SendToBack();
        }
    }
}
