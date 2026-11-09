using System;
using System.Drawing;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    public partial class BillingModule : UserControl
    {
        private const string SearchPlaceholder = "⌕  Search bill or tenant...";

        public BillingModule()
        {
            InitializeComponent();
            PMS_v1.UserControls.ModulePageLayout.ApplyStandardLayout(
                tlpMain, pnlHeader, tlpMetrics, pnlActions, roundedPanelTable);
            ConfigureBillingGrid();
            PopulateSampleRows();
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
            txtSearch.TextChanged += (_, _) => ApplyBillFilters();
            cmbFilter.SelectedIndexChanged += (_, _) => ApplyBillFilters();
            dgvBills.CellPainting += DgvBills_CellPainting;
        }

        private void ConfigureBillingGrid()
        {
            txtSearch.Text = SearchPlaceholder;
            cmbFilter.Items.AddRange(new object[]
            {
                "All Statuses", "Paid", "Partially Paid", "Unpaid", "Overdue", "Canceled"
            });
            cmbFilter.SelectedIndex = 0;
            btnNewBill.Values.Text = "＋  New Bill";

            dgvBills.AutoGenerateColumns = false;
            dgvBills.AllowUserToAddRows = false;
            dgvBills.AllowUserToDeleteRows = false;
            dgvBills.AllowUserToResizeRows = false;
            dgvBills.MultiSelect = false;
            dgvBills.ReadOnly = true;
            dgvBills.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBills.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvBills.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvBills.EnableHeadersVisualStyles = false;
            dgvBills.RowTemplate.Height = 42;
            dgvBills.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(74, 151, 196),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(74, 151, 196),
                SelectionForeColor = Color.White
            };
            dgvBills.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 49, 53),
                Font = new Font("Segoe UI", 9F),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 8, 0),
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };
            dgvBills.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };

            dgvBills.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Bill",
                HeaderText = "BILL",
                FillWeight = 16,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tenant",
                HeaderText = "TENANT",
                FillWeight = 46,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Due",
                HeaderText = "DUE",
                FillWeight = 18,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Padding = new Padding(8, 0, 14, 0)
                }
            });
            dgvBills.Columns.Add(new DataGridViewTextBoxColumn
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

        private void PopulateSampleRows()
        {
            dgvBills.Rows.Add("B-001", "Sophia Leigh R. Manoguid", "5,000", "Paid");
            dgvBills.Rows.Add("B-002", "Alexis N. Prado", "10,000", "Unpaid");
            dgvBills.Rows.Add("B-003", "Shella Mith C. Belarmino", "6,356", "Partially Paid");
            dgvBills.Rows.Add("B-004", "Wyne Benjamin Constantino", "6,767", "Overdue");
            dgvBills.Rows.Add("B-005", "Ryan Villanueva", "1,234", "Canceled");
        }

        private void LayoutActionRow()
        {
            PMS_v1.UserControls.ModulePageLayout.LayoutActions(
                pnlActions, txtSearch, cmbFilter, btnNewBill);
        }

        private void ApplyBillFilters()
        {
            string searchText = txtSearch.Text == SearchPlaceholder ? string.Empty : txtSearch.Text.Trim();
            string selectedStatus = cmbFilter.SelectedIndex <= 0 ? string.Empty : cmbFilter.Text;

            foreach (DataGridViewRow row in dgvBills.Rows)
            {
                bool matchesSearch = string.IsNullOrEmpty(searchText) ||
                    row.Cells["Bill"].Value?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ||
                    row.Cells["Tenant"].Value?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ||
                    row.Cells["Due"].Value?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ||
                    row.Cells["Status"].Value?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true;
                bool matchesStatus = string.IsNullOrEmpty(selectedStatus) ||
                    string.Equals(row.Cells["Status"].Value?.ToString(), selectedStatus, StringComparison.OrdinalIgnoreCase);

                row.Visible = matchesSearch && matchesStatus;
            }
        }

        private void DgvBills_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgvBills.Columns["Status"].Index)
                return;

            e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

            string status = Convert.ToString(e.FormattedValue) ?? string.Empty;
            Font font = e.CellStyle.Font ?? dgvBills.Font;
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
    }
}
