using MySql.Data.MySqlClient;
using PMS_v1.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace PMS_v1.Pages
{
    public partial class LeasingModule : UserControl
    {
        public LeasingModule()
        {
            InitializeComponent();
            PMS_v1.UserControls.ModulePageLayout.ApplyStandardLayout(
                tlpMainSkeleton, pnlHeaderBlock, tlpMetricsRow, pnlCommandActionRow, roundedPanelTable);
            PMS_v1.UserControls.ModulePageLayout.FitGridToRoundedPanel(roundedPanelTable, dgvLeases);
            ConfigureLeaseGrid();
            PMS_v1.UserControls.GridHelper.ShowSelection(dgvLeases);
            mnuEdit.Visible = CanEdit;   // staff can view, only admins and managers can edit
            btnEditLease.Visible = CanEdit;
            LayoutCommandActionRow();
            pnlCommandActionRow.Resize += (_, _) => LayoutCommandActionRow();
            dgvLeases.CellPainting += DgvLeases_CellPainting;
            dgvLeases.CellMouseDown += (_, e) =>
            {
                // right-click selects the row under the mouse so the menu acts on it
                if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                    dgvLeases.CurrentCell = dgvLeases.Rows[e.RowIndex].Cells[0];
            };
            ctxRow.Opening += (_, e) =>
            {
                if (SelectedId == null) { e.Cancel = true; return; }   // nothing under the mouse
            };
            txtSearchInput.TextChanged += (_, _) => ApplyLeaseFilters();
            cmbFilterDropdown.SelectedIndexChanged += (_, _) => ApplyLeaseFilters();
            LoadStats();
            LoadLease();
        }

        private void LeasingModule_Load(object sender, EventArgs e)
        {

        }
        private void btnNewLease_Click(object sender, EventArgs e)
        {

        }

        private void ConfigureLeaseGrid()
        {
            cmbFilterDropdown.Items.AddRange(new object[] { "All Statuses", "Active", "Pending", "Expired", "Terminated" });
            cmbFilterDropdown.SelectedIndex = 0;
            btnNewLease.Values.Text = "＋  New Lease";

            dgvLeases.AutoGenerateColumns = false;
            dgvLeases.AllowUserToAddRows = false;
            dgvLeases.AllowUserToDeleteRows = false;
            dgvLeases.AllowUserToResizeRows = false;
            dgvLeases.MultiSelect = false;
            dgvLeases.ReadOnly = true;
            dgvLeases.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeases.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLeases.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvLeases.EnableHeadersVisualStyles = false;
            dgvLeases.RowTemplate.Height = 42;
            dgvLeases.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(74, 151, 196),
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(74, 151, 196),
                SelectionForeColor = Color.White
            };
            dgvLeases.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 49, 53),
                Font = new Font("Century Gothic", 9F),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 8, 0),
                SelectionBackColor = Color.FromArgb(232, 243, 250),
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };
            dgvLeases.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(232, 243, 250),
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };

            dgvLeases.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tenant",
                HeaderText = "TENANT",
                FillWeight = 27,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvLeases.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Unit",
                HeaderText = "UNIT",
                FillWeight = 21,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvLeases.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "StartDate",
                HeaderText = "START DATE",
                FillWeight = 18,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvLeases.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "LeaseEnds",
                HeaderText = "LEASE ENDS",
                FillWeight = 18,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvLeases.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "STATUS",
                FillWeight = 16,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Padding = new Padding(4, 0, 4, 0)
                }
            });
        }

        private void ApplyLeaseFilters()
        {
            string search = txtSearchInput.Text.Trim();
            string status = cmbFilterDropdown.SelectedIndex <= 0 ? string.Empty : cmbFilterDropdown.Text;

            PMS_v1.UserControls.GridHelper.Filter(dgvLeases, row =>
            {
                bool matchesSearch = string.IsNullOrEmpty(search) ||
                    PMS_v1.UserControls.GridHelper.Has(row, "Tenant", search) || PMS_v1.UserControls.GridHelper.Has(row, "Unit", search) ||
                    PMS_v1.UserControls.GridHelper.Has(row, "StartDate", search) || PMS_v1.UserControls.GridHelper.Has(row, "LeaseEnds", search) ||
                    PMS_v1.UserControls.GridHelper.Has(row, "Status", search);
                bool matchesStatus = string.IsNullOrEmpty(status) ||
                    string.Equals(row.Cells["Status"].Value?.ToString(), status, StringComparison.OrdinalIgnoreCase);
                return matchesSearch && matchesStatus;
            });
        }

        private void LayoutCommandActionRow()
        {
            PMS_v1.UserControls.ActionRowLayout.PackRight(
                pnlCommandActionRow, txtSearchInput, cmbFilterDropdown, btnViewLease, btnEditLease, btnNewLease);
        }

        private void DgvLeases_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            PMS_v1.UserControls.StatusBadge.Paint(dgvLeases, e, "Status");
        }

        //Load statcards
        private void LoadStats()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                    COUNT(CASE WHEN STATUS = 'Active' THEN 1 END) AS Active,
                                    COUNT(CASE WHEN STATUS = 'Pending' THEN 1 END) AS Pending,
                                    COUNT(CASE WHEN STATUS = 'Expired' THEN 1 END) AS Expired,
                                    COUNT(CASE WHEN STATUS = 'Terminated' THEN 1 END) AS Terminate
                               FROM lease";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        statCardActive.CardNumber = reader["Active"].ToString();
                        statCardPending.CardNumber = reader["Pending"].ToString();
                        statCardExpired.CardNumber = reader["Expired"].ToString();
                        statCardTerminated.CardNumber = reader["Terminate"].ToString();
                    }
                }
            }
        }

        private void LoadLease()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                    CONCAT(r.FIRST_NAME, ' ', r.LAST_NAME) AS Tenant,
                                    l.LEASE_ID,
                                    u.UNIT_NO, u.FLOOR_NO,
                                    l.START_DATE AS StartDate,
                                    l.END_DATE AS LeaseEnds, l.STATUS
                               FROM lease l
                               LEFT JOIN resident r ON l.RESIDENT_ID = r.RESIDENT_ID
                               LEFT JOIN units u ON l.UNIT_ID = u.UNIT_ID
                               ORDER BY l.END_DATE DESC";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dgvLeases.Rows.Clear();

                    while (reader.Read())
                    {
                        string status = reader["STATUS"].ToString() ?? string.Empty;
                        string unit = "Unit " + reader["UNIT_NO"].ToString() +
                            (reader["FLOOR_NO"] is DBNull ? string.Empty : " · Floor " + reader["FLOOR_NO"].ToString());

                        int rowIndex = dgvLeases.Rows.Add(
                            reader["Tenant"].ToString(),
                            unit,
                            Convert.ToDateTime(reader["StartDate"]).ToString("MMM dd, yyyy"),
                            Convert.ToDateTime(reader["LeaseEnds"]).ToString("MMM dd, yyyy"),
                            status);

                        dgvLeases.Rows[rowIndex].Tag = Convert.ToInt32(reader["LEASE_ID"]);
                    }
                }
            }

            ApplyLeaseFilters();
        }

        // ---------- helpers ----------
        private int? SelectedId => dgvLeases.CurrentRow?.Tag as int?;

        // admins and managers edit; staff can only view
        private static bool CanEdit => PMS_v1.Helper.Session.IsAdmin || PMS_v1.Helper.Session.IsManager;

        private bool RequireSelection(out int id)
        {
            if (SelectedId is int value) { id = value; return true; }
            id = 0;
            MessageBox.Show(this, "Select a lease in the table first.", "No lease selected",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        // ---------- VIEW ----------
        private void btnViewLease_Click(object? sender, EventArgs e) => ViewSelected();
        private void mnuView_Click(object? sender, EventArgs e) => ViewSelected();

        private void ViewSelected()
        {
            if (!RequireSelection(out int id)) return;

            using (var f = new LeaseDetailForm(id))
            {
                if (!f.Found) { LoadStats(); LoadLease(); return; }   // deleted by someone else
                f.ShowDialog(this.FindForm());
            }
        }

        // ---------- EDIT (admin and manager) ----------
        private void btnEditLease_Click(object? sender, EventArgs e) => EditSelected();
        private void mnuEdit_Click(object? sender, EventArgs e) => EditSelected();

        // what a lease can be changed to: Pending and Active move forward; an Expired or
        // Terminated lease can be reopened as Active (only admins and managers get this far)
        private static string[] StatusChoices(string current)
        {
            switch (current)
            {
                case "Pending": return new[] { "Pending", "Active", "Terminated" };
                case "Active": return new[] { "Active", "Expired", "Terminated" };
                default: return new[] { current, "Active" };
            }
        }

        private void EditSelected()
        {
            if (!CanEdit) return;
            if (!RequireSelection(out int id)) return;

            Dictionary<string, object> current;
            int unitId;
            string oldStatus;
            decimal oldRent;
            DateTime loadedUpdatedAt;
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT RESIDENT_ID, UNIT_ID, START_DATE, END_DATE, MONTHLY_RENT, DEPOSIT, STATUS, UPDATED_AT " +
                "FROM lease WHERE LEASE_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) { LoadStats(); LoadLease(); return; }   // deleted by someone else

                    unitId = Convert.ToInt32(r["UNIT_ID"]);
                    oldStatus = r["STATUS"].ToString() ?? string.Empty;
                    oldRent = Convert.ToDecimal(r["MONTHLY_RENT"]);
                    loadedUpdatedAt = Convert.ToDateTime(r["UPDATED_AT"]);

                    current = new Dictionary<string, object>
                    {
                        ["resident"] = r["RESIDENT_ID"],
                        ["unit"] = r["UNIT_ID"],
                        ["startDate"] = r["START_DATE"],
                        ["endDate"] = r["END_DATE"],
                        ["monthlyRent"] = r["MONTHLY_RENT"],
                        ["deposit"] = r["DEPOSIT"],
                        ["status"] = r["STATUS"]
                    };
                }
            }

            // tenant and unit are shown but locked; the start date is locked once the lease is no longer Pending
            using (var f = new RecordForm(FormMode.Edit, "Lease",
                FormDefinitions.Lease(FormMode.Edit, startLocked: oldStatus != "Pending")))
            {
                f.Validator = values => ValidateLeaseEdit(values, id, unitId, oldStatus);
                f.SetOptions("resident", Lookups.Residents());
                f.SetOptions("unit", Lookups.AllUnits());
                f.SetOptions("status", StatusChoices(oldStatus));
                f.SetValues(current);
                if (f.ShowDialog(this.FindForm()) != DialogResult.OK) return;

                var v = f.Values;
                if ((decimal)v["monthlyRent"] != oldRent &&
                    MessageBox.Show(this,
                        "Changing the monthly rent only affects bills created from now on. " +
                        "Bills that already exist keep their amounts.\n\nSave the new rent?",
                        "Change monthly rent", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                SaveLeaseEdit(id, unitId, loadedUpdatedAt, oldStatus, v);
            }
        }

        // runs when Save is pressed, so a problem keeps the form open
        private string? ValidateLeaseEdit(Dictionary<string, object> v, int leaseId, int unitId, string oldStatus)
        {
            string? error = FormDefinitions.ValidateLease(v);
            if (error != null) return error;

            using (var conn = Db.GetConnection())
            {
                conn.Open();
                return CheckLease(conn, null, leaseId, unitId,
                    (DateTime)v["startDate"], (DateTime)v["endDate"], oldStatus, (string)v["status"]);
            }
        }

        // the checks that need the database; returns a message, or null when the lease can be saved
        private static string? CheckLease(MySqlConnection conn, MySqlTransaction? tx, int leaseId, int unitId,
            DateTime start, DateTime end, string oldStatus, string newStatus)
        {
            // Expired and Terminated leases no longer hold the unit
            if (newStatus != "Pending" && newStatus != "Active") return null;

            using (var cmd = new MySqlCommand(
                "SELECT COUNT(*) FROM lease WHERE UNIT_ID = @unit AND LEASE_ID <> @id " +
                "AND STATUS IN ('Pending', 'Active') AND START_DATE <= @end AND END_DATE >= @start", conn, tx))
            {
                cmd.Parameters.AddWithValue("@unit", unitId);
                cmd.Parameters.AddWithValue("@id", leaseId);
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                if (Convert.ToInt32(cmd.ExecuteScalar()) > 0)
                    return "This unit already has another Pending or Active lease that overlaps these dates.";
            }

            if (newStatus == "Active" && oldStatus != "Active")
            {
                using (var cmd = new MySqlCommand("SELECT STATUS FROM units WHERE UNIT_ID = @unit", conn, tx))
                {
                    cmd.Parameters.AddWithValue("@unit", unitId);
                    if (string.Equals(cmd.ExecuteScalar()?.ToString(), "Under Maintenance", StringComparison.Ordinal))
                        return "This unit is under maintenance, so the lease can't be set to Active. Finish the maintenance first.";
                }
            }
            return null;
        }

        // saves the lease and keeps the unit's status in step, all or nothing.
        // RESIDENT_ID, UNIT_ID and EMPLOYEE_NO are not touched, so whoever recorded the lease stays on it.
        private void SaveLeaseEdit(int id, int unitId, DateTime loadedUpdatedAt, string oldStatus,
            Dictionary<string, object> v)
        {
            string newStatus = (string)v["status"];
            string? problem = null;   // set when nothing could be saved

            using (var conn = Db.GetConnection())
            {
                conn.Open();
                using (var tx = conn.BeginTransaction())
                {
                    // lock the lease, then make sure nobody changed it while the form was open
                    object? stamp;
                    using (var cmd = new MySqlCommand(
                        "SELECT UPDATED_AT FROM lease WHERE LEASE_ID = @id FOR UPDATE", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        stamp = cmd.ExecuteScalar();
                    }

                    if (stamp == null)
                        problem = "This lease no longer exists.";
                    else if (Convert.ToDateTime(stamp) != loadedUpdatedAt)
                        problem = "This lease was changed by someone else while you were editing it. Your changes were not saved.";
                    else
                    {
                        // lock the unit too, so its status can't change between the checks and the save
                        using (var cmd = new MySqlCommand(
                            "SELECT STATUS FROM units WHERE UNIT_ID = @unit FOR UPDATE", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@unit", unitId);
                            cmd.ExecuteScalar();
                        }

                        problem = CheckLease(conn, tx, id, unitId,
                            (DateTime)v["startDate"], (DateTime)v["endDate"], oldStatus, newStatus);
                    }

                    if (problem == null)
                    {
                        using (var cmd = new MySqlCommand(
                            "UPDATE lease SET START_DATE = @start, END_DATE = @end, MONTHLY_RENT = @rent, " +
                            "DEPOSIT = @deposit, STATUS = @status WHERE LEASE_ID = @id", conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@start", v["startDate"]);
                            cmd.Parameters.AddWithValue("@end", v["endDate"]);
                            cmd.Parameters.AddWithValue("@rent", v["monthlyRent"]);
                            cmd.Parameters.AddWithValue("@deposit", v["deposit"] ?? 0m);
                            cmd.Parameters.AddWithValue("@status", newStatus);
                            cmd.Parameters.AddWithValue("@id", id);
                            cmd.ExecuteNonQuery();
                        }

                        // an Active lease makes the unit Occupied; when one ends, the unit goes back to
                        // Vacant unless it is still Occupied by another Active lease
                        string? unitSql = null;
                        if (newStatus == "Active")
                            unitSql = "UPDATE units SET STATUS = 'Occupied' WHERE UNIT_ID = @unit";
                        else if (oldStatus == "Active")
                            unitSql = "UPDATE units SET STATUS = 'Vacant' WHERE UNIT_ID = @unit AND STATUS = 'Occupied' " +
                                      "AND NOT EXISTS (SELECT 1 FROM lease WHERE UNIT_ID = @unit AND STATUS = 'Active' AND LEASE_ID <> @id)";

                        if (unitSql != null)
                        {
                            using (var cmd = new MySqlCommand(unitSql, conn, tx))
                            {
                                cmd.Parameters.AddWithValue("@unit", unitId);
                                cmd.Parameters.AddWithValue("@id", id);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        tx.Commit();
                    }
                    else
                    {
                        tx.Rollback();
                    }
                }
            }

            if (problem != null)
                MessageBox.Show(this, problem, "Lease not saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadStats();
            LoadLease();
        }

        private void btnNewLease_Click_1(object sender, EventArgs e)
        {
            using (var f = new RecordForm(FormMode.New, "Lease", FormDefinitions.Lease()))
            {
                f.Validator = FormDefinitions.ValidateLease;
                f.SetOptions("unit", Lookups.VacantUnits());       // a list of new ComboItem(unitId, "Unit 101")
                f.SetOptions("resident", Lookups.Residents());
                if (f.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    int unitId = (int)f.Values["unit"];
                    // INSERT with @parameters here
                }
            }
        }
    }
}