using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using PMS_v1.Database;
using PMS_v1.Helper;
using System;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    public partial class DashboardModule : UserControl
    {
        public DashboardModule()
        {
            InitializeComponent();
            PMS_v1.UserControls.ModulePageLayout.ApplyMetricsRow(tlpMain, 1, tlpMetrics);
            PMS_v1.UserControls.ModulePageLayout.FitGridToRoundedPanel(roundedPanelTable, dgvRecent);

            ConfigureRecentGrid();
            LoadStats();
            LoadRecentTransactions();
            lblGreeting.Text = $"Welcome, {Helper.Session.Role}";
        }

        // Recent transactions table: the newest payments, same look as the other pages
        private void ConfigureRecentGrid()
        {
            dgvRecent.AutoGenerateColumns = false;
            foreach (DataGridViewColumn column in dgvRecent.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            // amount is right-aligned, status is centered; headers follow their columns
            colAmount.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            colAmount.DefaultCellStyle.Padding = new Padding(8, 0, 20, 0);
            colAmount.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            colAmount.HeaderCell.Style.Padding = new Padding(8, 0, 20, 0);

            colStatus.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStatus.DefaultCellStyle.Padding = new Padding(4, 0, 4, 0);
            colStatus.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            colStatus.HeaderCell.Style.Padding = new Padding(4, 0, 4, 0);

            PMS_v1.UserControls.StatusBadge.Attach(dgvRecent, "colStatus");
        }

        private void LoadRecentTransactions()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                    p.PAYMENT_ID,
                                    CONCAT(r.FIRST_NAME, ' ', r.LAST_NAME) AS Tenant,
                                    p.AMOUNT,
                                    p.PAYMENT_DATE,
                                    p.STATUS
                               FROM payment p
                               JOIN billing b  ON b.BILLING_ID  = p.BILLING_ID
                               JOIN lease l    ON l.LEASE_ID    = b.LEASE_ID
                               JOIN resident r ON r.RESIDENT_ID = l.RESIDENT_ID
                               ORDER BY p.PAYMENT_DATE DESC, p.PAYMENT_ID DESC
                               LIMIT 10";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dgvRecent.Rows.Clear();

                    while (reader.Read())
                    {
                        int rowIndex = dgvRecent.Rows.Add(
                            reader["Tenant"].ToString(),
                            "₱" + Convert.ToDecimal(reader["AMOUNT"]).ToString("N2"),
                            Convert.ToDateTime(reader["PAYMENT_DATE"]).ToString("MMM dd, yyyy"),
                            reader["STATUS"].ToString());

                        dgvRecent.Rows[rowIndex].Tag = Convert.ToInt32(reader["PAYMENT_ID"]);
                    }
                }
            }

            dgvRecent.ClearSelection();   // read-only overview: don't start with the first row highlighted
        }

        // Load statcards
        private void LoadStats()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                   (SELECT COALESCE(SUM(b.AMOUNT - COALESCE(p.Paid, 0)), 0)
                                      FROM billing b
                                      LEFT JOIN (SELECT BILLING_ID, SUM(AMOUNT) AS Paid
                                                   FROM payment
                                                  WHERE STATUS = 'Completed'
                                                  GROUP BY BILLING_ID) p ON p.BILLING_ID = b.BILLING_ID
                                     WHERE b.STATUS IN ('Unpaid', 'Partially Paid', 'Overdue')) AS UnpaidBalance,
                                   (SELECT COUNT(*) FROM lease WHERE STATUS = 'Expired') AS ExpiredLeases,
                                   (SELECT COUNT(*) FROM billing
                                     WHERE BILL_TYPE = 'Rent' AND STATUS = 'Overdue') AS RentOverdue,
                                   (SELECT COUNT(*) FROM maintenance_request
                                     WHERE STATUS IN ('Open', 'In Progress')) AS RepairsNeeded";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        statCardUnpaid.CardNumber = "₱" + Convert.ToDecimal(reader["UnpaidBalance"]).ToString("N0");
                        statCardExpired.CardNumber = reader["ExpiredLeases"].ToString();
                        statCardOverdue.CardNumber = reader["RentOverdue"].ToString();
                        statCardRepairs.CardNumber = reader["RepairsNeeded"].ToString();
                    }
                }
            }
        }
    }
}