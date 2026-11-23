#nullable disable
using MySql.Data.MySqlClient;
using PMS_v1.Database;
using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PMS_v1.Pages
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

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT l.LEASE_ID, l.START_DATE, l.END_DATE, l.MONTHLY_RENT, l.DEPOSIT, l.STATUS, l.UPDATED_AT, " +
                "       r.FIRST_NAME AS R_FIRST, r.LAST_NAME AS R_LAST, r.CONTACT_NO AS R_CONTACT, " +
                "       u.UNIT_NO, u.FLOOR_NO, u.UNIT_TYPE, u.PHOTO, " +
                "       p.FIRST_NAME AS P_FIRST, p.LAST_NAME AS P_LAST, p.POSITION AS P_POSITION " +
                "FROM lease l " +
                "LEFT JOIN resident r ON r.RESIDENT_ID = l.RESIDENT_ID " +
                "LEFT JOIN units u ON u.UNIT_ID = l.UNIT_ID " +
                "LEFT JOIN personnel p ON p.EMPLOYEE_NO = l.EMPLOYEE_NO " +
                "WHERE l.LEASE_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", leaseId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return false;   // deleted by someone else

                    Text = "Lease L-" + leaseId.ToString("D4");
                    lblHeader.Text = Text;

                    lblStatus.Text = Str(r["STATUS"]);
                    lblTenant.Text = PersonLine(r["R_FIRST"], r["R_LAST"], r["R_CONTACT"], "Not specified");
                    lblUnit.Text = "Unit " + Str(r["UNIT_NO"]);
                    lblFloor.Text = r["FLOOR_NO"] is DBNull ? "—" : "Floor " + Str(r["FLOOR_NO"]);
                    lblUnitType.Text = Str(r["UNIT_TYPE"]);
                    lblStartDate.Text = Day(r["START_DATE"]);
                    lblEndDate.Text = Day(r["END_DATE"]);
                    lblMonthlyRent.Text = Peso.Format(Convert.ToDecimal(r["MONTHLY_RENT"]));
                    lblDeposit.Text = Peso.Format(Convert.ToDecimal(r["DEPOSIT"]));
                    lblRecordedBy.Text = PersonLine(r["P_FIRST"], r["P_LAST"], r["P_POSITION"], "Not specified");
                    lblLastUpdated.Text = Convert.ToDateTime(r["UPDATED_AT"])
                        .ToString("MMM dd, yyyy h:mm tt", CultureInfo.InvariantCulture);

                    photo = r["PHOTO"] as byte[];   // null when the unit has no photo
                }
            }

            SetPhoto(photo);
            return true;
        }
    }
}