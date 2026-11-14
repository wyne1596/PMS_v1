using System.Drawing;

namespace PMS_v1.Pages
{
    public partial class Dashboard : UserControl
    {
        public Dashboard()
        {
            InitializeComponent();
            ConfigureTransactionsGrid();
        }

        private void ConfigureTransactionsGrid()
        {
            dgvTransactions.AutoGenerateColumns = false;
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.AllowUserToResizeRows = false;
            dgvTransactions.MultiSelect = false;
            dgvTransactions.ReadOnly = true;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTransactions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTransactions.EnableHeadersVisualStyles = false;
            dgvTransactions.RowTemplate.Height = 36;
            dgvTransactions.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(248, 249, 250),
                ForeColor = Color.FromArgb(108, 117, 125),
                Font = new Font("Segoe UI", 8F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                SelectionBackColor = Color.FromArgb(248, 249, 250),
                SelectionForeColor = Color.FromArgb(108, 117, 125)
            };
            dgvTransactions.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 49, 53),
                Font = new Font("Segoe UI", 8F),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };

            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Unit", HeaderText = "UNIT", FillWeight = 14,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tenant", HeaderText = "TENANT", FillWeight = 36,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Date", HeaderText = "DATE", FillWeight = 21,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Amount", HeaderText = "AMOUNT", FillWeight = 16,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvTransactions.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status", HeaderText = "STATUS", FillWeight = 13,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }

    }
}
