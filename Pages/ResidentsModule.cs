using MySql.Data.MySqlClient;
using PMS_v1.Database;
using PMS_v1.ExceptionHandler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    public partial class ResidentsModule : UserControl
    {
        public ResidentsModule()
        {
            InitializeComponent();

            // staff can add and edit residents but not delete them
            btnDeleteResident.Visible = PMS_v1.Helper.Session.CanDelete;
            mnuDelete.Visible = PMS_v1.Helper.Session.CanDelete;

            PMS_v1.UserControls.ModulePageLayout.ApplyStandardLayout(
                tlpMain, pnlHeader, tlpMetrics, pnlActions, roundedPanelTable);
            PMS_v1.UserControls.ModulePageLayout.FitGridToRoundedPanel(roundedPanelTable, dgvResidents);
            ConfigureResidentsGrid();
            LayoutActionRow();

            pnlActions.Resize += (_, _) => LayoutActionRow();
            txtSearch.TextChanged += (_, _) => ApplyFilters();
            cmbFilter.SelectedIndexChanged += (_, _) => ApplyFilters();
            dgvResidents.CellPainting += DgvResidents_CellPainting;
            dgvResidents.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) EditSelected(); };
            dgvResidents.CellMouseDown += (_, e) =>
            {
                // right-click selects the row under the mouse so Edit/Delete act on it
                if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                    dgvResidents.CurrentCell = dgvResidents.Rows[e.RowIndex].Cells[0];
            };

            // Main caches its pages, so reload every time this page is shown (other pages change what it displays)
            VisibleChanged += (_, _) => { if (Visible && !DesignMode) Refresh_(); };
            LoadStats();
            LoadResidents();
        }

        // ---------- grid setup (same look as Billing) ----------
        private void ConfigureResidentsGrid()
        {
            cmbFilter.Items.AddRange(new object[] { "All Residents", "With Active Lease", "No Active Lease" });
            cmbFilter.SelectedIndex = 0;

            PMS_v1.UserControls.ModulePageLayout.ApplyStandardGridStyle(dgvResidents);

            AddColumn("Resident", "RESIDENT", 24);
            AddColumn("Contact", "CONTACT NO.", 16);
            AddColumn("Email", "EMAIL", 24);
            AddColumn("Birthdate", "BIRTHDATE", 14);
            AddColumn("Emergency", "EMERGENCY NO.", 16);
            AddColumn("Lease", "LEASE", 14, DataGridViewContentAlignment.MiddleCenter);
        }

        private void AddColumn(string name, string header, float weight,
            DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft)
        {
            dgvResidents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                FillWeight = weight,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = align }
            });
        }

        private void LayoutActionRow()
        {
            PMS_v1.UserControls.ActionRowLayout.PackRight(
                pnlActions, txtSearch, cmbFilter, btnEditResident, btnDeleteResident, btnNewResident);
        }

        // ---------- search / filter ----------
        private void ApplyFilters()
        {
            string search = txtSearch.Text.Trim();
            int filter = cmbFilter.SelectedIndex;   // 0 all, 1 with lease, 2 no lease

            PMS_v1.UserControls.GridHelper.Filter(dgvResidents, row =>
            {
                bool matchesSearch = string.IsNullOrEmpty(search) ||
                    PMS_v1.UserControls.GridHelper.Has(row, "Resident", search) ||
                    PMS_v1.UserControls.GridHelper.Has(row, "Contact", search) ||
                    PMS_v1.UserControls.GridHelper.Has(row, "Email", search) ||
                    PMS_v1.UserControls.GridHelper.Has(row, "Emergency", search);

                string lease = row.Cells["Lease"].Value?.ToString();
                bool matchesLease = filter <= 0 ||
                    (filter == 1 && lease == "Active") ||
                    (filter == 2 && lease == "None");

                return matchesSearch && matchesLease;
            });
        }

        // ---------- lease badge ----------
        private void DgvResidents_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            PMS_v1.UserControls.StatusBadge.Paint(dgvResidents, e, "Lease", s => s == "None" ? "No lease" : s);
        }

        // ---------- load ----------
        private void LoadStats()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                const string query = @"
                    SELECT
                        COUNT(*) AS Total,
                        (SELECT COUNT(DISTINCT RESIDENT_ID) FROM lease WHERE STATUS = 'Active') AS WithLease,
                        COALESCE(SUM(CREATED_AT >= DATE_FORMAT(CURDATE(), '%Y-%m-01')), 0) AS NewThisMonth
                    FROM resident";

                using (var cmd = new MySqlCommand(query, conn))
                using (var r = cmd.ExecuteReader())
                {
                    if (r.Read())
                    {
                        int total = Convert.ToInt32(r["Total"]);
                        int withLease = Convert.ToInt32(r["WithLease"]);
                        statCardTotal.CardNumber = total.ToString();
                        statCardWithLease.CardNumber = withLease.ToString();
                        statCardNoLease.CardNumber = Math.Max(0, total - withLease).ToString();
                        statCardNew.CardNumber = Convert.ToInt32(r["NewThisMonth"]).ToString();
                    }
                }
            }
        }

        private void LoadResidents()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();
                const string query = @"
                    SELECT r.RESIDENT_ID, r.FIRST_NAME, r.LAST_NAME, r.CONTACT_NO, r.EMAIL,
                           r.BIRTHDATE, r.EMERGENCY_CONTACT_NO,
                           EXISTS (SELECT 1 FROM lease l
                                   WHERE l.RESIDENT_ID = r.RESIDENT_ID AND l.STATUS = 'Active') AS HasLease
                    FROM resident r
                    ORDER BY r.LAST_NAME, r.FIRST_NAME";

                using (var cmd = new MySqlCommand(query, conn))
                using (var r = cmd.ExecuteReader())
                {
                    dgvResidents.Rows.Clear();
                    while (r.Read())
                    {
                        int index = dgvResidents.Rows.Add(
                            r["FIRST_NAME"] + " " + r["LAST_NAME"],
                            Show(r["CONTACT_NO"]),
                            Show(r["EMAIL"]),
                            r["BIRTHDATE"] is DateTime d ? d.ToString("MMM dd, yyyy") : "—",
                            Show(r["EMERGENCY_CONTACT_NO"]),
                            Convert.ToInt32(r["HasLease"]) == 1 ? "Active" : "None");

                        dgvResidents.Rows[index].Tag = Convert.ToInt32(r["RESIDENT_ID"]);
                    }
                }
            }
            ApplyFilters();
        }

        private static string Show(object value) =>
            value == null || value is DBNull || string.IsNullOrWhiteSpace(value.ToString()) ? "—" : value.ToString();

        // ---------- helpers ----------
        private int? SelectedId => dgvResidents.CurrentRow?.Tag as int?;

        private bool RequireSelection(out int id)
        {
            if (SelectedId is int value) { id = value; return true; }
            id = 0;
            MessageBox.Show(this, "Select a resident in the table first.", "No resident selected",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        private static void AddParams(MySqlCommand cmd, Dictionary<string, object> v)
        {
            // RecordForm returns null for blank optional fields; MySQL needs DBNull
            cmd.Parameters.AddWithValue("@first", v["firstName"]);
            cmd.Parameters.AddWithValue("@last", v["lastName"]);
            cmd.Parameters.AddWithValue("@contact", v["contact"] ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@email", v["email"] ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@birth", v["birthdate"] ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@emergency", v["emergencyContact"] ?? DBNull.Value);
        }

        private void Refresh_()
        {
            LoadStats();
            LoadResidents();
        }

        // ---------- CREATE ----------
        private void btnNewResident_Click(object sender, EventArgs e)
        {
            using (var f = new RecordForm(FormMode.New, "Resident", FormDefinitions.Resident()))
            {
                f.Validator = FormDefinitions.ValidateResident;
                if (f.ShowDialog(this.FindForm()) != DialogResult.OK) return;

                try
                {
                    using (var conn = Db.GetConnection())
                    using (var cmd = new MySqlCommand(
                        "INSERT INTO resident (FIRST_NAME, LAST_NAME, CONTACT_NO, EMAIL, BIRTHDATE, EMERGENCY_CONTACT_NO) " +
                        "VALUES (@first, @last, @contact, @email, @birth, @emergency)", conn))
                    {
                        AddParams(cmd, f.Values);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    Refresh_();
                }
                catch (Exception ex)
                {
                    ErrorHandler.Show(this, ex, ErrorRules.Resident);
                }
            }
        }

        // ---------- UPDATE ----------
        private void mnuEdit_Click(object? sender, EventArgs e) => EditSelected();
        private void btnEditResident_Click(object? sender, EventArgs e) => EditSelected();

        private void EditSelected()
        {
            if (!RequireSelection(out int id)) return;

            Dictionary<string, object> current;
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT FIRST_NAME, LAST_NAME, CONTACT_NO, EMAIL, BIRTHDATE, EMERGENCY_CONTACT_NO " +
                "FROM resident WHERE RESIDENT_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) { Refresh_(); return; }   // deleted by someone else
                    current = new Dictionary<string, object>
                    {
                        ["firstName"] = r["FIRST_NAME"],
                        ["lastName"] = r["LAST_NAME"],
                        ["contact"] = r["CONTACT_NO"],
                        ["email"] = r["EMAIL"],
                        ["birthdate"] = r["BIRTHDATE"],
                        ["emergencyContact"] = r["EMERGENCY_CONTACT_NO"]
                    };
                }
            }

            using (var f = new RecordForm(FormMode.Edit, "Resident", FormDefinitions.Resident()))
            {
                f.Validator = FormDefinitions.ValidateResident;
                f.SetValues(current);                       // DBNull values are skipped
                if (f.ShowDialog(this.FindForm()) != DialogResult.OK) return;

                try
                {
                    using (var conn = Db.GetConnection())
                    using (var cmd = new MySqlCommand(
                        "UPDATE resident SET FIRST_NAME=@first, LAST_NAME=@last, CONTACT_NO=@contact, " +
                        "EMAIL=@email, BIRTHDATE=@birth, EMERGENCY_CONTACT_NO=@emergency " +
                        "WHERE RESIDENT_ID=@id", conn))
                    {
                        AddParams(cmd, f.Values);
                        cmd.Parameters.AddWithValue("@id", id);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    Refresh_();
                }
                catch (Exception ex)
                {
                    ErrorHandler.Show(this, ex, ErrorRules.Resident);
                }
            }
        }

        // ---------- DELETE ----------
        private void mnuDelete_Click(object? sender, EventArgs e) => DeleteSelected();
        private void btnDeleteResident_Click(object? sender, EventArgs e) => DeleteSelected();

        private void DeleteSelected()
        {
            if (!PMS_v1.Helper.Session.CanDelete) return;
            if (!RequireSelection(out int id)) return;
            string name = dgvResidents.CurrentRow.Cells["Resident"].Value?.ToString() ?? "this resident";

            if (MessageBox.Show(this, "Delete " + name + "?", "Confirm delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes) return;

            try
            {
                using (var conn = Db.GetConnection())
                using (var cmd = new MySqlCommand("DELETE FROM resident WHERE RESIDENT_ID = @id", conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                Refresh_();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(this, ex, ErrorRules.ResidentDelete);
            }
        }
    }
}