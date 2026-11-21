using MySql.Data.MySqlClient;
using PMS_v1.Database;
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

            LoadStats();
            LoadResidents();
        }

        // ---------- grid setup (same look as Billing) ----------
        private void ConfigureResidentsGrid()
        {
            cmbFilter.Items.AddRange(new object[] { "All Residents", "With Active Lease", "No Active Lease" });
            cmbFilter.SelectedIndex = 0;

            dgvResidents.AutoGenerateColumns = false;
            dgvResidents.AllowUserToAddRows = false;
            dgvResidents.AllowUserToDeleteRows = false;
            dgvResidents.AllowUserToResizeRows = false;
            dgvResidents.MultiSelect = false;
            dgvResidents.ReadOnly = true;
            dgvResidents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvResidents.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvResidents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvResidents.EnableHeadersVisualStyles = false;
            dgvResidents.RowTemplate.Height = 42;
            dgvResidents.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(74, 151, 196),
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(74, 151, 196),
                SelectionForeColor = Color.White
            };
            dgvResidents.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 49, 53),
                Font = new Font("Century Gothic", 9F),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 8, 0),
                SelectionBackColor = Color.FromArgb(232, 243, 250),   // light blue so the chosen row is visible
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };
            dgvResidents.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(232, 243, 250),
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };

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

            // a grid can't hide the row that holds the current cell
            dgvResidents.CurrentCell = null;

            foreach (DataGridViewRow row in dgvResidents.Rows)
            {
                bool matchesSearch = string.IsNullOrEmpty(search) ||
                    Has(row, "Resident", search) || Has(row, "Contact", search) ||
                    Has(row, "Email", search) || Has(row, "Emergency", search);

                string lease = row.Cells["Lease"].Value?.ToString();
                bool matchesLease = filter <= 0 ||
                    (filter == 1 && lease == "Active") ||
                    (filter == 2 && lease == "None");

                row.Visible = matchesSearch && matchesLease;
            }
        }

        private static bool Has(DataGridViewRow row, string column, string text) =>
            row.Cells[column].Value?.ToString()?.Contains(text, StringComparison.OrdinalIgnoreCase) == true;

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
                catch (MySqlException ex) when (ex.Number == 1062)
                {
                    MessageBox.Show(this, "That email is already used by another resident.");
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
                catch (MySqlException ex) when (ex.Number == 1062)
                {
                    MessageBox.Show(this, "That email is already used by another resident.");
                }
            }
        }

        // ---------- DELETE ----------
        private void mnuDelete_Click(object? sender, EventArgs e) => DeleteSelected();
        private void btnDeleteResident_Click(object? sender, EventArgs e) => DeleteSelected();

        private void DeleteSelected()
        {
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
            catch (MySqlException ex) when (ex.Number == 1451)
            {
                MessageBox.Show(this, "This resident has leases or other records and can't be deleted.");
            }
        }
    }
}