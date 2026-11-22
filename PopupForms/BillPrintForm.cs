#nullable disable
using MySql.Data.MySqlClient;
using PMS_v1.Database;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    /// <summary>
    /// Shows one bill the way it would look on paper. The layout is in
    /// BillPrintForm.Designer.cs, so it can be edited in the Visual Studio designer;
    /// this file only fills the labels.
    ///
    ///   using (var f = new BillPrintForm(billingId))
    ///   {
    ///       if (!f.Found) return;          // the bill was deleted
    ///       f.ShowDialog(this.FindForm());
    ///   }
    /// </summary>
    public partial class BillPrintForm : Form
    {
        private static readonly Color TextMuted = Color.FromArgb(120, 120, 120);

        private sealed class BillInfo
        {
            public string BillNo, Tenant, Unit, BillType, Status, Mode, RefNo;
            public DateTime BillDate, DueDate;
            public DateTime? LastPayment;
            public decimal Amount, Paid, Balance;
        }

        private readonly BillInfo bill;

        /// <summary>False when the bill no longer exists (nothing to show).</summary>
        public bool Found { get { return bill != null; } }

        public BillPrintForm(int billingId)
        {
            InitializeComponent();

            bill = LoadBill(billingId);
            if (bill == null) return;
            ShowBill();
        }

        // ---------- Data ----------
        private static string Str(object value)
        {
            return value == null || value is DBNull ? string.Empty : value.ToString();
        }

        private static BillInfo LoadBill(int billingId)
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

                    string status = Str(r["STATUS"]);
                    return new BillInfo
                    {
                        BillNo = "B-" + billingId.ToString("D4"),
                        Tenant = Str(r["Tenant"]),
                        Unit = Str(r["UNIT_NO"]),
                        BillType = Str(r["BILL_TYPE"]),
                        Status = status == "Cancelled" ? "Canceled" : status,   // same spelling as the Billing page
                        BillDate = Convert.ToDateTime(r["BILL_DATE"]),
                        DueDate = Convert.ToDateTime(r["DUE_DATE"]),
                        Amount = Convert.ToDecimal(r["AMOUNT"]),
                        Paid = Convert.ToDecimal(r["AMOUNT_PAID"]),
                        Balance = Convert.ToDecimal(r["BALANCE"]),
                        LastPayment = r["LAST_PAYMENT_DATE"] is DateTime d ? d : (DateTime?)null,
                        Mode = Str(r["LAST_PAYMENT_MODE"]),
                        RefNo = Str(r["LAST_REF_NO"])
                    };
                }
            }
        }

        // ---------- Fill the labels (positions, fonts and colors come from the designer) ----------
        private void ShowBill()
        {
            Text = "Bill " + bill.BillNo;
            lblHeader.Text = Text;

            lblTenant.Text = bill.Tenant;
            lblUnit.Text = bill.Unit;
            lblBillType.Text = bill.BillType;
            lblBillDate.Text = Day(bill.BillDate);
            lblDueDate.Text = Day(bill.DueDate);

            lblAmount.Text = Php(bill.Amount);
            lblPaid.Text = Php(bill.Paid);
            lblBalance.Text = Php(bill.Balance);

            lblStatus.Text = bill.Status;
            lblStatus.ForeColor = StatusColor(bill.Status);   // the only color that depends on the data

            if (bill.LastPayment.HasValue)
            {
                string mode = bill.Mode.Length > 0 ? " - " + bill.Mode : string.Empty;
                lblLastPayment.Text = Day(bill.LastPayment.Value) + mode;
            }
            else
            {
                lblLastPayment.Text = "None yet";
            }
            lblRefNo.Text = bill.RefNo.Length > 0 ? bill.RefNo : "-";
        }

        private static string Php(decimal value)
        {
            return "₱ " + value.ToString("N2", CultureInfo.InvariantCulture);
        }

        private static string Day(DateTime value)
        {
            return value.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture);
        }

        private static Color StatusColor(string status)
        {
            switch (status)
            {
                case "Paid": return Color.FromArgb(46, 125, 50);
                case "Partially Paid": return Color.FromArgb(191, 100, 0);
                case "Overdue": return Color.FromArgb(198, 40, 40);
                default: return TextMuted;   // Unpaid, Canceled
            }
        }
    }
}
