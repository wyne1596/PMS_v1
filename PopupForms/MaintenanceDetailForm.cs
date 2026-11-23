#nullable disable
using MySql.Data.MySqlClient;
using PMS_v1.Database;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace PMS_v1.Pages
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
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT m.REPORT_ID, u.UNIT_NO, " +
                "       r.FIRST_NAME AS R_FIRST, r.LAST_NAME AS R_LAST, r.CONTACT_NO AS R_CONTACT, " +
                "       p.FIRST_NAME AS P_FIRST, p.LAST_NAME AS P_LAST, p.POSITION AS P_POSITION, " +
                "       m.PROBLEM, m.MAINTENANCE_TYPE, m.PRIORITY, m.STATUS, m.DATE_REPORTED, " +
                "       m.DATE_COMPLETED, m.COST, m.REPAIR_DETAILS, m.UPDATED_AT " +
                "FROM maintenance_request m " +
                "LEFT JOIN units u ON u.UNIT_ID = m.UNIT_ID " +
                "LEFT JOIN resident r ON r.RESIDENT_ID = m.RESIDENT_ID " +
                "LEFT JOIN personnel p ON p.PERSONNEL_ID = m.PERSONNEL_ID " +
                "WHERE m.REPORT_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", reportId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return false;   // deleted by someone else

                    Text = "Request R-" + reportId.ToString("D4");
                    lblHeader.Text = Text;
                    statusTracker.Status = Str(r["STATUS"]);

                    lblUnit.Text = r["UNIT_NO"] is DBNull ? "Common area" : "Unit " + Str(r["UNIT_NO"]);
                    lblReportedBy.Text = PersonLine(r["R_FIRST"], r["R_LAST"], r["R_CONTACT"], "Not specified");
                    lblAssignedTo.Text = PersonLine(r["P_FIRST"], r["P_LAST"], r["P_POSITION"], "Not yet assigned");
                    lblType.Text = Str(r["MAINTENANCE_TYPE"]);
                    lblPriority.Text = Str(r["PRIORITY"]);
                    lblDateReported.Text = Day(r["DATE_REPORTED"]);
                    lblDateCompleted.Text = Day(r["DATE_COMPLETED"]);
                    lblCost.Text = Peso.Format(Convert.ToDecimal(r["COST"]));
                    lblLastUpdated.Text = Convert.ToDateTime(r["UPDATED_AT"])
                        .ToString("MMM dd, yyyy h:mm tt", CultureInfo.InvariantCulture);
                    lblProblem.Text = Str(r["PROBLEM"]);

                    string repairDetails = Str(r["REPAIR_DETAILS"]);
                    lblRepairDetails.Text = repairDetails.Length == 0 ? "No repair notes yet." : repairDetails;
                }
            }
            return true;
        }
    }
}