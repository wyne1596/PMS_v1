using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.Models.Responses;

namespace PMS_v1.DataAccess
{
    // DATA ACCESS for the Dashboard.
    // This class is the only place that talks to the database (runs the SQL) for the Dashboard page.
    // The page calls these methods instead of writing SQL itself.
    public class DashboardData
    {
        // The numbers for the stat cards (bill status is derived by the v_billing view); null only if the database returns no row.
        public DashboardStats? GetStats()
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
                        if (!reader.Read()) return null;

                        return new DashboardStats
                        {
                            UnpaidBalance = Convert.ToDecimal(reader["UnpaidBalance"]),
                            ExpiredLeases = Convert.ToInt32(reader["ExpiredLeases"]),
                            RentOverdue = Convert.ToInt32(reader["RentOverdue"]),
                            RepairsNeeded = Convert.ToInt32(reader["RepairsNeeded"]),
                            OccupiedUnits = Convert.ToInt32(reader["OccupiedUnits"]),
                            TotalUnits = Convert.ToInt32(reader["TotalUnits"]),
                            VacantUnits = Convert.ToInt32(reader["VacantUnits"]),
                            CollectedThisMonth = Convert.ToDecimal(reader["CollectedThisMonth"]),
                            BillsDueSoon = Convert.ToInt32(reader["BillsDueSoon"]),
                            LeasesExpiring = Convert.ToInt32(reader["LeasesExpiring"]),
                            UrgentRepairs = Convert.ToInt32(reader["UrgentRepairs"])
                        };
                    }
                }
            }
        }

        // The 5 overdue bills that have waited longest.
        public List<OverdueBillItem> GetOldestOverdueBills()
        {
            var list = new List<OverdueBillItem>();

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
                    while (reader.Read())
                    {
                        list.Add(new OverdueBillItem
                        {
                            Tenant = reader["Tenant"].ToString() ?? string.Empty,
                            UnitNo = reader["UNIT_NO"].ToString() ?? string.Empty,
                            BillType = reader["BILL_TYPE"].ToString() ?? string.Empty,
                            DueDate = Convert.ToDateTime(reader["DUE_DATE"]),
                            DaysLate = Convert.ToInt32(reader["DaysLate"]),
                            Balance = Convert.ToDecimal(reader["BALANCE"])
                        });
                    }
                }
            }

            return list;
        }
    }
}
