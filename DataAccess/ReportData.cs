using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.Models.Responses;

namespace PMS_v1.DataAccess
{
    // DATA ACCESS for the Reports page.
    // This class is the only place that talks to the database (runs the SQL) for the Reports page.
    // The page calls this method instead of writing SQL itself.
    public class ReportData
    {
        // One row per completed payment dated from `from` (included) up to `to` (not included), newest first.
        // fullyPaidOnly: false = every payment on a bill (even if the bill is only partly paid);
        //                true  = only payments on bills that are now paid in full.
        public List<PaymentReportItem> GetPayments(DateTime from, DateTime to, bool fullyPaidOnly)
        {
            var rows = new List<PaymentReportItem>();

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                @"SELECT
                      p.BILLING_ID,
                      p.REF_NO,
                      CONCAT(r.FIRST_NAME, ' ', r.LAST_NAME) AS Tenant,
                      u.UNIT_NO,
                      p.PAYMENT_DATE,
                      p.PAYMENT_MODE,
                      p.AMOUNT AS PaidNow,
                      b.AMOUNT,
                      b.BALANCE,
                      b.STATUS
                  FROM payment p
                  JOIN v_billing b ON b.BILLING_ID = p.BILLING_ID
                  JOIN lease l ON l.LEASE_ID = b.LEASE_ID
                  JOIN resident r ON r.RESIDENT_ID = l.RESIDENT_ID
                  JOIN units u ON u.UNIT_ID = l.UNIT_ID
                  WHERE p.STATUS = 'Completed'
                    AND p.PAYMENT_DATE >= @from
                    AND p.PAYMENT_DATE <  @to" +
                    (fullyPaidOnly ? " AND b.AMOUNT_PAID >= b.AMOUNT" : "") + @"
                  ORDER BY p.PAYMENT_DATE DESC, p.PAYMENT_ID DESC", conn))
            {
                cmd.Parameters.AddWithValue("@from", from);
                cmd.Parameters.AddWithValue("@to", to);
                conn.Open();

                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        rows.Add(new PaymentReportItem
                        {
                            BillingId = Convert.ToInt32(r["BILLING_ID"]),
                            RefNo = r["REF_NO"]?.ToString() ?? string.Empty,
                            Tenant = r["Tenant"].ToString() ?? string.Empty,
                            UnitNo = r["UNIT_NO"].ToString() ?? string.Empty,
                            PaymentDate = Convert.ToDateTime(r["PAYMENT_DATE"]),
                            PaymentMode = r["PAYMENT_MODE"]?.ToString() ?? string.Empty,
                            BillAmount = Convert.ToDecimal(r["AMOUNT"]),
                            AmountPaid = Convert.ToDecimal(r["PaidNow"]),
                            Balance = Convert.ToDecimal(r["BALANCE"]),
                            Status = r["STATUS"].ToString() ?? string.Empty
                        });
                    }
                }
            }

            return rows;
        }
    }
}
