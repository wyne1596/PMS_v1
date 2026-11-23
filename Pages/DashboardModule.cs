using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using PMS_v1.Database;
using PMS_v1.ExceptionHandler;
using PMS_v1.Helper;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    public partial class DashboardModule : UserControl
    {
        // Asks Main to open a page, the same names the side menu uses
        public event Action<string>? PageRequested;

        public DashboardModule()
        {
            InitializeComponent();
            PMS_v1.UserControls.ModulePageLayout.ApplyMetricsRow(tlpMain, 1, tlpMetrics);
            PMS_v1.UserControls.ModulePageLayout.ApplyMetricsRow(tlpMain, 2, tlpMetrics2);
            PMS_v1.UserControls.ModulePageLayout.FitGridToRoundedPanel(roundedPanelTable, dgvOverdue);

            ConfigureOverdueGrid();
            dgvOverdue.Paint += DgvOverdue_Paint;
            lblGreeting.Text = $"Welcome, {Helper.Session.Role}";

            // each stat card opens the page it summarizes
            MakeClickable(statCardUnpaid, "Billing");
            MakeClickable(statCardExpired, "Leasing");
            MakeClickable(statCardOverdue, "Billing");
            MakeClickable(statCardRepairs, "Maintenance");
            MakeClickable(statCardOccupancy, "Units");
            MakeClickable(statCardVacant, "Units");
            MakeClickable(statCardCollected, "Reports");
            MakeClickable(statCardDueSoon, "Billing");
            MakeClickable(statCardExpiring, "Leasing");
            MakeClickable(statCardUrgent, "Maintenance");

            // Main caches its pages, so reload every time the Dashboard is shown
            VisibleChanged += (_, _) => { if (Visible && !DesignMode) LoadDashboard(); };
        }

        private void MakeClickable(PMS_v1.UserControls.Statcard card, string page)
        {
            card.Cursor = Cursors.Hand;
            card.Click += (_, _) => PageRequested?.Invoke(page);
        }

        // Needs Attention table: the oldest overdue bills
        private void ConfigureOverdueGrid()
        {
            PMS_v1.UserControls.ModulePageLayout.ApplyStandardGridStyle(dgvOverdue);

            var centered = DataGridViewContentAlignment.MiddleCenter;
            var right = DataGridViewContentAlignment.MiddleRight;

            AddOverdueColumn("Tenant", "TENANT", 28);
            AddOverdueColumn("Unit", "UNIT", 10, centered, new Padding(4, 0, 4, 0));
            AddOverdueColumn("BillType", "BILL TYPE", 18);
            AddOverdueColumn("Due", "DUE", 16, centered, new Padding(8, 0, 14, 0));
            AddOverdueColumn("DaysLate", "DAYS LATE", 12, centered, new Padding(4, 0, 4, 0));
            AddOverdueColumn("Balance", "BALANCE", 16, right, new Padding(8, 0, 14, 0));
        }

        private void AddOverdueColumn(string name, string header, float fillWeight,
            DataGridViewContentAlignment? alignment = null, Padding? padding = null)
        {
            var column = new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                FillWeight = fillWeight,
                SortMode = DataGridViewColumnSortMode.NotSortable
            };

            if (alignment != null || padding != null)
            {
                column.DefaultCellStyle = new DataGridViewCellStyle();
                if (alignment != null) column.DefaultCellStyle.Alignment = alignment.Value;
                if (padding != null) column.DefaultCellStyle.Padding = padding.Value;
            }

            dgvOverdue.Columns.Add(column);
        }

        private void LoadDashboard()
        {
            try
            {
                LoadStats();
                LoadOverdueBills();
            }
            catch (MySqlException)
            {
                ErrorHandler.ShowLoadError(this, "dashboard", "Dashboard");
            }
        }

        // Load statcards (status is derived by the v_billing view)
        private void LoadStats()
        {
            DateTime monthStart = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                   (SELECT COALESCE(SUM(BALANCE), 0)
                                      FROM v_billing
                                     WHERE STATUS IN ('Unpaid', 'Partially Paid', 'Overdue')) AS UnpaidBalance,
                                   (SELECT COUNT(*) FROM lease WHERE STATUS = 'Expired') AS ExpiredLeases,
                                   (SELECT COUNT(*) FROM v_billing
                                     WHERE BILL_TYPE = 'Rent' AND STATUS = 'Overdue') AS RentOverdue,
                                   (SELECT COUNT(*) FROM maintenance_request
                                     WHERE STATUS IN ('Open', 'In Progress')) AS RepairsNeeded,
                                   (SELECT COUNT(*) FROM units WHERE STATUS = 'Occupied') AS OccupiedUnits,
                                   (SELECT COUNT(*) FROM units) AS TotalUnits,
                                   (SELECT COUNT(*) FROM units WHERE STATUS = 'Vacant') AS VacantUnits,
                                   (SELECT COALESCE(SUM(AMOUNT), 0) FROM payment
                                     WHERE STATUS = 'Completed'
                                       AND PAYMENT_DATE >= @monthStart
                                       AND PAYMENT_DATE <  @nextMonth) AS CollectedThisMonth,
                                   (SELECT COUNT(*) FROM v_billing
                                     WHERE STATUS IN ('Unpaid', 'Partially Paid')
                                       AND DUE_DATE >= CURDATE()
                                       AND DUE_DATE <= DATE_ADD(CURDATE(), INTERVAL 7 DAY)) AS BillsDueSoon,
                                   (SELECT COUNT(*) FROM lease
                                     WHERE STATUS = 'Active'
                                       AND END_DATE >= CURDATE()
                                       AND END_DATE <= DATE_ADD(CURDATE(), INTERVAL 30 DAY)) AS LeasesExpiring,
                                   (SELECT COUNT(*) FROM maintenance_request
                                     WHERE STATUS IN ('Open', 'In Progress')
                                       AND PRIORITY IN ('High', 'Urgent')) AS UrgentRepairs";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@monthStart", monthStart);
                    cmd.Parameters.AddWithValue("@nextMonth", monthStart.AddMonths(1));

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            statCardUnpaid.CardNumber = Peso0(reader["UnpaidBalance"]);
                            statCardExpired.CardNumber = reader["ExpiredLeases"].ToString();
                            statCardOverdue.CardNumber = reader["RentOverdue"].ToString();
                            statCardRepairs.CardNumber = reader["RepairsNeeded"].ToString();
                            statCardOccupancy.CardNumber = reader["OccupiedUnits"] + " / " + reader["TotalUnits"];
                            statCardVacant.CardNumber = reader["VacantUnits"].ToString();
                            statCardCollected.CardNumber = Peso0(reader["CollectedThisMonth"]);
                            statCardDueSoon.CardNumber = reader["BillsDueSoon"].ToString();
                            statCardExpiring.CardNumber = reader["LeasesExpiring"].ToString();
                            statCardUrgent.CardNumber = reader["UrgentRepairs"].ToString();
                        }
                    }
                }
            }
        }

        // The 5 overdue bills that have waited longest
        private void LoadOverdueBills()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                    CONCAT(r.FIRST_NAME, ' ', r.LAST_NAME) AS Tenant,
                                    u.UNIT_NO,
                                    b.BILL_TYPE,
                                    b.DUE_DATE,
                                    DATEDIFF(CURDATE(), b.DUE_DATE) AS DaysLate,
                                    b.BALANCE
                               FROM v_billing b
                               JOIN lease l ON l.LEASE_ID = b.LEASE_ID
                               JOIN resident r ON r.RESIDENT_ID = l.RESIDENT_ID
                               JOIN units u ON u.UNIT_ID = l.UNIT_ID
                               WHERE b.STATUS = 'Overdue'
                               ORDER BY b.DUE_DATE, b.BILLING_ID
                               LIMIT 5";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dgvOverdue.Rows.Clear();

                    while (reader.Read())
                    {
                        int daysLate = Convert.ToInt32(reader["DaysLate"]);

                        dgvOverdue.Rows.Add(
                            reader["Tenant"].ToString(),
                            reader["UNIT_NO"].ToString(),
                            reader["BILL_TYPE"].ToString(),
                            Convert.ToDateTime(reader["DUE_DATE"]).ToString("MMM dd, yyyy", CultureInfo.InvariantCulture),
                            daysLate + (daysLate == 1 ? " day" : " days"),
                            "₱" + Convert.ToDecimal(reader["BALANCE"]).ToString("N2", CultureInfo.InvariantCulture));
                    }
                }
            }

            dgvOverdue.ClearSelection();   // read-only overview: don't start with the first row highlighted
            dgvOverdue.Invalidate();       // redraw the empty-state message
        }

        // "No overdue bills" message drawn in the middle of an empty table
        private void DgvOverdue_Paint(object? sender, PaintEventArgs e)
        {
            if (dgvOverdue.Rows.Count > 0) return;

            var area = new Rectangle(0, dgvOverdue.ColumnHeadersHeight, dgvOverdue.ClientSize.Width,
                Math.Max(0, dgvOverdue.ClientSize.Height - dgvOverdue.ColumnHeadersHeight));
            using (var font = new Font("Century Gothic", 10F))
            {
                TextRenderer.DrawText(e.Graphics, "No overdue bills.", font, area, Color.FromArgb(125, 130, 134),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        // whole pesos on the cards
        private static string Peso0(object value) =>
            "₱" + Convert.ToDecimal(value).ToString("N0", CultureInfo.InvariantCulture);
    }
}