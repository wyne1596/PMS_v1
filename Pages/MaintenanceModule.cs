using MySql.Data.MySqlClient;
using PMS_v1.Database;

namespace PMS_v1.Pages
{
    public partial class MaintenanceModule : UserControl
    {

        public MaintenanceModule()
        {
            InitializeComponent();
            PMS_v1.UserControls.ModulePageLayout.ApplyStandardLayout(
                tlpMain, pnlHeader, tlpMetrics, pnlActions, roundedPanelTable);
            PMS_v1.UserControls.ModulePageLayout.FitGridToRoundedPanel(roundedPanelTable, dgvRequests);
            ConfigureMaintenanceGrid();
            LayoutActionRow();

            pnlActions.Resize += (_, _) => LayoutActionRow();
            txtSearch.TextChanged += (_, _) => ApplyRequestFilters();
            cmbFilter.SelectedIndexChanged += (_, _) => ApplyRequestFilters();
            dgvRequests.CellPainting += DgvRequests_CellPainting;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (DesignMode || System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

            LoadStats();
        }

        private void ConfigureMaintenanceGrid()
        {
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
                Font = new Font("Century Gothic", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(74, 151, 196),
                SelectionForeColor = Color.White
            };
            dgvRequests.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 49, 53),
                Font = new Font("Century Gothic", 9F),
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
            string searchText = txtSearch.Text.Trim();
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

        private void statCardCanceled_Load(object sender, EventArgs e)
        {

        }

        // Load statcards
        // statCardCanceled is not loaded: maintenance_request.STATUS has no Canceled value.
        private void LoadStats()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                   COUNT(CASE WHEN STATUS IN ('Resolved', 'Closed') THEN 1 END) AS Completed,
                                   COUNT(CASE WHEN STATUS = 'Open' THEN 1 END) AS Scheduled,
                                   COUNT(CASE WHEN STATUS = 'In Progress' THEN 1 END) AS InProgress
                               FROM maintenance_request";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        statCardCompleted.CardNumber = reader["Completed"].ToString();
                        statCardScheduled.CardNumber = reader["Scheduled"].ToString();
                        statCardInProgress.CardNumber = reader["InProgress"].ToString();
                    }
                }
            }
        }
    }
}