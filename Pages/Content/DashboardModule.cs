using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using PMS_v1.Data;
using PMS_v1.DataAccess;
using PMS_v1.ExceptionHandler;
using PMS_v1.Helper;
using PMS_v1.Models.Responses;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace PMS_v1.Pages.Content.Dashboard
{
    public partial class DashboardModule : UserControl
    {
        private readonly DashboardData _dashboardData = new DashboardData();

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
            DashboardStats? stats = _dashboardData.GetStats();

            if (stats != null)
            {
                statCardUnpaid.CardNumber = Peso.Whole(stats.UnpaidBalance);
                statCardExpired.CardNumber = stats.ExpiredLeases.ToString();
                statCardOverdue.CardNumber = stats.RentOverdue.ToString();
                statCardRepairs.CardNumber = stats.RepairsNeeded.ToString();
                statCardOccupancy.CardNumber = stats.OccupiedUnits + " / " + stats.TotalUnits;
                statCardVacant.CardNumber = stats.VacantUnits.ToString();
                statCardCollected.CardNumber = Peso.Whole(stats.CollectedThisMonth);
                statCardDueSoon.CardNumber = stats.BillsDueSoon.ToString();
                statCardExpiring.CardNumber = stats.LeasesExpiring.ToString();
                statCardUrgent.CardNumber = stats.UrgentRepairs.ToString();
            }
        }

        // The 5 overdue bills that have waited longest
        private void LoadOverdueBills()
        {
            List<OverdueBillItem> bills = _dashboardData.GetOldestOverdueBills();

            dgvOverdue.Rows.Clear();

            foreach (OverdueBillItem bill in bills)
            {
                int daysLate = bill.DaysLate;

                dgvOverdue.Rows.Add(
                    bill.Tenant,
                    bill.UnitNo,
                    bill.BillType,
                    bill.DueDate.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture),
                    daysLate + (daysLate == 1 ? " day" : " days"),
                    Peso.Format(bill.Balance));
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
    }
}