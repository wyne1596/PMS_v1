using System;
using System.Collections.Generic;
using System.Globalization;
using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.Models.Entities;
using PMS_v1.Models.Requests;
using PMS_v1.Models.Responses;

namespace PMS_v1.DataAccess
{
    // DATA ACCESS for bills and payments.
    // This class is the only place that talks to the database (runs the SQL) for the Billing page and the Bill window.
    // The page and the window call these methods instead of writing SQL themselves.
    // (Bill status, paid amount and balance are worked out from the payment rows by the v_billing view.)
    public class BillData
    {
        // One count per bill status; null only if the database returns no row.
        public BillStats? GetStats()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                   COUNT(CASE WHEN STATUS = 'Paid' THEN 1 END) AS Paid,
                                   COUNT(CASE WHEN STATUS = 'Partially Paid' THEN 1 END) AS PartiallyPaid,
                                   COUNT(CASE WHEN STATUS = 'Unpaid' THEN 1 END) AS Unpaid,
                                   COUNT(CASE WHEN STATUS = 'Overdue' THEN 1 END) AS Overdue,
                                   COUNT(CASE WHEN STATUS = 'Cancelled' THEN 1 END) AS Canceled
                               FROM v_billing";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.Read()) return null;

                    return new BillStats
                    {
                        Paid = Convert.ToInt32(reader["Paid"]),
                        PartiallyPaid = Convert.ToInt32(reader["PartiallyPaid"]),
                        Unpaid = Convert.ToInt32(reader["Unpaid"]),
                        Overdue = Convert.ToInt32(reader["Overdue"]),
                        Canceled = Convert.ToInt32(reader["Canceled"])
                    };
                }
            }
        }

        // Every bill for the table, latest due date first.
        public List<BillListItem> GetAll()
        {
            var list = new List<BillListItem>();

            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                    b.BILLING_ID,
                                    CONCAT(r.FIRST_NAME, ' ', r.LAST_NAME) AS Tenant,
                                    u.UNIT_NO,
                                    b.BILL_TYPE,
                                    b.DUE_DATE,
                                    b.AMOUNT,
                                    b.AMOUNT_PAID,
                                    b.BALANCE,
                                    b.LAST_PAYMENT_MODE,
                                    b.STATUS
                               FROM v_billing b
                               JOIN lease l ON l.LEASE_ID = b.LEASE_ID
                               JOIN resident r ON r.RESIDENT_ID = l.RESIDENT_ID
                               JOIN units u ON u.UNIT_ID = l.UNIT_ID
                               ORDER BY b.DUE_DATE DESC, b.BILLING_ID DESC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new BillListItem
                        {
                            BillingId = Convert.ToInt32(reader["BILLING_ID"]),
                            Tenant = reader["Tenant"].ToString() ?? string.Empty,
                            UnitNo = reader["UNIT_NO"].ToString() ?? string.Empty,
                            BillType = reader["BILL_TYPE"].ToString() ?? string.Empty,
                            DueDate = Convert.ToDateTime(reader["DUE_DATE"]),
                            Amount = Convert.ToDecimal(reader["AMOUNT"]),
                            AmountPaid = Convert.ToDecimal(reader["AMOUNT_PAID"]),
                            Balance = Convert.ToDecimal(reader["BALANCE"]),
                            LastPaymentMode = reader["LAST_PAYMENT_MODE"].ToString() ?? string.Empty,
                            Status = reader["STATUS"].ToString() ?? string.Empty
                        });
                    }
                }
            }

            return list;
        }

        // Everything the Bill window shows; null when the bill no longer exists.
        public BillDetail? GetDetail(int billingId)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                @"SELECT CONCAT(r.FIRST_NAME, ' ', r.LAST_NAME) AS Tenant, u.UNIT_NO,
                         b.BILL_TYPE, b.BILL_DATE, b.DUE_DATE, b.AMOUNT, b.AMOUNT_PAID, b.BALANCE,
                         b.LAST_PAYMENT_DATE, b.LAST_PAYMENT_MODE, b.LAST_REF_NO, b.STATUS
                  FROM v_billing b
                  JOIN lease l ON l.LEASE_ID = b.LEASE_ID
                  JOIN resident r ON r.RESIDENT_ID = l.RESIDENT_ID
                  JOIN units u ON u.UNIT_ID = l.UNIT_ID
                  WHERE b.BILLING_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", billingId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;

                    return new BillDetail
                    {
                        BillingId = billingId,
                        Tenant = Str(r["Tenant"]),
                        UnitNo = Str(r["UNIT_NO"]),
                        BillType = Str(r["BILL_TYPE"]),
                        Status = Str(r["STATUS"]),
                        BillDate = Convert.ToDateTime(r["BILL_DATE"]),
                        DueDate = Convert.ToDateTime(r["DUE_DATE"]),
                        Amount = Convert.ToDecimal(r["AMOUNT"]),
                        AmountPaid = Convert.ToDecimal(r["AMOUNT_PAID"]),
                        Balance = Convert.ToDecimal(r["BALANCE"]),
                        LastPaymentDate = r["LAST_PAYMENT_DATE"] is DateTime d ? d : (DateTime?)null,
                        LastPaymentMode = Str(r["LAST_PAYMENT_MODE"]),
                        LastRefNo = Str(r["LAST_REF_NO"])
                    };
                }
            }
        }

        // One bill for the Edit form; null when the bill no longer exists.
        public Bill? GetById(int billingId)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT LEASE_ID, BILL_TYPE, BILL_DATE, DUE_DATE, AMOUNT, AMOUNT_PAID, CANCELLED " +
                "FROM v_billing WHERE BILLING_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", billingId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return null;   // deleted by someone else

                    return new Bill
                    {
                        BillingId = billingId,
                        LeaseId = Convert.ToInt32(r["LEASE_ID"]),
                        BillType = Str(r["BILL_TYPE"]),
                        BillDate = Convert.ToDateTime(r["BILL_DATE"]),
                        DueDate = Convert.ToDateTime(r["DUE_DATE"]),
                        Amount = Convert.ToDecimal(r["AMOUNT"]),
                        AmountPaid = Convert.ToDecimal(r["AMOUNT_PAID"]),
                        Cancelled = Convert.ToInt32(r["CANCELLED"]) == 1
                    };
                }
            }
        }

        // The start date of a lease; null when the lease is not found.
        public DateTime? GetLeaseStartDate(int leaseId)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand("SELECT START_DATE FROM lease WHERE LEASE_ID = @lease", conn))
            {
                cmd.Parameters.AddWithValue("@lease", leaseId);
                conn.Open();
                object? start = cmd.ExecuteScalar();
                if (start == null || start is DBNull) return null;
                return Convert.ToDateTime(start);
            }
        }

        // How many active (not canceled) Rent bills a lease already has dated in the month starting at monthStart,
        // not counting the bill with id billingId (0 for a new bill).
        public int CountRentBillsInMonth(int leaseId, int billingId, DateTime monthStart)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM billing WHERE LEASE_ID = @lease AND BILL_TYPE = 'Rent' AND CANCELLED = 0 " +
                "AND BILLING_ID <> @id AND BILL_DATE >= @monthStart AND BILL_DATE < @nextMonth", conn))
            {
                cmd.Parameters.AddWithValue("@lease", leaseId);
                cmd.Parameters.AddWithValue("@id", billingId);
                cmd.Parameters.AddWithValue("@monthStart", monthStart);
                cmd.Parameters.AddWithValue("@nextMonth", monthStart.AddMonths(1));
                conn.Open();
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        // Adds a new bill.
        public void Create(CreateBillRequest request)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "INSERT INTO billing (LEASE_ID, BILL_TYPE, BILL_DATE, DUE_DATE, AMOUNT) " +
                "VALUES (@lease, @type, @billDate, @dueDate, @amount)", conn))
            {
                cmd.Parameters.AddWithValue("@lease", request.LeaseId);
                cmd.Parameters.AddWithValue("@type", request.BillType);
                cmd.Parameters.AddWithValue("@billDate", request.BillDate);
                cmd.Parameters.AddWithValue("@dueDate", request.DueDate);
                cmd.Parameters.AddWithValue("@amount", request.Amount);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Saves the edited bill.
        public void Update(int billingId, UpdateBillRequest request)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "UPDATE billing SET BILL_TYPE=@type, BILL_DATE=@billDate, DUE_DATE=@dueDate, " +
                "AMOUNT=@amount, CANCELLED=@cancelled WHERE BILLING_ID=@id", conn))
            {
                cmd.Parameters.AddWithValue("@type", request.BillType);
                cmd.Parameters.AddWithValue("@billDate", request.BillDate);
                cmd.Parameters.AddWithValue("@dueDate", request.DueDate);
                cmd.Parameters.AddWithValue("@amount", request.Amount);
                cmd.Parameters.AddWithValue("@cancelled", request.Cancelled ? 1 : 0);
                cmd.Parameters.AddWithValue("@id", billingId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // The bills that still have a balance left to pay (not canceled), oldest due date first.
        public List<PayableBill> GetPayableBills()
        {
            var list = new List<PayableBill>();

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                @"SELECT b.BILLING_ID,
                         CONCAT(r.FIRST_NAME, ' ', r.LAST_NAME) AS Tenant,
                         b.BALANCE,
                         b.BILL_DATE
                  FROM v_billing b
                  JOIN lease l ON l.LEASE_ID = b.LEASE_ID
                  JOIN resident r ON r.RESIDENT_ID = l.RESIDENT_ID
                  WHERE b.CANCELLED = 0 AND b.AMOUNT_PAID < b.AMOUNT
                  ORDER BY b.DUE_DATE, b.BILLING_ID", conn))
            {
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                    {
                        list.Add(new PayableBill
                        {
                            BillingId = Convert.ToInt32(r["BILLING_ID"]),
                            Tenant = r["Tenant"].ToString() ?? string.Empty,
                            Balance = Convert.ToDecimal(r["Balance"]),
                            BillDate = Convert.ToDateTime(r["BILL_DATE"]).Date
                        });
                    }
                }
            }

            return list;
        }

        // ---------- REFERENCE NO. ----------
        // Reference no. like BT-20261103-0001: mode code, payment date, running number.
        private static readonly Dictionary<string, string> ModeCode = new Dictionary<string, string>
        {
            ["Cash"] = "CS",
            ["Bank Transfer"] = "BT",
            ["E-Wallet"] = "EW",
            ["Check"] = "CK",
            ["Credit Card"] = "CC",
            ["Debit Card"] = "DC"
        };

        // The running number continues from the highest one already on a payment, so it keeps
        // counting up across all modes and dates. (REF_NO is unique, so a clash is rejected.)
        private static string NextReferenceNo(MySqlConnection conn, MySqlTransaction tx, string mode, DateTime paymentDate)
        {
            ModeCode.TryGetValue(mode, out var code);

            int next;
            using (var cmd = new MySqlCommand(
                @"SELECT COALESCE(MAX(CAST(SUBSTRING_INDEX(REF_NO, '-', -1) AS UNSIGNED)), 0) + 1
                  FROM payment
                  WHERE REF_NO REGEXP '^[A-Z]{2}-[0-9]{8}-[0-9]+$'", conn, tx))
            {
                next = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return (code ?? "PY") + "-" +
                   paymentDate.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + "-" +
                   next.ToString("D4");
        }

        // ---------- RECORD PAYMENT ----------
        // Each payment is saved as its own row in the payment table. The bill's paid amount,
        // balance and status are worked out from those rows by the v_billing view.
        // Returns the reference no. of the saved payment (the typed one, or the one created here).
        public string RecordPayment(RecordPaymentRequest request)
        {
            string? typedRef = request.RefNo;
            string refNo = typedRef ?? string.Empty;

            using (var conn = Db.GetConnection())
            {
                conn.Open();

                // A typed reference no. (bank or e-wallet transaction no.) is kept as it is.
                // A blank one is created here. Two people saving at the same moment can draw the
                // same number; the unique key rejects the second save, so draw a fresh one and retry.
                for (int attempt = 1; ; attempt++)
                {
                    using (var tx = conn.BeginTransaction())
                    {
                        try
                        {
                            // Lock the bill first, so two people paying it at once are handled one after the other.
                            using (var lockCmd = new MySqlCommand(
                                "SELECT BILLING_ID FROM billing WHERE BILLING_ID = @id FOR UPDATE", conn, tx))
                            {
                                lockCmd.Parameters.AddWithValue("@id", request.BillingId);
                                lockCmd.ExecuteScalar();
                            }

                            if (typedRef == null)
                                refNo = NextReferenceNo(conn, tx, request.Mode, request.PaymentDate);

                            using (var cmd = new MySqlCommand(
                                "INSERT INTO payment (BILLING_ID, AMOUNT, PAYMENT_DATE, PAYMENT_MODE, REF_NO, PERSONNEL_ID) " +
                                "VALUES (@id, @amount, @payDate, @mode, @refNo, @personnel)", conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@id", request.BillingId);
                                cmd.Parameters.AddWithValue("@amount", request.Amount);
                                cmd.Parameters.AddWithValue("@payDate", request.PaymentDate);
                                cmd.Parameters.AddWithValue("@mode", request.Mode);
                                cmd.Parameters.AddWithValue("@refNo", refNo);
                                cmd.Parameters.AddWithValue("@personnel", (object?)request.PersonnelId ?? DBNull.Value);
                                cmd.ExecuteNonQuery();
                            }

                            tx.Commit();
                            break;
                        }
                        catch (MySqlException ex) when (ex.Number == 1062 && typedRef == null && attempt < 3)
                        {
                            tx.Rollback();   // that number was just taken; the loop draws a fresh one
                        }
                    }
                }
            }

            return refNo;
        }

        private static string Str(object value)
        {
            return value == null || value is DBNull ? string.Empty : value.ToString() ?? string.Empty;
        }
    }
}
