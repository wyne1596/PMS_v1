using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.DataAccess;
using PMS_v1.ExceptionHandler;
using PMS_v1.Models.Responses;
using PMS_v1.UserControls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace PMS_v1.Pages.Content.Reports
{
    /// <summary>
    /// Reports page: recent payments on bills, filtered by Today / This Week / This Month / This Year.
    ///
    /// One row per payment received on a bill (payment table), dated by PAYMENT_DATE. A bill paid in
    /// two installments shows twice; BALANCE and STATUS are the bill's current ones (v_billing).
    /// </summary>
    public partial class ReportsModule : UserControl
    {
        private readonly ReportData _reportData = new ReportData();

        // Order matters: RangeFor() switches on the index.
        private static readonly string[] PeriodNames =
            { "Today", "This Week", "This Month", "This Year", "All Time" };

        private const int DefaultPeriodIndex = 2;   // This Month

        // false: every payment on a bill (even if the bill is only partly paid)
        // true : only payments on bills that are now paid in full
        private const bool FullyPaidOnly = false;

        // Columns the search box looks through
        private static readonly string[] SearchColumns =
            { "Reference", "Bill", "Tenant", "Unit", "PaidOn", "Mode", "Status" };

        // Raw values kept on each grid row (Tag) so CSV export doesn't have to parse formatted text.
        private sealed record ReportRow(
            int BillingId, string Reference, string Tenant, string Unit, DateTime PaidOn,
            string Mode, decimal Amount, decimal Paid, decimal Balance, string Status);

        public ReportsModule()
        {
            InitializeComponent();
            ModulePageLayout.ApplyStandardLayout(
                tlpMain, pnlHeader, tlpMetrics, pnlActions, roundedPanelTable);
            ModulePageLayout.FitGridToRoundedPanel(roundedPanelTable, dgvReport);
            ConfigureStatCards();
            ConfigureReportGrid();
            LayoutActionRow();

            pnlActions.Resize += (_, _) => LayoutActionRow();
            txtSearch.TextChanged += (_, _) => ApplySearch();
            cmbPeriod.SelectedIndexChanged += (_, _) => LoadReport();
            dgvReport.CellPainting += (_, e) => StatusBadge.Paint(dgvReport, e, "Status");
            dgvReport.Paint += DgvReport_Paint;

            // Main caches its pages, so reload every time Reports is shown; a payment recorded
            // on the Billing page then shows up here without restarting the app.
            VisibleChanged += (_, _) => { if (Visible && !DesignMode) LoadReport(); };
        }

        // ---------- setup ----------
        private void ConfigureStatCards()
        {
            statCardCollected.CardCaption = "Total Collected";
            statCardCollected.CardNumber = Peso.Whole(0m);

            statCardBills.CardCaption = "Payments";
            statCardBills.CardNumber = "0";

            statCardOutstanding.CardCaption = "Still Owed";
            statCardOutstanding.CardNumber = Peso.Whole(0m);

            statCardAverage.CardCaption = "Avg. Payment";
            statCardAverage.CardNumber = Peso.Whole(0m);
        }

        private void ConfigureReportGrid()
        {
            cmbPeriod.Items.AddRange(PeriodNames);
            cmbPeriod.SelectedIndex = DefaultPeriodIndex;   // set before the handler is attached, so no load yet

            ModulePageLayout.ApplyStandardGridStyle(dgvReport);

            var centered = DataGridViewContentAlignment.MiddleCenter;
            var right = DataGridViewContentAlignment.MiddleRight;

            AddColumn("Reference", "REFERENCE", 15);
            AddColumn("Bill", "BILL", 8, centered, new Padding(4, 0, 4, 0));
            AddColumn("Tenant", "TENANT", 18);
            AddColumn("Unit", "UNIT", 7, centered, new Padding(4, 0, 4, 0));
            AddColumn("PaidOn", "PAID ON", 12, centered, new Padding(8, 0, 14, 0));
            AddColumn("Mode", "MODE", 12);
            AddColumn("Amount", "BILL AMOUNT", 11, right, new Padding(8, 0, 14, 0));
            AddColumn("Paid", "AMOUNT PAID", 11, right, new Padding(8, 0, 14, 0));
            AddColumn("Balance", "BALANCE", 10, right, new Padding(8, 0, 14, 0));
            AddColumn("Status", "STATUS", 13, centered, new Padding(4, 0, 4, 0));
        }

        private void AddColumn(string name, string header, float fillWeight,
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

            dgvReport.Columns.Add(column);
        }

        private void LayoutActionRow()
        {
            ActionRowLayout.PackRight(pnlActions, txtSearch, cmbPeriod);
        }

        // ---------- period filter ----------

        /// <summary>The [from, to) range of payment dates for a dropdown choice.</summary>
        private static (DateTime From, DateTime To) RangeFor(int periodIndex, DateTime today)
        {
            switch (periodIndex)
            {
                case 0:   // Today
                    return (today, today.AddDays(1));

                case 1:   // This Week: starts on the computer's first day of the week (Sunday or Monday)
                    DayOfWeek first = CultureInfo.CurrentCulture.DateTimeFormat.FirstDayOfWeek;
                    int back = (7 + (int)today.DayOfWeek - (int)first) % 7;
                    DateTime weekStart = today.AddDays(-back);
                    return (weekStart, weekStart.AddDays(7));

                case 2:   // This Month
                    var monthStart = new DateTime(today.Year, today.Month, 1);
                    return (monthStart, monthStart.AddMonths(1));

                case 3:   // This Year
                    var yearStart = new DateTime(today.Year, 1, 1);
                    return (yearStart, yearStart.AddYears(1));

                default:  // All Time
                    return (new DateTime(1900, 1, 1), today.AddDays(1));
            }
        }

        private static string DescribeRange(int periodIndex, DateTime from, DateTime to)
        {
            DateTime last = to.AddDays(-1);
            if (periodIndex == 0) return last.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture);
            if (periodIndex == 4) return "All payments to date";

            return from.Year == last.Year
                ? from.ToString("MMM dd", CultureInfo.InvariantCulture) + " – " +
                  last.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture)
                : from.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture) + " – " +
                  last.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture);
        }

        // ---------- load ----------
        private void LoadReport()
        {
            int period = cmbPeriod.SelectedIndex < 0 ? DefaultPeriodIndex : cmbPeriod.SelectedIndex;
            var (from, to) = RangeFor(period, DateTime.Today);
            lblRange.Text = DescribeRange(period, from, to);

            var rows = new List<ReportRow>();
            try
            {
                foreach (PaymentReportItem payment in _reportData.GetPayments(from, to, FullyPaidOnly))
                {
                    string reference = payment.RefNo;
                    string mode = payment.PaymentMode;

                    rows.Add(new ReportRow(
                        payment.BillingId,
                        reference.Length == 0 ? "-" : reference,
                        payment.Tenant,
                        payment.UnitNo,
                        payment.PaymentDate,
                        mode.Length == 0 ? "-" : mode,
                        payment.BillAmount,
                        payment.AmountPaid,
                        payment.Balance,
                        payment.Status));
                }
            }
            catch (MySqlException)
            {
                ErrorHandler.ShowLoadError(this, "report", "Reports");
                return;
            }

            FillGrid(rows);
            UpdateStats(rows);
            ApplySearch();
        }

        private void FillGrid(List<ReportRow> rows)
        {
            dgvReport.Rows.Clear();
            foreach (var row in rows)
            {
                int index = dgvReport.Rows.Add(
                    row.Reference,
                    "B-" + row.BillingId.ToString("D4"),
                    row.Tenant,
                    row.Unit,
                    row.PaidOn.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture),
                    row.Mode,
                    Peso.Format(row.Amount),
                    Peso.Format(row.Paid),
                    Peso.Format(row.Balance),
                    row.Status);

                dgvReport.Rows[index].Tag = row;
            }
        }

        // The cards describe the chosen period; the search box only narrows the table.
        private void UpdateStats(List<ReportRow> rows)
        {
            decimal collected = 0, owed = 0;
            var billsSeen = new HashSet<int>();
            foreach (var row in rows)
            {
                collected += row.Paid;
                if (billsSeen.Add(row.BillingId))   // a bill paid twice in this period is counted once
                    owed += row.Balance;
            }

            statCardCollected.CardNumber = Peso.Whole(collected);
            statCardBills.CardNumber = rows.Count.ToString(CultureInfo.InvariantCulture);
            statCardOutstanding.CardNumber = Peso.Whole(owed);
            statCardAverage.CardNumber = Peso.Whole(rows.Count == 0 ? 0 : collected / rows.Count);
        }

        private void ApplySearch()
        {
            string text = txtSearch.Text.Trim();
            GridHelper.Filter(dgvReport, row =>
                string.IsNullOrEmpty(text) ||
                Array.Exists(SearchColumns, column => GridHelper.Has(row, column, text)));
            dgvReport.Invalidate();   // redraw the empty-state message if the search hid every row
        }

        // "No results" message drawn in the middle of an empty table
        private void DgvReport_Paint(object? sender, PaintEventArgs e)
        {
            if (dgvReport.Rows.GetRowCount(DataGridViewElementStates.Visible) > 0) return;

            string message = dgvReport.Rows.Count == 0
                ? "No payments for this period."
                : "No bills match your search.";

            var area = new Rectangle(0, dgvReport.ColumnHeadersHeight, dgvReport.ClientSize.Width,
                Math.Max(0, dgvReport.ClientSize.Height - dgvReport.ColumnHeadersHeight));
            using (var font = new Font("Century Gothic", 10F))
            {
                TextRenderer.DrawText(e.Graphics, message, font, area, Color.FromArgb(125, 130, 134),
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
        }

        // ---------- export ----------
        /*private void btnExport_Click(object? sender, EventArgs e)
        {
            var visible = new List<ReportRow>();
            foreach (DataGridViewRow row in dgvReport.Rows)
                if (row.Visible && row.Tag is ReportRow data)
                    visible.Add(data);

            if (visible.Count == 0)
            {
                MessageBox.Show(this, "There's nothing to export for this period.", "Export CSV",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string period = PeriodNames[Math.Max(0, cmbPeriod.SelectedIndex)].Replace(' ', '-').ToLowerInvariant();
            using (var dialog = new SaveFileDialog
            {
                Title = "Export rent payments",
                Filter = "CSV file (*.csv)|*.csv",
                FileName = "rent-payments-" + period + "-" + DateTime.Today.ToString("yyyyMMdd", CultureInfo.InvariantCulture) + ".csv"
            })
            {
                if (dialog.ShowDialog(this.FindForm()) != DialogResult.OK) return;

                var csv = new StringBuilder();
                csv.AppendLine("Reference,Bill,Tenant,Unit,Paid On,Mode,Bill Amount,Amount Paid,Balance,Status");
                foreach (var r in visible)
                {
                    csv.AppendLine(string.Join(",",
                        Csv(r.Reference),
                        Csv("B-" + r.BillingId.ToString("D4")),
                        Csv(r.Tenant),
                        Csv(r.Unit),
                        r.PaidOn.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                        Csv(r.Mode),
                        r.Amount.ToString("0.00", CultureInfo.InvariantCulture),
                        r.Paid.ToString("0.00", CultureInfo.InvariantCulture),
                        r.Balance.ToString("0.00", CultureInfo.InvariantCulture),
                        Csv(r.Status)));
                }

                try
                {
                    // UTF-8 with a BOM so Excel reads names with accents correctly
                    File.WriteAllText(dialog.FileName, csv.ToString(), new UTF8Encoding(true));
                    MessageBox.Show(this, "Exported " + visible.Count + " bill(s).", "Export CSV",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (IOException)
                {
                    MessageBox.Show(this, "The file couldn't be saved. If it's open in another program, close it and try again.",
                        "Export CSV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                catch (UnauthorizedAccessException)
                {
                    MessageBox.Show(this, "You don't have permission to save there. Choose another folder.",
                        "Export CSV", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // ---------- helpers ----------
        private static string Csv(string value) =>
            value.IndexOfAny(new[] { ',', '"', '\r', '\n' }) >= 0
                ? "\"" + value.Replace("\"", "\"\"") + "\""
                : value;*/

    }
}