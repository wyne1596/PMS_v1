using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.DataAccess;
using PMS_v1.Models.Entities;
using PMS_v1.Models.Requests;
using PMS_v1.Models.Responses;
using PMS_v1.PopupForms.DetailForms;
using PMS_v1.ExceptionHandler;
using PMS_v1.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace PMS_v1.Pages.Content.Billing
{
    public partial class BillingModule : UserControl
    {
        private readonly BillData _billData = new BillData();

        // Columns the search box looks through
        private static readonly string[] SearchColumns =
            { "Bill", "Tenant", "Unit", "BillType", "Due", "Mode", "Status" };

        public BillingModule()
        {
            InitializeComponent();
            PMS_v1.UserControls.ModulePageLayout.ApplyStandardLayout(
                tlpMain, pnlHeader, tlpMetrics, pnlActions, roundedPanelTable);
            PMS_v1.UserControls.ModulePageLayout.FitGridToRoundedPanel(roundedPanelTable, dgvBills);
            ConfigureBillingGrid();
            LayoutActionRow();

            pnlActions.Resize += (_, _) => LayoutActionRow();
            txtSearch.TextChanged += (_, _) => ApplyBillFilters();
            cmbFilter.SelectedIndexChanged += (_, _) => ApplyBillFilters();
            dgvBills.CellPainting += DgvBills_CellPainting;
            dgvBills.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) EditSelected(); };
            dgvBills.CellMouseDown += (_, e) =>
            {
                // right-click selects the row under the mouse so the menu acts on it
                if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                    dgvBills.CurrentCell = dgvBills.Rows[e.RowIndex].Cells[0];
            };
            ctxRow.Opening += (_, e) =>
            {
                if (SelectedId == null) { e.Cancel = true; return; }   // nothing under the mouse

                // nothing left to collect on a paid or canceled bill
                string status = dgvBills.CurrentRow?.Cells["Status"].Value?.ToString() ?? string.Empty;
                mnuRecordPayment.Enabled = status != "Paid" && status != "Canceled";
            };
            // Main caches its pages, so reload every time this page is shown (other pages change what it displays)
            VisibleChanged += (_, _) => { if (Visible && !DesignMode) Refresh_(); };
            LoadStats();
            LoadBills();
        }

        private void ConfigureBillingGrid()
        {
            cmbFilter.Items.AddRange(new object[]
            {
                "All Statuses", "Paid", "Partially Paid", "Unpaid", "Overdue", "Canceled"
            });
            cmbFilter.SelectedIndex = 0;

            PMS_v1.UserControls.ModulePageLayout.ApplyStandardGridStyle(dgvBills);

            var centered = DataGridViewContentAlignment.MiddleCenter;
            var right = DataGridViewContentAlignment.MiddleRight;

            AddBillColumn("Bill", "BILL", 10);
            AddBillColumn("Tenant", "TENANT", 20);
            AddBillColumn("Unit", "UNIT", 7, centered, new Padding(4, 0, 4, 0));
            AddBillColumn("BillType", "BILL TYPE", 12);
            AddBillColumn("Due", "DUE", 12, centered, new Padding(8, 0, 14, 0));
            AddBillColumn("Amount", "AMOUNT", 11, right, new Padding(8, 0, 14, 0));
            AddBillColumn("Paid", "PAID", 10, right, new Padding(8, 0, 14, 0));
            AddBillColumn("Balance", "BALANCE", 11, right, new Padding(8, 0, 14, 0));
            AddBillColumn("Mode", "MODE", 12);
            AddBillColumn("Status", "STATUS", 14, centered, new Padding(4, 0, 4, 0));
        }

        private void AddBillColumn(string name, string header, float fillWeight,
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

            dgvBills.Columns.Add(column);
        }

        private void LayoutActionRow()
        {
            PMS_v1.UserControls.ActionRowLayout.PackRight(
                pnlActions, txtSearch, cmbFilter, btnEditBill, btnViewBill, btnRecordPayment, btnNewBill);
        }

        private void ApplyBillFilters()
        {
            string searchText = txtSearch.Text.Trim();
            string selectedStatus = cmbFilter.SelectedIndex <= 0 ? string.Empty : cmbFilter.Text;

            PMS_v1.UserControls.GridHelper.Filter(dgvBills, row =>
            {
                bool matchesSearch = string.IsNullOrEmpty(searchText) ||
                    Array.Exists(SearchColumns, column => PMS_v1.UserControls.GridHelper.Has(row, column, searchText));
                bool matchesStatus = string.IsNullOrEmpty(selectedStatus) ||
                    string.Equals(row.Cells["Status"].Value?.ToString(), selectedStatus, StringComparison.OrdinalIgnoreCase);
                return matchesSearch && matchesStatus;
            });
        }

        private void DgvBills_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            PMS_v1.UserControls.StatusBadge.Paint(dgvBills, e, "Status");
        }

        // Load statcards (status is derived by the v_billing view)
        private void LoadStats()
        {
            BillStats? stats = _billData.GetStats();

            if (stats != null)
            {
                statCardPaid.CardNumber = stats.Paid.ToString();
                statCardPartiallyPaid.CardNumber = stats.PartiallyPaid.ToString();
                statCardUnpaid.CardNumber = stats.Unpaid.ToString();
                statCardOverdue.CardNumber = stats.Overdue.ToString();
                statCardCanceled.CardNumber = stats.Canceled.ToString();
            }
        }

        // Load bills into the table
        private void LoadBills()
        {
            List<BillListItem> bills = _billData.GetAll();

            dgvBills.Rows.Clear();

            foreach (BillListItem bill in bills)
            {
                string status = bill.Status;
                string mode = bill.LastPaymentMode;

                int rowIndex = dgvBills.Rows.Add(
                    "B-" + bill.BillingId.ToString("D4"),
                    bill.Tenant,
                    bill.UnitNo,
                    bill.BillType,
                    bill.DueDate.ToString("MMM dd, yyyy"),
                    Peso.Format(bill.Amount),
                    Peso.Format(bill.AmountPaid),
                    Peso.Format(bill.Balance),
                    mode.Length == 0 ? "-" : mode,
                    status == "Cancelled" ? "Canceled" : status);   // keep the page's "Canceled" spelling so the filter matches

                dgvBills.Rows[rowIndex].Tag = bill.BillingId;
            }

            ApplyBillFilters();
        }

        // ---------- helpers ----------
        private int? SelectedId => dgvBills.CurrentRow?.Tag as int?;

        private bool RequireSelection(out int id)
        {
            if (SelectedId is int value) { id = value; return true; }
            id = 0;
            MessageBox.Show(this, "Select a bill in the table first.", "No bill selected",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        private void Refresh_()
        {
            LoadStats();
            LoadBills();
        }

        // A Rent bill always shows the unit's base rent and can't be edited; the other bill types stay editable.
        // fillNow = false (Edit) keeps the bill's saved amount until the lease or the bill type is changed.
        private static void WireRentAmount(RecordForm f, bool fillNow)
        {
            void Apply(bool fill)
            {
                bool rent = (f.GetValue("billType") as string) == "Rent";
                f.SetLocked("amount", rent);
                if (rent && fill)
                    f.SetValue("amount", LookupData.BaseRentOfLease((int?)f.GetValue("lease")));
            }

            f.OnChoiceChanged("lease", () => Apply(true));
            f.OnChoiceChanged("billType", () => Apply(true));
            Apply(fillNow);
        }

        // The checks for a bill that need the database; they run when Save is pressed, so a problem keeps the form open.
        // billingId is 0 for a new bill. A bill that is being canceled is not checked.
        private static string? CheckBillAgainstLease(Dictionary<string, object> v, int billingId)
        {
            if (v.ContainsKey("cancelled") && (string)v["cancelled"] == "Yes") return null;
            if (!(v["lease"] is int leaseId)) return null;

            var billDate = (DateTime)v["billDate"];

            return new BillService().CheckBillAgainstLease(leaseId, (string)v["billType"], billDate, billingId);
        }

        // ---------- CREATE ----------
        private void btnNewBill_Click(object sender, EventArgs e)
        {
            using (var f = new RecordForm(FormMode.New, "Bill", FormDefinitions.Bill()))
            {
                f.Validator = x => FormDefinitions.ValidateBill(x) ?? CheckBillAgainstLease(x, 0);
                f.SetOptions("lease", LookupData.LeaseChoices(null));
                WireRentAmount(f, fillNow: true);   // a Rent bill shows the unit's base rent, locked
                if (f.ShowDialog(this.FindForm()) != DialogResult.OK) return;

                var v = f.Values;
                try
                {
                    _billData.Create(new CreateBillRequest
                    {
                        LeaseId = (int)v["lease"],
                        BillType = (string)v["billType"],
                        BillDate = (DateTime)v["billDate"],
                        DueDate = (DateTime)v["dueDate"],
                        Amount = (decimal)v["amount"]
                    });
                    Refresh_();
                }
                catch (Exception ex)
                {
                    ErrorHandler.Show(this, ex, ErrorRules.Bill);
                }
            }
        }

        // ---------- UPDATE ----------
        private void mnuEdit_Click(object? sender, EventArgs e) => EditSelected();
        private void btnEditBill_Click(object? sender, EventArgs e) => EditSelected();

        private void EditSelected()
        {
            if (!RequireSelection(out int id)) return;

            Bill? bill = _billData.GetById(id);
            if (bill == null) { Refresh_(); return; }   // deleted by someone else

            int leaseId = bill.LeaseId;
            decimal paid = bill.AmountPaid;
            Dictionary<string, object> current = new Dictionary<string, object>
            {
                ["lease"] = leaseId,
                ["billType"] = bill.BillType,
                ["billDate"] = bill.BillDate,
                ["dueDate"] = bill.DueDate,
                ["amount"] = bill.Amount,
                ["cancelled"] = bill.Cancelled ? "Yes" : "No"
            };

            using (var f = new RecordForm(FormMode.Edit, "Bill", FormDefinitions.Bill(FormMode.Edit)))
            {
                f.Validator = x =>
                    FormDefinitions.ValidateBill(x)
                    ?? ((decimal)x["amount"] < paid
                            ? "The amount can't be less than the " + Peso.Format(paid) + " already paid."
                            : null)
                    ?? ((string)x["cancelled"] == "Yes" && paid > 0
                            ? "A bill that already has payments can't be canceled."
                            : null)
                    ?? CheckBillAgainstLease(x, id);
                f.SetOptions("lease", LookupData.LeaseChoices(leaseId));
                f.SetValues(current);                       // DBNull values are skipped
                WireRentAmount(f, fillNow: false);          // a Rent bill's amount is locked
                if (f.ShowDialog(this.FindForm()) != DialogResult.OK) return;

                var v = f.Values;
                try
                {
                    _billData.Update(id, new UpdateBillRequest
                    {
                        BillType = (string)v["billType"],
                        BillDate = (DateTime)v["billDate"],
                        DueDate = (DateTime)v["dueDate"],
                        Amount = (decimal)v["amount"],
                        Cancelled = (string)v["cancelled"] == "Yes"
                    });
                    Refresh_();
                }
                catch (Exception ex)
                {
                    ErrorHandler.Show(this, ex, ErrorRules.Bill);
                }
            }
        }

        // (The reference no. is created in BillData.RecordPayment, in the DataAccess folder.)

        // ---------- RECORD PAYMENT ----------
        // Each payment is saved as its own row in the payment table. The bill's paid amount,
        // balance and status are worked out from those rows by the v_billing view.
        private void mnuRecordPayment_Click(object? sender, EventArgs e) => btnRecordPayment_Click(sender, e);

        private void btnRecordPayment_Click(object? sender, EventArgs e)
        {
            var balances = new Dictionary<int, decimal>();
            var billDates = new Dictionary<int, DateTime>();
            var items = new List<ComboItem>();

            foreach (PayableBill payable in _billData.GetPayableBills())
            {
                int billingId = payable.BillingId;
                decimal balance = payable.Balance;
                balances[billingId] = balance;
                billDates[billingId] = payable.BillDate;
                items.Add(new ComboItem(billingId,
                    "B-" + billingId.ToString("D4") + " - " + payable.Tenant + " - " + Peso.Format(balance) + " left"));
            }

            if (items.Count == 0)
            {
                MessageBox.Show(this, "There are no bills with a balance left to pay.", "Nothing to pay",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (var f = new RecordForm(FormMode.New, "Payment", FormDefinitions.Payment()))
            {
                f.SetOptions("bill", items);

                // start on the selected bill, with its full balance filled in
                if (SelectedId is int selected && balances.TryGetValue(selected, out decimal selectedBalance))
                {
                    f.SetValue("bill", selected);
                    f.SetValue("amount", selectedBalance);
                }

                f.Validator = x =>
                {
                    if (x["bill"] is int chosen && balances.TryGetValue(chosen, out decimal left)
                        && (decimal)x["amount"] > left)
                        return "The amount is more than what's left on the bill (" + Peso.Format(left) + ").";

                    var payDate = (DateTime)x["paymentDate"];
                    if (payDate > DateTime.Today)
                        return "Payment date can't be in the future.";
                    if (x["bill"] is int billChosen && billDates.TryGetValue(billChosen, out DateTime billDate)
                        && payDate < billDate)
                        return "Payment date can't be before the bill date.";
                    return null;
                };

                if (f.ShowDialog(this.FindForm()) != DialogResult.OK) return;

                var v = f.Values;
                string? typedRef = v["refNo"] as string;   // blank = null, so the page creates one
                string refNo = typedRef ?? string.Empty;
                try
                {
                    refNo = _billData.RecordPayment(new RecordPaymentRequest
                    {
                        BillingId = (int)v["bill"],
                        Amount = (decimal)v["amount"],
                        PaymentDate = (DateTime)v["paymentDate"],
                        Mode = (string)v["mode"],
                        RefNo = typedRef,
                        PersonnelId = PMS_v1.Helper.Session.PersonnelId > 0 ? PMS_v1.Helper.Session.PersonnelId : null
                    });
                    Refresh_();
                    MessageBox.Show(this, "Payment recorded.\r\nReference no.: " + refNo, "Payment saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    ErrorHandler.Show(this, ex, ErrorRules.Payment(typedRef != null));
                }
            }
        }

        private void mnuViewBill_Click(object? sender, EventArgs e) => ViewSelected();
        private void btnViewBill_Click(object? sender, EventArgs e) => ViewSelected();

        private void ViewSelected()
        {
            if (!RequireSelection(out int id)) return;

            using (var f = new BillDetailForm(id))
            {
                if (!f.Found) { Refresh_(); return; }   // deleted by someone else
                f.ShowDialog(this.FindForm());
            }
        }
    }
}