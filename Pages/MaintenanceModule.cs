using System.Drawing.Drawing2D;

namespace PMS_v1.Pages
{
    public partial class MaintenanceModule : UserControl
    {
        private const string SearchPlaceholder = "⌕  Search maintenance requests...";

        public MaintenanceModule()
        {
            InitializeComponent();
            PMS_v1.UserControls.ModulePageLayout.ApplyStandardLayout(
                tlpMain, pnlHeader, tlpMetrics, pnlActions, roundedPanelTable);
            ConfigureMaintenanceGrid();
            LayoutActionRow();

            pnlActions.Resize += (_, _) => LayoutActionRow();
            txtSearch.Enter += (_, _) =>
            {
                if (txtSearch.Text == SearchPlaceholder)
                    txtSearch.Text = string.Empty;
            };
            txtSearch.Leave += (_, _) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                    txtSearch.Text = SearchPlaceholder;
            };
            txtSearch.TextChanged += (_, _) => ApplyRequestFilters();
            cmbFilter.SelectedIndexChanged += (_, _) => ApplyRequestFilters();
            dgvRequests.CellPainting += DgvRequests_CellPainting;
        }

        private void ConfigureMaintenanceGrid()
        {
            statCardCompleted.CardCaption = "Completed";
            statCardCompleted.CardNumber = "00";
            statCardCompleted.CardIcon = PMS_v1.Resources.Resources.check;
            statCardScheduled.CardCaption = "Scheduled";
            statCardScheduled.CardNumber = "00";
            statCardScheduled.CardIcon = PMS_v1.Resources.Resources.clock;
            statCardInProgress.CardCaption = "In Progress";
            statCardInProgress.CardNumber = "00";
            statCardInProgress.CardIcon = CreateInProgressIcon();
            statCardCanceled.CardCaption = "Canceled";
            statCardCanceled.CardNumber = "00";

            txtSearch.Text = SearchPlaceholder;
            cmbFilter.Items.AddRange(new object[] { "All Statuses", "Completed", "Scheduled", "In Progress", "Canceled" });
            cmbFilter.SelectedIndex = 0;

            dgvRequests.AutoGenerateColumns = false;
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.AllowUserToDeleteRows = false;
            dgvRequests.AllowUserToResizeRows = false;
            dgvRequests.MultiSelect = false;
            dgvRequests.ReadOnly = true;
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRequests.EnableHeadersVisualStyles = false;
            dgvRequests.RowTemplate.Height = 42;
            dgvRequests.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(74, 151, 196),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(74, 151, 196),
                SelectionForeColor = Color.White
            };
            dgvRequests.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 49, 53),
                Font = new Font("Segoe UI", 9F),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 8, 0),
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };
            dgvRequests.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };

            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Request",
                HeaderText = "REQUEST",
                FillWeight = 20,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Unit",
                HeaderText = "UNIT",
                FillWeight = 20,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Issue",
                HeaderText = "ISSUE",
                FillWeight = 40,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "STATUS",
                FillWeight = 20,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Padding = new Padding(4, 0, 4, 0)
                }
            });
        }

        private void LayoutActionRow()
        {
            PMS_v1.UserControls.ModulePageLayout.LayoutActions(
                pnlActions, txtSearch, cmbFilter, btnNewRequest);
        }

        private void ApplyRequestFilters()
        {
            string searchText = txtSearch.Text == SearchPlaceholder ? string.Empty : txtSearch.Text.Trim();
            string selectedStatus = cmbFilter.SelectedIndex <= 0 ? string.Empty : cmbFilter.Text;

            foreach (DataGridViewRow row in dgvRequests.Rows)
            {
                bool matchesSearch = string.IsNullOrEmpty(searchText) ||
                    row.Cells["Request"].Value?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ||
                    row.Cells["Unit"].Value?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ||
                    row.Cells["Issue"].Value?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ||
                    row.Cells["Status"].Value?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true;
                bool matchesStatus = string.IsNullOrEmpty(selectedStatus) ||
                    string.Equals(row.Cells["Status"].Value?.ToString(), selectedStatus, StringComparison.OrdinalIgnoreCase);

                row.Visible = matchesSearch && matchesStatus;
            }
        }

        private void DgvRequests_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvRequests.Columns["Status"].Index)
                return;

            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            string status = Convert.ToString(e.FormattedValue) ?? string.Empty;
            Font font = e.CellStyle.Font ?? dgvRequests.Font;
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
        }

        private static Bitmap CreateInProgressIcon()
        {
            var icon = new Bitmap(48, 48);
            using Graphics graphics = Graphics.FromImage(icon);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.Transparent);

            using var blue = new SolidBrush(Color.FromArgb(74, 151, 196));
            using var white = new SolidBrush(Color.White);
            using var gearPen = new Pen(Color.FromArgb(74, 151, 196), 2.5F);

            Point[] hourglass =
            {
                new(8, 7), new(29, 7), new(29, 11), new(22, 19),
                new(22, 22), new(29, 30), new(29, 35), new(8, 35),
                new(8, 30), new(15, 22), new(15, 19), new(8, 11)
            };
            graphics.FillPolygon(blue, hourglass);
            graphics.FillPolygon(white, new[] { new Point(12, 11), new Point(25, 11), new Point(19, 18) });
            graphics.FillPolygon(white, new[] { new Point(19, 25), new Point(25, 31), new Point(12, 31) });

            graphics.DrawLine(gearPen, 34, 26, 34, 31);
            graphics.DrawLine(gearPen, 34, 37, 34, 42);
            graphics.DrawLine(gearPen, 27, 34, 32, 34);
            graphics.DrawLine(gearPen, 36, 34, 41, 34);
            graphics.DrawLine(gearPen, 29, 29, 32, 32);
            graphics.DrawLine(gearPen, 36, 36, 39, 39);
            graphics.DrawLine(gearPen, 29, 39, 32, 36);
            graphics.DrawLine(gearPen, 36, 32, 39, 29);
            graphics.DrawEllipse(gearPen, 30, 30, 8, 8);

            return icon;
        }

        private void statCardCanceled_Load(object sender, EventArgs e)
        {

        }
    }
}
