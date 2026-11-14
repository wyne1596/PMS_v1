using MySql.Data.MySqlClient;
using PMS_v1.Database;
using System;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    public partial class DashboardModule : UserControl
    {
        public DashboardModule()
        {
            InitializeComponent();
            PMS_v1.UserControls.ModulePageLayout.FitGridToRoundedPanel(roundedPanelTable, dgvRecent);

            LoadStats();
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