#nullable disable
using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.DataAccess;
using PMS_v1.Models.Responses;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PMS_v1.PopupForms.DetailForms
{
    /// <summary>
    /// One lease, read-only: the unit's photo, the tenant, the unit they live in, and the lease terms.
    /// The layout is in LeaseDetailForm.Designer.cs; this file fills it in.
    ///
    ///   using (var f = new LeaseDetailForm(leaseId))
    ///   {
    ///       if (!f.Found) return;          // the lease was deleted
    ///       f.ShowDialog(this.FindForm());
    ///   }
    /// </summary>
    public partial class LeaseDetailForm : Form
    {
        private readonly int leaseId;

        /// <summary>False when the lease no longer exists.</summary>
        public bool Found { get; private set; }

        public LeaseDetailForm(int leaseId)
        {
            InitializeComponent();
            this.leaseId = leaseId;
            FormClosed += (_, _) =>
            {
                if (picUnit.Image != null) picUnit.Image.Dispose();
            };
            Found = ShowLease();
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

        private void SetPhoto(byte[] bytes)
        {
            if (picUnit.Image != null)
            {
                picUnit.Image.Dispose();
                picUnit.Image = null;
            }

            if (bytes != null && bytes.Length > 0)
            {
                try
                {
                    using (var stream = new MemoryStream(bytes))
                    using (var loaded = Image.FromStream(stream))
                        picUnit.Image = new Bitmap(loaded);   // a copy, so the stream can close
                }
                catch (ArgumentException)
                {
                    picUnit.Image = null;   // the stored bytes are not a picture
                }
            }

            lblNoPhoto.Visible = picUnit.Image == null;
        }

        // ---------- View ----------
        private bool ShowLease()
        {
            byte[] photo = null;

            LeaseDetail d = new LeaseData().GetDetail(leaseId);
            if (d == null) return false;   // deleted by someone else

            Text = "Lease L-" + leaseId.ToString("D4");
            lblHeader.Text = Text;

            lblStatus.Text = d.Status;
            lblTenant.Text = PersonLine(d.ResidentFirstName, d.ResidentLastName, d.ResidentContactNo, "Not specified");
            lblUnit.Text = "Unit " + Str(d.UnitNo);
            lblFloor.Text = d.FloorNo.HasValue ? "Floor " + d.FloorNo.Value.ToString() : "—";
            lblUnitType.Text = Str(d.UnitType);
            lblStartDate.Text = Day(d.StartDate);
            lblEndDate.Text = Day(d.EndDate);
            lblMonthlyRent.Text = Peso.Format(d.MonthlyRent);
            lblDeposit.Text = Peso.Format(d.Deposit);
            lblRecordedBy.Text = PersonLine(d.RecorderFirstName, d.RecorderLastName, d.RecorderPosition, "Not specified");
            lblLastUpdated.Text = d.UpdatedAt
                .ToString("MMM dd, yyyy h:mm tt", CultureInfo.InvariantCulture);

            photo = d.Photo;   // null when the unit has no photo

            SetPhoto(photo);
            return true;
        }
    }
}