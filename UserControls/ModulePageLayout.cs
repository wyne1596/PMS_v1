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

        // Same metrics sizing as the Dashboard: 154px row minus 3px margin above and below = 148px cards.
        internal const int MetricsRowHeight = 154;

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
            pageLayout.Margin = new Padding(3, 3, 3, 3);
            pageLayout.ColumnCount = 1;
            pageLayout.RowCount = 4;
            pageLayout.ColumnStyles.Clear();
            pageLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            pageLayout.RowStyles.Clear();
            pageLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, MetricsRowHeight));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Absolute, 72F));
            pageLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            header.Dock = DockStyle.Fill;
            header.Margin = new Padding(3, 3, 3, 3);
            LayoutMetricCards(metrics);

            actions.Dock = DockStyle.Fill;
            actions.Margin = new Padding(15, 3, 15, 3);
            content.Dock = DockStyle.Fill;
            content.Margin = new Padding(15, 3, 15, 3);

            metrics.ResumeLayout(true);
            pageLayout.ResumeLayout(true);
        }

        // Lets a page with its own table (the Dashboard) use exactly the same metrics row as the module pages.
        internal static void ApplyMetricsRow(TableLayoutPanel pageLayout, int rowIndex, TableLayoutPanel metrics)
        {
            pageLayout.RowStyles[rowIndex] = new RowStyle(SizeType.Absolute, MetricsRowHeight);
            LayoutMetricCards(metrics);
        }

        // Equal-width columns, cards fill their cell, 15px outer / 7px inner gaps (as on the Dashboard).
        private static void LayoutMetricCards(TableLayoutPanel metrics)
        {
            metrics.SuspendLayout();
            metrics.Dock = DockStyle.Fill;
            metrics.Margin = new Padding(3, 3, 3, 3);
            metrics.ColumnCount = metrics.Controls.Count;
            metrics.ColumnStyles.Clear();

            int cardCount = metrics.Controls.Count;
            if (cardCount > 0)
            {
                float columnWidth = 100F / cardCount;
                for (int i = 0; i < cardCount; i++)
                    metrics.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, columnWidth));
            }

            for (int i = 0; i < cardCount; i++)
            {
                Control card = metrics.GetControlFromPosition(i, 0) ?? metrics.Controls[i];
                card.Dock = DockStyle.Fill;
                card.Margin = new Padding(i == 0 ? 15 : 7, 0, i == cardCount - 1 ? 15 : 7, 0);
            }

            metrics.ResumeLayout(true);
        }

        // Same table look as Billing / Payment / Maintenance / Leasing.
        internal static void ApplyStandardGridStyle(DataGridView grid)
        {
            grid.AutoGenerateColumns = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.AllowUserToResizeRows = false;
            grid.MultiSelect = false;
            grid.ReadOnly = true;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            grid.EnableHeadersVisualStyles = false;
            grid.RowTemplate.Height = 42;
            grid.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(74, 151, 196),
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(74, 151, 196),
                SelectionForeColor = Color.White
            };
            grid.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 49, 53),
                Font = new Font("Century Gothic", 9F),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 8, 0),
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };
            grid.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };
        }

        // Draws the rounded status pill used on the other pages' STATUS column.
        internal static void AttachStatusBadge(DataGridView grid, string columnName)
        {
            grid.CellPainting += (sender, e) =>
            {
                if (e.RowIndex < 0 || e.ColumnIndex != grid.Columns[columnName].Index)
                    return;

                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                string status = Convert.ToString(e.FormattedValue) ?? string.Empty;
                Font font = e.CellStyle.Font ?? grid.Font;
                Size textSize = TextRenderer.MeasureText(status, font);
                int badgeWidth = Math.Min(e.CellBounds.Width - 8, textSize.Width + 14);
                int badgeHeight = Math.Min(24, e.CellBounds.Height - 8);
                var badgeBounds = new Rectangle(
                    e.CellBounds.Left + (e.CellBounds.Width - badgeWidth) / 2,
                    e.CellBounds.Top + (e.CellBounds.Height - badgeHeight) / 2,
                    badgeWidth,
                    badgeHeight);

                using (var badge = new SolidBrush(Color.FromArgb(218, 237, 248)))
                    e.Graphics.FillRectangle(badge, badgeBounds);

                TextRenderer.DrawText(e.Graphics, status, font, badgeBounds,
                    Color.FromArgb(45, 93, 120),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding);
                e.Handled = true;
            };
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
