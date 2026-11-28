#nullable disable
using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.DataAccess;
using PMS_v1.Models.Responses;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace PMS_v1.PopupForms.DetailForms
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
    public partial class BillDetailForm : Form
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

        public BillDetailForm(int billingId)
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
            BillDetail detail = new BillData().GetDetail(billingId);
            if (detail == null) return null;

            string status = detail.Status;
            return new BillInfo
            {
                BillNo = "B-" + billingId.ToString("D4"),
                Tenant = detail.Tenant,
                Unit = detail.UnitNo,
                BillType = detail.BillType,
                Status = status == "Cancelled" ? "Canceled" : status,   // same spelling as the Billing page
                BillDate = detail.BillDate,
                DueDate = detail.DueDate,
                Amount = detail.Amount,
                Paid = detail.AmountPaid,
                Balance = detail.Balance,
                LastPayment = detail.LastPaymentDate,
                Mode = detail.LastPaymentMode,
                RefNo = detail.LastRefNo
            };
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

            lblAmount.Text = Peso.Format(bill.Amount);
            lblPaid.Text = Peso.Format(bill.Paid);
            lblBalance.Text = Peso.Format(bill.Balance);

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