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
            pageLayout.Padding = Padding.Empty;
            pageLayout.Margin = new Padding(3, 2, 3, 2);
            pageLayout.ColumnCount = 1;
            pageLayout.RowCount = 4;
            pageLayout.ColumnStyles.Clear();
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.RowStyles.Clear();
            pageLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

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

                var old = grid.Region;
                grid.Region = new Region(path);
                old?.Dispose();
            }

            grid.SizeChanged += (_, _) => ClipCorners();
            ClipCorners();
        }

        internal static void LayoutActions(Control actionRow, Control search, Control filter, Control action)
        {
            ConfigureActionControls(search, filter, action);

            int width = actionRow.ClientSize.Width;
            int height = actionRow.ClientSize.Height;
            if (width <= 0 || height <= 0) return;

            int actionWidth = Math.Min(MaximumActionWidth, Math.Max(MinimumActionWidth, (int)(width * 0.18)));
            int filterWidth = Math.Min(MaximumFilterWidth, Math.Max(MinimumFilterWidth, (int)(width * 0.16)));
            int searchWidth = Math.Max(MinimumSearchWidth, width - actionWidth - filterWidth - ActionGap * 2);
            int filterLeft = searchWidth + ActionGap;
            int actionLeft = filterLeft + filterWidth + ActionGap;

            actionRow.SuspendLayout();
            search.SetBounds(0, 0, searchWidth, SearchAndFilterHeight);
            filter.SetBounds(filterLeft, 0, filterWidth, SearchAndFilterHeight);
            action.SetBounds(actionLeft, 0, actionWidth, ActionHeight);

            // Krypton boxes keep their own height, so centre each control on the row using its real height.
            search.Top = (height - search.Height) / 2;
            filter.Top = (height - filter.Height) / 2;
            action.Top = (height - action.Height) / 2;

            LayoutActionSurface(actionRow, search);
            LayoutActionSurface(actionRow, filter);
            search.BringToFront();
            filter.BringToFront();
            action.BringToFront();
            actionRow.ResumeLayout(false);
        }

        private static void ConfigureActionControls(Control search, Control filter, Control action)
        {
            if (search is Krypton.Toolkit.KryptonTextBox searchBox)
            {
                searchBox.StateCommon.Back.Color1 = Color.White;
                searchBox.StateCommon.Border.Color1 = Color.FromArgb(224, 227, 229);
                searchBox.StateCommon.Border.Rounding = 10F;
                searchBox.StateCommon.Content.Font = new Font("Century Gothic", 8.5F);
                searchBox.StateCommon.Content.Color1 = Color.FromArgb(125, 130, 134);
            }

            if (filter is Krypton.Toolkit.KryptonComboBox filterBox)
            {
                filterBox.StateCommon.ComboBox.Back.Color1 = Color.White;
                filterBox.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(224, 227, 229);
                filterBox.StateCommon.ComboBox.Border.Rounding = 10F;
                filterBox.StateCommon.ComboBox.Content.Font = new Font("Century Gothic", 8.5F);
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
