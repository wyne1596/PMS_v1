#nullable disable
using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.DataAccess;
using PMS_v1.Models.Responses;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace PMS_v1.PopupForms.DetailForms
{
    /// <summary>
    /// One maintenance request, read-only: progress, who reported it, who is working on it,
    /// and the other details.
    /// The layout is in MaintenanceDetailForm.Designer.cs; this file fills it in.
    ///
    ///   using (var f = new MaintenanceDetailForm(reportId))
    ///   {
    ///       if (!f.Found) return;          // the request was deleted
    ///       f.ShowDialog(this.FindForm());
    ///   }
    /// </summary>
    public partial class MaintenanceDetailForm : Form
    {
        private readonly int reportId;
        private readonly MaintenanceData _maintenanceData = new MaintenanceData();

        /// <summary>False when the request no longer exists.</summary>
        public bool Found { get; private set; }

        public MaintenanceDetailForm(int reportId)
        {
            InitializeComponent();
            this.reportId = reportId;
            Found = ShowRequest();
        }

        // ---------- helpers ----------
        private static string Str(object value)
        {
            return value == null || value is DBNull ? string.Empty : value.ToString();
        }

        private static string Day(object value)
        {
            if (value == null || value is DBNull) return "—";
            return Convert.ToDateTime(value).ToString("MMM dd, yyyy", CultureInfo.InvariantCulture);
        }

        // "Maria Santos (09170000101)" / "Wyne Ben (Administrator)"; blank extra is left out
        private static string PersonLine(object first, object last, object extra, string whenMissing)
        {
            if (first == null || first is DBNull) return whenMissing;
            string name = (Str(first) + " " + Str(last)).Trim();
            string more = Str(extra);
            return more.Length == 0 ? name : name + " (" + more + ")";
        }

        // ---------- View ----------
        private bool ShowRequest()
        {
            MaintenanceDetail d = _maintenanceData.GetDetail(reportId);
            if (d == null) return false;   // deleted by someone else

            Text = "Request R-" + reportId.ToString("D4");
            lblHeader.Text = Text;
            statusTracker.Status = d.Status;

            lblUnit.Text = d.UnitNo == null ? "Common area" : "Unit " + d.UnitNo;
            lblReportedBy.Text = PersonLine(d.ReporterFirstName, d.ReporterLastName, d.ReporterContactNo, "Not specified");
            lblAssignedTo.Text = PersonLine(d.TechnicianFirstName, d.TechnicianLastName, d.TechnicianPosition, "Not yet assigned");
            lblType.Text = d.MaintenanceType;
            lblPriority.Text = d.Priority;
            lblDateReported.Text = Day(d.DateReported);
            lblDateCompleted.Text = Day(d.DateCompleted);
            lblCost.Text = Peso.Format(d.Cost);
            lblLastUpdated.Text = d.UpdatedAt
                .ToString("MMM dd, yyyy h:mm tt", CultureInfo.InvariantCulture);
            lblProblem.Text = d.Problem;

            string repairDetails = d.RepairDetails ?? string.Empty;
            lblRepairDetails.Text = repairDetails.Length == 0 ? "No repair notes yet." : repairDetails;
            return true;
        }
    }
}