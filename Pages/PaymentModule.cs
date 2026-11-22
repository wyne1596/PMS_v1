using MySql.Data.MySqlClient;
using PMS_v1.Database;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    public partial class PaymentModule : UserControl
    {
        public PaymentModule()
        {
            InitializeComponent();
            PMS_v1.UserControls.ModulePageLayout.ApplyStandardLayout(
                tlpMain, pnlHeader, tlpMetrics, pnlActions, roundedPanelTable);
            PMS_v1.UserControls.ModulePageLayout.FitGridToRoundedPanel(roundedPanelTable, dgvPayments);
            if (statCardRefunded.CardIcon is null)
                statCardRefunded.CardIcon = CreateRefundIcon();
            ConfigurePaymentGrid();
            PMS_v1.UserControls.GridHelper.ShowSelection(dgvPayments);
            LayoutActionRow();
            pnlActions.Resize += (_, _) => LayoutActionRow();
            dgvPayments.CellPainting += DgvPayments_CellPainting;
            txtSearch.TextChanged += (_, _) => ApplyPaymentFilters();
            cmbFilter.SelectedIndexChanged += (_, _) => ApplyPaymentFilters();
            //LoadStats();
            //LoadPayments();
        }

        private void ConfigurePaymentGrid()
        {
            cmbFilter.Items.AddRange(new object[] { "All Statuses", "Completed", "Pending", "Failed", "Refunded" });
            cmbFilter.SelectedIndex = 0;
            btnNewTransaction.Values.Text = "＋  New Transaction";

            statCardCompleted.CardCaption = "Completed";
            statCardCompleted.CardNumber = "00";
            statCardPending.CardCaption = "Pending";
            statCardPending.CardNumber = "00";
            statCardFailed.CardCaption = "Failed";
            statCardFailed.CardNumber = "00";
            statCardRefunded.CardCaption = "Refunded";
            statCardRefunded.CardNumber = "00";

            dgvPayments.AutoGenerateColumns = false;
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.AllowUserToResizeRows = false;
            dgvPayments.MultiSelect = false;
            dgvPayments.ReadOnly = true;
            dgvPayments.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayments.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPayments.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvPayments.EnableHeadersVisualStyles = false;
            dgvPayments.RowTemplate.Height = 42;
            dgvPayments.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(74, 151, 196),
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(74, 151, 196),
                SelectionForeColor = Color.White
            };
            dgvPayments.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 49, 53),
                Font = new Font("Century Gothic", 9F),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 8, 0),
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };
            dgvPayments.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                SelectionBackColor = Color.White,
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };

            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Reference",
                HeaderText = "REFERENCE",
                FillWeight = 19,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tenant",
                HeaderText = "TENANT",
                FillWeight = 20,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Mode",
                HeaderText = "MODE",
                FillWeight = 15,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Amount",
                HeaderText = "AMOUNT",
                FillWeight = 18,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight
                }
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Date",
                HeaderText = "DATE",
                FillWeight = 18,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter
                }
            });
            dgvPayments.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "STATUS",
                FillWeight = 20,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Padding = new Padding(0, 0, 4, 0)
                }
            });
        }

        private void ApplyPaymentFilters()
        {
            string search = txtSearch.Text.Trim();
            string status = cmbFilter.SelectedIndex <= 0 ? string.Empty : cmbFilter.Text;

            PMS_v1.UserControls.GridHelper.Filter(dgvPayments, row =>
            {
                bool matchesSearch = string.IsNullOrEmpty(search) ||
                    PMS_v1.UserControls.GridHelper.Has(row, "Reference", search) || PMS_v1.UserControls.GridHelper.Has(row, "Tenant", search) ||
                    PMS_v1.UserControls.GridHelper.Has(row, "Mode", search) || PMS_v1.UserControls.GridHelper.Has(row, "Amount", search) ||
                    PMS_v1.UserControls.GridHelper.Has(row, "Date", search) || PMS_v1.UserControls.GridHelper.Has(row, "Status", search);
                bool matchesStatus = string.IsNullOrEmpty(status) ||
                    string.Equals(row.Cells["Status"].Value?.ToString(), status, StringComparison.OrdinalIgnoreCase);
                return matchesSearch && matchesStatus;
            });
        }

        private void LayoutActionRow()
        {
            PMS_v1.UserControls.ActionRowLayout.PackRight(
                pnlActions, txtSearch, cmbFilter, btnNewTransaction);
        }

        private void DgvPayments_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            PMS_v1.UserControls.StatusBadge.Paint(dgvPayments, e, "Status");
        }

        private static Bitmap CreateRefundIcon()
        {
            var icon = new Bitmap(48, 48);
            using Graphics graphics = Graphics.FromImage(icon);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            using var pen = new Pen(Color.FromArgb(74, 151, 196), 3.2F)
            {
                StartCap = LineCap.Flat,
                EndCap = LineCap.Triangle
            };

            graphics.DrawLine(pen, 8, 16, 39, 16);
            graphics.DrawLine(pen, 40, 32, 9, 32);
            return icon;
        }

        // Load statcards
        /*private void LoadStats()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                   COUNT(CASE WHEN STATUS = 'Completed' THEN 1 END) AS Completed,
                                   COUNT(CASE WHEN STATUS = 'Pending' THEN 1 END) AS Pending,
                                   COUNT(CASE WHEN STATUS = 'Failed' THEN 1 END) AS Failed,
                                   COUNT(CASE WHEN STATUS = 'Refunded' THEN 1 END) AS Refunded
                               FROM payment";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        statCardCompleted.CardNumber = reader["Completed"].ToString();
                        statCardPending.CardNumber = reader["Pending"].ToString();
                        statCardFailed.CardNumber = reader["Failed"].ToString();
                        statCardRefunded.CardNumber = reader["Refunded"].ToString();
                    }
                }
            }
        }
*/
/*        private void LoadPayments()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                                SELECT
                                    p.PAYMENT_ID,
                                    p.REF_NO,
                                    CONCAT(r.FIRST_NAME, ' ', r.LAST_NAME) AS Tenant,
                                    p.`MODE`        AS PayMode,
                                    p.AMOUNT,
                                    p.PAYMENT_DATE  AS PaymentDate,
                                    p.STATUS
                                FROM payment p
                                JOIN billing b  ON b.BILLING_ID  = p.BILLING_ID
                                JOIN lease l    ON l.LEASE_ID    = b.LEASE_ID
                                JOIN resident r ON r.RESIDENT_ID = l.RESIDENT_ID
                                ORDER BY p.PAYMENT_DATE DESC, p.PAYMENT_ID DESC";

                using (var cmd = new MySqlCommand(query, conn))
                using (var reader = cmd.ExecuteReader())
                {
                    dgvPayments.Rows.Clear();

                    while (reader.Read())
                    {
                        int index = dgvPayments.Rows.Add(
                            reader["REF_NO"].ToString(),
                            reader["Tenant"].ToString(),
                            reader["PayMode"].ToString(),
                            "₱" + Convert.ToDecimal(reader["AMOUNT"]).ToString("N2"),
                            Convert.ToDateTime(reader["PaymentDate"]).ToString("MMM dd, yyyy"),
                            reader["STATUS"].ToString());

                        dgvPayments.Rows[index].Tag = Convert.ToInt32(reader["PAYMENT_ID"]);
                    }
                }
            }

            ApplyPaymentFilters();
        }
*/
        private void btnNewTransaction_Click(object sender, EventArgs e)
        {
            using (var f = new RecordForm(FormMode.New, "Transaction", FormDefinitions.Payment()))
            {
                if (f.ShowDialog(this.FindForm()) == DialogResult.OK)
                {
                    // backend: read f.Values["amount"], f.Values["dueDate"], and so on
                }
            }
        }
    }
}