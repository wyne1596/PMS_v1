#nullable disable
using MySql.Data.MySqlClient;
using PMS_v1.Database;
using PMS_v1.ExceptionHandler;
using PMS_v1.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    /// <summary>
    /// One unit: photo, status, details and, if occupied, the current tenant.
    /// The layout is in UnitDetailForm.Designer.cs; this file fills it in.
    /// Everyone can view. Only an admin (Session.IsAdmin) sees the edit buttons.
    ///
    ///   using (var f = new UnitDetailForm(unitId))
    ///   {
    ///       if (!f.Found) return;          // the unit was deleted
    ///       f.ShowDialog(this.FindForm());
    ///       if (f.Changed) { /* reload the table */ }
    ///   }
    /// </summary>
    public partial class UnitDetailForm : Form
    {
        // photos are shrunk to fit this box before they are saved, to keep the database small
        private const int MaxPhotoWidth = 1024;
        private const int MaxPhotoHeight = 768;

        private readonly int unitId;

        /// <summary>False when the unit no longer exists.</summary>
        public bool Found { get; private set; }

        /// <summary>True when an admin edited the unit's details, so the table should reload.</summary>
        public bool Changed { get; private set; }

        public UnitDetailForm(int unitId)
        {
            InitializeComponent();
            this.unitId = unitId;

            // only an admin can change anything
            bool admin = Session.IsAdmin;
            btnEditDetails.Visible = admin;
            btnChangePhoto.Visible = admin;
            btnRemovePhoto.Visible = admin;

            FormClosed += (_, _) =>
            {
                if (picUnit.Image != null) picUnit.Image.Dispose();
            };

            Found = ShowUnit();
        }

        // ---------- helpers ----------
        private static string Str(object value)
        {
            return value == null || value is DBNull ? string.Empty : value.ToString();
        }

        private static string Day(DateTime value)
        {
            return value.ToString("MMM dd, yyyy", CultureInfo.InvariantCulture);
        }

        // ---------- View ----------
        private bool ShowUnit()
        {
            string unitNo = "", floor = "", type = "", status = "";
            decimal rent = 0;
            byte[] photo = null;
            int openRequests = 0;

            // current tenant (null = nobody has an active lease on this unit)
            string tenant = null, contact = "-", period = "-", leaseRent = "-", deposit = "-";

            using (var conn = Db.GetConnection())
            {
                conn.Open();

                using (var cmd = new MySqlCommand(
                    "SELECT UNIT_NO, FLOOR_NO, UNIT_TYPE, BASE_RENT, STATUS, PHOTO FROM units WHERE UNIT_ID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", unitId);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (!r.Read()) return false;
                        unitNo = Str(r["UNIT_NO"]);
                        floor = Str(r["FLOOR_NO"]);
                        type = Str(r["UNIT_TYPE"]);
                        rent = Convert.ToDecimal(r["BASE_RENT"]);
                        status = Str(r["STATUS"]);
                        photo = r["PHOTO"] as byte[];   // null when the unit has no photo
                    }
                }

                using (var cmd = new MySqlCommand(
                    @"SELECT CONCAT(r.FIRST_NAME, ' ', r.LAST_NAME) AS Tenant, r.CONTACT_NO,
                             l.START_DATE, l.END_DATE, l.MONTHLY_RENT, l.DEPOSIT
                      FROM lease l
                      JOIN resident r ON r.RESIDENT_ID = l.RESIDENT_ID
                      WHERE l.UNIT_ID = @id AND l.STATUS = 'Active'
                      ORDER BY l.START_DATE DESC
                      LIMIT 1", conn))
                {
                    cmd.Parameters.AddWithValue("@id", unitId);
                    using (var r = cmd.ExecuteReader())
                    {
                        if (r.Read())
                        {
                            tenant = Str(r["Tenant"]);
                            contact = Str(r["CONTACT_NO"]);
                            if (contact.Length == 0) contact = "-";
                            period = Day(Convert.ToDateTime(r["START_DATE"])) + " to " + Day(Convert.ToDateTime(r["END_DATE"]));
                            leaseRent = Peso.Format(Convert.ToDecimal(r["MONTHLY_RENT"]));
                            deposit = Peso.Format(Convert.ToDecimal(r["DEPOSIT"]));
                        }
                    }
                }

                using (var cmd = new MySqlCommand(
                    "SELECT COUNT(*) FROM maintenance_request WHERE UNIT_ID = @id AND STATUS IN ('Open', 'In Progress')", conn))
                {
                    cmd.Parameters.AddWithValue("@id", unitId);
                    openRequests = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            Text = "Unit " + unitNo;
            lblHeader.Text = Text;

            lblUnitNo.Text = unitNo;
            lblFloor.Text = floor.Length > 0 ? floor : "-";
            lblType.Text = type;
            lblBaseRent.Text = Peso.Format(rent);
            lblOpenRequests.Text = openRequests == 0 ? "None" : openRequests.ToString(CultureInfo.InvariantCulture);

            ShowStatus(status);

            if (tenant == null)
            {
                tenant = status == "Vacant" ? "None (vacant)"
                       : status == "Under Maintenance" ? "None (under maintenance)"
                       : "No active lease found";
            }
            lblTenant.Text = tenant;
            lblContact.Text = contact;
            lblLeasePeriod.Text = period;
            lblLeaseRent.Text = leaseRent;
            lblDeposit.Text = deposit;

            SetPhoto(photo);
            return true;
        }

        private void ShowStatus(string status)
        {
            lblStatusBadge.Text = status;

            switch (status)
            {
                case "Vacant":
                    lblStatusBadge.BackColor = Color.FromArgb(232, 245, 233);
                    lblStatusBadge.ForeColor = Color.FromArgb(46, 125, 50);
                    break;
                case "Occupied":
                    lblStatusBadge.BackColor = Color.FromArgb(227, 242, 253);
                    lblStatusBadge.ForeColor = Color.FromArgb(21, 101, 192);
                    break;
                default:   // Under Maintenance
                    lblStatusBadge.BackColor = Color.FromArgb(255, 243, 224);
                    lblStatusBadge.ForeColor = Color.FromArgb(191, 100, 0);
                    break;
            }
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
                using (var stream = new MemoryStream(bytes))
                using (var loaded = Image.FromStream(stream))
                {
                    picUnit.Image = new Bitmap(loaded);   // a copy, so the stream can close
                }
            }

            lblNoPhoto.Visible = picUnit.Image == null;
            btnRemovePhoto.Visible = Session.IsAdmin && picUnit.Image != null;
        }

        // ---------- Edit details (admin only) ----------
        private void btnEditDetails_Click(object sender, EventArgs e)
        {
            if (!Session.IsAdmin) return;

            if (EditUnit(this, unitId))
            {
                Changed = true;
                ShowUnit();
            }
        }

        /// <summary>
        /// Opens the shared Edit form for a unit and saves it. Returns true when saved.
        /// Used by this form and by the Units page's Edit button.
        /// </summary>
        public static bool EditUnit(IWin32Window owner, int unitId)
        {
            if (!Session.IsAdmin) return false;

            string unitNo, type, status;
            int? floor = null;
            decimal rent;

            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT UNIT_NO, FLOOR_NO, UNIT_TYPE, BASE_RENT, STATUS FROM units WHERE UNIT_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", unitId);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) return false;   // deleted by someone else
                    unitNo = Str(r["UNIT_NO"]);
                    if (!(r["FLOOR_NO"] is DBNull)) floor = Convert.ToInt32(r["FLOOR_NO"]);
                    type = Str(r["UNIT_TYPE"]);
                    rent = Convert.ToDecimal(r["BASE_RENT"]);
                    status = Str(r["STATUS"]);
                }
            }

            var current = new Dictionary<string, object>
            {
                ["unitNo"] = unitNo,
                ["furnishing"] = type,
                ["baseRent"] = rent,
                ["status"] = status
            };
            if (floor.HasValue) current["floor"] = (decimal)floor.Value;

            // an occupied unit's status is set by its lease, so the form locks it
            using (var f = new RecordForm(FormMode.Edit, "Unit", FormDefinitions.Unit(status == "Occupied")))
            {
                f.Validator = FormDefinitions.ValidateUnit;
                f.SetValues(current);
                if (f.ShowDialog(owner) != DialogResult.OK) return false;

                var v = f.Values;
                try
                {
                    using (var conn = Db.GetConnection())
                    using (var cmd = new MySqlCommand(
                        "UPDATE units SET UNIT_NO = @unitNo, FLOOR_NO = @floor, UNIT_TYPE = @type, " +
                        "BASE_RENT = @rent, STATUS = @status WHERE UNIT_ID = @id", conn))
                    {
                        cmd.Parameters.AddWithValue("@unitNo", v["unitNo"]);
                        cmd.Parameters.AddWithValue("@floor", Convert.ToInt32(v["floor"]));
                        cmd.Parameters.AddWithValue("@type", v["furnishing"]);
                        cmd.Parameters.AddWithValue("@rent", v["baseRent"]);
                        cmd.Parameters.AddWithValue("@status", v["status"]);
                        cmd.Parameters.AddWithValue("@id", unitId);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    ErrorHandler.Show(owner, ex, ErrorRules.Unit);
                    return false;
                }
            }
        }

        // ---------- Photo (admin only) ----------
        private void btnChangePhoto_Click(object sender, EventArgs e)
        {
            if (!Session.IsAdmin) return;

            using (var dialog = new OpenFileDialog
            {
                Title = "Choose a photo of the unit",
                Filter = "Pictures (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp"
            })
            {
                if (dialog.ShowDialog(this) != DialogResult.OK) return;

                byte[] bytes;
                try
                {
                    bytes = ToSmallJpeg(dialog.FileName);
                }
                catch (Exception)
                {
                    ErrorHandler.ShowInvalidPicture(this);
                    return;
                }

                SavePhoto(bytes);
            }
        }

        private void btnRemovePhoto_Click(object sender, EventArgs e)
        {
            if (!Session.IsAdmin) return;

            if (MessageBox.Show(this, "Remove this unit's photo?", "Remove photo",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                SavePhoto(null);
        }

        // null = remove the photo
        private void SavePhoto(byte[] bytes)
        {
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand("UPDATE units SET PHOTO = @photo WHERE UNIT_ID = @id", conn))
            {
                cmd.Parameters.Add("@photo", MySqlDbType.MediumBlob).Value = (object)bytes ?? DBNull.Value;
                cmd.Parameters.AddWithValue("@id", unitId);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

            SetPhoto(bytes);
        }

        // Shrinks the picture to fit MaxPhotoWidth x MaxPhotoHeight and saves it as a JPEG.
        private static byte[] ToSmallJpeg(string path)
        {
            using (var source = Image.FromFile(path))
            {
                double scale = Math.Min(1.0, Math.Min(
                    MaxPhotoWidth / (double)source.Width,
                    MaxPhotoHeight / (double)source.Height));
                int width = Math.Max(1, (int)(source.Width * scale));
                int height = Math.Max(1, (int)(source.Height * scale));

                using (var small = new Bitmap(width, height))
                {
                    using (var g = Graphics.FromImage(small))
                    {
                        g.Clear(Color.White);   // a PNG's see-through parts become white, not black
                        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                        g.DrawImage(source, 0, 0, width, height);
                    }

                    using (var stream = new MemoryStream())
                    {
                        small.Save(stream, ImageFormat.Jpeg);
                        return stream.ToArray();
                    }
                }
            }
        }
    }
}