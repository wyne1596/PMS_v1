using MySql.Data.MySqlClient;
using PMS_v1.Database;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    public partial class BillingModule : UserControl
    {
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
                    if (reader.Read())
                    {
                        statCardPaid.CardNumber = reader["Paid"].ToString();
                        statCardPartiallyPaid.CardNumber = reader["PartiallyPaid"].ToString();
                        statCardUnpaid.CardNumber = reader["Unpaid"].ToString();
                        statCardOverdue.CardNumber = reader["Overdue"].ToString();
                        statCardCanceled.CardNumber = reader["Canceled"].ToString();
                    }
                }
            }
        }

        private void statCardPartiallyPaid_Load(object sender, EventArgs e)
        {
        }

        // Load bills into the table
        private void LoadBills()
        {
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
                    dgvBills.Rows.Clear();

                    while (reader.Read())
                    {
                        string status = reader["STATUS"].ToString() ?? string.Empty;
                        string mode = reader["LAST_PAYMENT_MODE"].ToString() ?? string.Empty;

                        int rowIndex = dgvBills.Rows.Add(
                            "B-" + Convert.ToInt32(reader["BILLING_ID"]).ToString("D4"),
                            reader["Tenant"].ToString(),
                            reader["UNIT_NO"].ToString(),
                            reader["BILL_TYPE"].ToString(),
                            Convert.ToDateTime(reader["DUE_DATE"]).ToString("MMM dd, yyyy"),
                            "₱" + Convert.ToDecimal(reader["AMOUNT"]).ToString("N2", CultureInfo.InvariantCulture),
                            "₱" + Convert.ToDecimal(reader["AMOUNT_PAID"]).ToString("N2", CultureInfo.InvariantCulture),
                            "₱" + Convert.ToDecimal(reader["BALANCE"]).ToString("N2", CultureInfo.InvariantCulture),
                            mode.Length == 0 ? "-" : mode,
                            status == "Cancelled" ? "Canceled" : status);   // keep the page's "Canceled" spelling so the filter matches

                        dgvBills.Rows[rowIndex].Tag = Convert.ToInt32(reader["BILLING_ID"]);
                    }
                }
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

        private static string Peso(decimal value) =>
            "P" + value.ToString("N2", CultureInfo.InvariantCulture);

        // Dropdown items like "Maria Santos - Unit 101".
        // New bill: every active lease.  Edit: only the bill's own lease (read-only).
        private static List<ComboItem> LeaseItems(int? onlyLeaseId)
        {
            var items = new List<ComboItem>();
            string where = onlyLeaseId.HasValue ? "l.LEASE_ID = @lease" : "l.STATUS = 'Active'";

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                @"SELECT l.LEASE_ID,
                         CONCAT(r.FIRST_NAME, ' ', r.LAST_NAME, ' - Unit ', u.UNIT_NO) AS Label
                  FROM lease l
                  JOIN resident r ON r.RESIDENT_ID = l.RESIDENT_ID
                  JOIN units u ON u.UNIT_ID = l.UNIT_ID
                  WHERE " + where + @"
                  ORDER BY r.LAST_NAME, r.FIRST_NAME", conn))
            {
                if (onlyLeaseId.HasValue) cmd.Parameters.AddWithValue("@lease", onlyLeaseId.Value);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    while (r.Read())
                        items.Add(new ComboItem(Convert.ToInt32(r["LEASE_ID"]), r["Label"].ToString()));
                }
            }
            return items;
        }

        // ---------- CREATE ----------
        private void btnNewBill_Click(object sender, EventArgs e)
        {
            using (var f = new RecordForm(FormMode.New, "Bill", FormDefinitions.Bill()))
            {
                f.Validator = FormDefinitions.ValidateBill;
                f.SetOptions("lease", LeaseItems(null));
                if (f.ShowDialog(this.FindForm()) != DialogResult.OK) return;

                var v = f.Values;
                try
                {
                    using (var conn = Db.GetConnection())
                    using (var cmd = new MySqlCommand(
                        "INSERT INTO billing (LEASE_ID, BILL_TYPE, BILL_DATE, DUE_DATE, AMOUNT) " +
                        "VALUES (@lease, @type, @billDate, @dueDate, @amount)", conn))
                    {
                        cmd.Parameters.AddWithValue("@lease", v["lease"]);
                        cmd.Parameters.AddWithValue("@type", v["billType"]);
                        cmd.Parameters.AddWithValue("@billDate", v["billDate"]);
                        cmd.Parameters.AddWithValue("@dueDate", v["dueDate"]);
                        cmd.Parameters.AddWithValue("@amount", v["amount"]);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    Refresh_();
                }
                catch (MySqlException ex) when (ex.Number == 3819)   // CHECK on billing failed
                {
                    MessageBox.Show(this, "Check the amount and the dates, then try again.");
                }
            }
        }

        // ---------- UPDATE ----------
        private void mnuEdit_Click(object? sender, EventArgs e) => EditSelected();
        private void btnEditBill_Click(object? sender, EventArgs e) => EditSelected();

        private void EditSelected()
        {
            if (!RequireSelection(out int id)) return;

            int leaseId = 0;
            decimal paid = 0;
            Dictionary<string, object> current;
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT LEASE_ID, BILL_TYPE, BILL_DATE, DUE_DATE, AMOUNT, AMOUNT_PAID, CANCELLED " +
                "FROM v_billing WHERE BILLING_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) { Refresh_(); return; }   // deleted by someone else
                    leaseId = Convert.ToInt32(r["LEASE_ID"]);
                    paid = Convert.ToDecimal(r["AMOUNT_PAID"]);
                    current = new Dictionary<string, object>
                    {
                        ["lease"] = leaseId,
                        ["billType"] = r["BILL_TYPE"],
                        ["billDate"] = r["BILL_DATE"],
                        ["dueDate"] = r["DUE_DATE"],
                        ["amount"] = r["AMOUNT"],
                        ["cancelled"] = Convert.ToInt32(r["CANCELLED"]) == 1 ? "Yes" : "No"
                    };
                }
            }

            using (var f = new RecordForm(FormMode.Edit, "Bill", FormDefinitions.Bill(FormMode.Edit)))
            {
                f.Validator = x =>
                    FormDefinitions.ValidateBill(x)
                    ?? ((decimal)x["amount"] < paid
                            ? "The amount can't be less than the " + Peso(paid) + " already paid."
                            : null)
                    ?? ((string)x["cancelled"] == "Yes" && paid > 0
                            ? "A bill that already has payments can't be canceled."
                            : null);
                f.SetOptions("lease", LeaseItems(leaseId));
                f.SetValues(current);                       // DBNull values are skipped
                if (f.ShowDialog(this.FindForm()) != DialogResult.OK) return;

                var v = f.Values;
                try
                {
                    using (var conn = Db.GetConnection())
                    using (var cmd = new MySqlCommand(
                        "UPDATE billing SET BILL_TYPE=@type, BILL_DATE=@billDate, DUE_DATE=@dueDate, " +
                        "AMOUNT=@amount, CANCELLED=@cancelled WHERE BILLING_ID=@id", conn))
                    {
                        cmd.Parameters.AddWithValue("@type", v["billType"]);
                        cmd.Parameters.AddWithValue("@billDate", v["billDate"]);
                        cmd.Parameters.AddWithValue("@dueDate", v["dueDate"]);
                        cmd.Parameters.AddWithValue("@amount", v["amount"]);
                        cmd.Parameters.AddWithValue("@cancelled", (string)v["cancelled"] == "Yes" ? 1 : 0);
                        cmd.Parameters.AddWithValue("@id", id);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    Refresh_();
                }
                catch (MySqlException ex) when (ex.Number == 3819)   // CHECK on billing failed
                {
                    MessageBox.Show(this, "Check the amount and the dates, then try again.");
                }
                catch (MySqlException ex) when (ex.Number == 1644)   // the database refused it (trigger); its message says why
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
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
        private void mnuRecordPayment_Click(object? sender, EventArgs e) => btnRecordPayment_Click(sender, e);

        private void btnRecordPayment_Click(object? sender, EventArgs e)
        {
            var balances = new Dictionary<int, decimal>();
            var items = new List<ComboItem>();

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                @"SELECT b.BILLING_ID,
                         CONCAT(r.FIRST_NAME, ' ', r.LAST_NAME) AS Tenant,
                         b.BALANCE
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
                        int billingId = Convert.ToInt32(r["BILLING_ID"]);
                        decimal balance = Convert.ToDecimal(r["Balance"]);
                        balances[billingId] = balance;
                        items.Add(new ComboItem(billingId,
                            "B-" + billingId.ToString("D4") + " - " + r["Tenant"] + " - " + Peso(balance) + " left"));
                    }
                }
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
                        return "The amount is more than what's left on the bill (" + Peso(left) + ").";
                    return null;
                };

                if (f.ShowDialog(this.FindForm()) != DialogResult.OK) return;

                var v = f.Values;
                string? typedRef = v["refNo"] as string;   // blank = null, so the page creates one
                string refNo = typedRef ?? string.Empty;
                try
                {
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
                                        lockCmd.Parameters.AddWithValue("@id", v["bill"]);
                                        lockCmd.ExecuteScalar();
                                    }

                                    if (typedRef == null)
                                        refNo = NextReferenceNo(conn, tx, (string)v["mode"], (DateTime)v["paymentDate"]);

                                    using (var cmd = new MySqlCommand(
                                        "INSERT INTO payment (BILLING_ID, AMOUNT, PAYMENT_DATE, PAYMENT_MODE, REF_NO, PERSONNEL_ID) " +
                                        "VALUES (@id, @amount, @payDate, @mode, @refNo, @personnel)", conn, tx))
                                    {
                                        cmd.Parameters.AddWithValue("@id", v["bill"]);
                                        cmd.Parameters.AddWithValue("@amount", v["amount"]);
                                        cmd.Parameters.AddWithValue("@payDate", v["paymentDate"]);
                                        cmd.Parameters.AddWithValue("@mode", v["mode"]);
                                        cmd.Parameters.AddWithValue("@refNo", refNo);
                                        cmd.Parameters.AddWithValue("@personnel",
                                            PMS_v1.Helper.Session.PersonnelId > 0
                                                ? PMS_v1.Helper.Session.PersonnelId
                                                : (object)DBNull.Value);
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
                    Refresh_();
                    MessageBox.Show(this, "Payment recorded.\r\nReference no.: " + refNo, "Payment saved",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (MySqlException ex) when (ex.Number == 1062)   // REF_NO is unique
                {
                    MessageBox.Show(this, typedRef == null
                        ? "Couldn't create a reference number for this payment. Please try again."
                        : "That reference number has already been used.");
                }
                catch (MySqlException ex) when (ex.Number == 1644)   // the database refused it (trigger): more than the balance, or a canceled bill
                {
                    MessageBox.Show(this, ex.Message);
                }
            }
        }

        // ---------- PRINT ----------
        private void mnuPrintBill_Click(object? sender, EventArgs e) => PrintSelected();
        private void btnPrintBill_Click(object? sender, EventArgs e) => PrintSelected();

        private void PrintSelected()
        {
            if (!RequireSelection(out int id)) return;

            using (var f = new BillPrintForm(id))
            {
                if (!f.Found) { Refresh_(); return; }   // deleted by someone else
                f.ShowDialog(this.FindForm());
            }
        }
    }
}   