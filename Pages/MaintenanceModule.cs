using MySql.Data.MySqlClient;
using PMS_v1.Database;
using System.Drawing.Drawing2D;

namespace PMS_v1.Pages
{
    public partial class MaintenanceModule : UserControl
    {

        public MaintenanceModule()
        {
            InitializeComponent();
            PMS_v1.UserControls.ModulePageLayout.ApplyStandardLayout(
                tlpMain, pnlHeader, tlpMetrics, pnlActions, roundedPanelTable);
            PMS_v1.UserControls.ModulePageLayout.FitGridToRoundedPanel(roundedPanelTable, dgvRequests);
            ConfigureMaintenanceGrid();
            PMS_v1.UserControls.GridHelper.ShowSelection(dgvRequests);
            LayoutActionRow();

            pnlActions.Resize += (_, _) => LayoutActionRow();
            txtSearch.TextChanged += (_, _) => ApplyRequestFilters();
            cmbFilter.SelectedIndexChanged += (_, _) => ApplyRequestFilters();
            dgvRequests.CellPainting += DgvRequests_CellPainting;
            dgvRequests.CellMouseDown += (_, e) =>
            {
                // right-click selects the row under the mouse so the menu acts on it
                if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                    dgvRequests.CurrentCell = dgvRequests.Rows[e.RowIndex].Cells[0];
            };
            ctxRow.Opening += (_, e) =>
            {
                if (SelectedId == null) { e.Cancel = true; return; }   // nothing under the mouse
            };
            mnuEdit.Visible = CanEdit;   // staff can view and add, only admins and managers can edit
            btnEditRequest.Visible = CanEdit;
            LoadStats();
            LoadRequests();
        }

        private void ConfigureMaintenanceGrid()
        {

            cmbFilter.Items.AddRange(new object[] { "All Statuses", "Open", "In Progress", "Resolved", "Closed" });
            cmbFilter.SelectedIndex = 0;

            dgvRequests.AutoGenerateColumns = false;
            dgvRequests.AllowUserToAddRows = false;
            dgvRequests.AllowUserToDeleteRows = false;
            dgvRequests.AllowUserToResizeRows = false;
            dgvRequests.MultiSelect = false;
            dgvRequests.ReadOnly = true;
            dgvRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRequests.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvRequests.EnableHeadersVisualStyles = false;
            dgvRequests.RowTemplate.Height = 42;
            dgvRequests.ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(74, 151, 196),
                ForeColor = Color.White,
                Font = new Font("Century Gothic", 9F, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                SelectionBackColor = Color.FromArgb(74, 151, 196),
                SelectionForeColor = Color.White
            };
            dgvRequests.DefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                ForeColor = Color.FromArgb(44, 49, 53),
                Font = new Font("Century Gothic", 9F),
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Padding = new Padding(12, 0, 8, 0),
                SelectionBackColor = Color.FromArgb(232, 243, 250),
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };
            dgvRequests.AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.White,
                SelectionBackColor = Color.FromArgb(232, 243, 250),
                SelectionForeColor = Color.FromArgb(44, 49, 53)
            };

            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Request",
                HeaderText = "REQUEST",
                FillWeight = 12,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Unit",
                HeaderText = "UNIT",
                FillWeight = 10,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Issue",
                HeaderText = "ISSUE",
                FillWeight = 24,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Type",
                HeaderText = "TYPE",
                FillWeight = 12,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Reported",
                HeaderText = "DATE REPORTED",
                FillWeight = 14,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "STATUS",
                FillWeight = 14,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Padding = new Padding(4, 0, 4, 0)
                }
            });
            dgvRequests.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Priority",
                HeaderText = "PRIORITY",
                FillWeight = 14,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Padding = new Padding(4, 0, 4, 0)
                }
            });
        }

        private void LayoutActionRow()
        {
            PMS_v1.UserControls.ActionRowLayout.PackRight(
                pnlActions, txtSearch, cmbFilter, btnEditRequest, btnNewRequest);
        }

        private void ApplyRequestFilters()
        {
            string searchText = txtSearch.Text.Trim();
            string selectedStatus = cmbFilter.SelectedIndex <= 0 ? string.Empty : cmbFilter.Text;

            dgvRequests.CurrentCell = null;   // a grid can't hide the row that holds the current cell
            foreach (DataGridViewRow row in dgvRequests.Rows)
            {
                bool matchesSearch = string.IsNullOrEmpty(searchText) ||
                    row.Cells["Request"].Value?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ||
                    row.Cells["Unit"].Value?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ||
                    row.Cells["Issue"].Value?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ||
                    row.Cells["Type"].Value?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ||
                    row.Cells["Reported"].Value?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ||
                    row.Cells["Priority"].Value?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true ||
                    row.Cells["Status"].Value?.ToString()?.Contains(searchText, StringComparison.OrdinalIgnoreCase) == true;
                bool matchesStatus = string.IsNullOrEmpty(selectedStatus) ||
                    string.Equals(row.Cells["Status"].Value?.ToString(), selectedStatus, StringComparison.OrdinalIgnoreCase);

                row.Visible = matchesSearch && matchesStatus;
            }
        }

        private void DgvRequests_CellPainting(object? sender, DataGridViewCellPaintingEventArgs e)
        {
            PMS_v1.UserControls.StatusBadge.Paint(dgvRequests, e, "Status");
            PMS_v1.UserControls.StatusBadge.Paint(dgvRequests, e, "Priority");
        }

        private static Bitmap CreateInProgressIcon()
        {
            var icon = new Bitmap(48, 48);
            using Graphics graphics = Graphics.FromImage(icon);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.Transparent);

            using var blue = new SolidBrush(Color.FromArgb(74, 151, 196));
            using var white = new SolidBrush(Color.White);
            using var gearPen = new Pen(Color.FromArgb(74, 151, 196), 2.5F);

            Point[] hourglass =
            {
                new(8, 7), new(29, 7), new(29, 11), new(22, 19),
                new(22, 22), new(29, 30), new(29, 35), new(8, 35),
                new(8, 30), new(15, 22), new(15, 19), new(8, 11)
            };
            graphics.FillPolygon(blue, hourglass);
            graphics.FillPolygon(white, new[] { new Point(12, 11), new Point(25, 11), new Point(19, 18) });
            graphics.FillPolygon(white, new[] { new Point(19, 25), new Point(25, 31), new Point(12, 31) });

            graphics.DrawLine(gearPen, 34, 26, 34, 31);
            graphics.DrawLine(gearPen, 34, 37, 34, 42);
            graphics.DrawLine(gearPen, 27, 34, 32, 34);
            graphics.DrawLine(gearPen, 36, 34, 41, 34);
            graphics.DrawLine(gearPen, 29, 29, 32, 32);
            graphics.DrawLine(gearPen, 36, 36, 39, 39);
            graphics.DrawLine(gearPen, 29, 39, 32, 36);
            graphics.DrawLine(gearPen, 36, 32, 39, 29);
            graphics.DrawEllipse(gearPen, 30, 30, 8, 8);

            return icon;
        }

        private void statCardCanceled_Load(object sender, EventArgs e)
        {

        }

        // Load statcards: one card per database status.
        // statCardCompleted = Resolved, statCardScheduled = Open, statCardInProgress = In Progress, statCardCanceled = Closed
        private void LoadStats()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                   COUNT(CASE WHEN STATUS = 'Resolved' THEN 1 END) AS Resolved,
                                   COUNT(CASE WHEN STATUS = 'Open' THEN 1 END) AS OpenRequests,
                                   COUNT(CASE WHEN STATUS = 'In Progress' THEN 1 END) AS InProgress,
                                   COUNT(CASE WHEN STATUS = 'Closed' THEN 1 END) AS Closed
                               FROM maintenance_request";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        statCardCompleted.CardNumber = reader["Resolved"].ToString();
                        statCardScheduled.CardNumber = reader["OpenRequests"].ToString();
                        statCardInProgress.CardNumber = reader["InProgress"].ToString();
                        statCardCanceled.CardNumber = reader["Closed"].ToString();
                    }
                }
            }
        }

        // Load requests into the table.
        // The Status column shows the database status as it is: Open, In Progress, Resolved, Closed.
        // Order: Resolved/Closed sink to the bottom; the rest go Urgent > High > Medium > Low, oldest reported first.
        private void LoadRequests()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT m.REPORT_ID, u.UNIT_NO, m.PROBLEM, m.MAINTENANCE_TYPE, m.DATE_REPORTED, m.PRIORITY, m.STATUS
                               FROM maintenance_request m
                               LEFT JOIN units u ON u.UNIT_ID = m.UNIT_ID
                               ORDER BY CASE WHEN m.STATUS IN ('Resolved', 'Closed') THEN 1 ELSE 0 END,
                                        FIELD(m.PRIORITY, 'Urgent', 'High', 'Medium', 'Low'),
                                        m.DATE_REPORTED ASC, m.REPORT_ID ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dgvRequests.Rows.Clear();

                    while (reader.Read())
                    {
                        int rowIndex = dgvRequests.Rows.Add(
                            "R-" + Convert.ToInt32(reader["REPORT_ID"]).ToString("D4"),
                            reader["UNIT_NO"] is DBNull ? "Common area" : reader["UNIT_NO"].ToString(),
                            reader["PROBLEM"].ToString(),
                            reader["MAINTENANCE_TYPE"].ToString(),
                            Convert.ToDateTime(reader["DATE_REPORTED"]).ToString("MMM dd, yyyy", System.Globalization.CultureInfo.InvariantCulture),
                            reader["STATUS"].ToString(),
                            reader["PRIORITY"].ToString());

                        dgvRequests.Rows[rowIndex].Tag = Convert.ToInt32(reader["REPORT_ID"]);
                    }
                }
            }

            ApplyRequestFilters();
        }

        // ---------- helpers ----------
        private int? SelectedId => dgvRequests.CurrentRow?.Tag as int?;

        // admins and managers edit; staff can only view and add
        private static bool CanEdit => PMS_v1.Helper.Session.IsAdmin || PMS_v1.Helper.Session.IsManager;

        private bool RequireSelection(out int id)
        {
            if (SelectedId is int value) { id = value; return true; }
            id = 0;
            MessageBox.Show(this, "Select a request in the table first.", "No request selected",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        private void Refresh_()
        {
            LoadStats();
            LoadRequests();
        }

        // dropdown choices with a first entry that saves as NULL ("Common area", "None")
        private static List<ComboItem> WithFirst(string text, List<ComboItem> items)
        {
            items.Insert(0, new ComboItem(null, text));
            return items;
        }

        // the values the New and Edit forms share
        private static void AddRequestParams(MySqlCommand cmd, Dictionary<string, object> v)
        {
            cmd.Parameters.AddWithValue("@unit", v["unit"] ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@resident", v["resident"] ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@problem", v["problem"] ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@type", v["maintenanceType"] ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@priority", v["priority"] ?? DBNull.Value);
            cmd.Parameters.AddWithValue("@reported", v["dateReported"] ?? DBNull.Value);
        }

        // ---------- CREATE ----------
        private void btnNewRequest_Click(object sender, EventArgs e)
        {
            using (var f = new RecordForm(FormMode.New, "Request", FormDefinitions.Maintenance()))
            {
                f.SetOptions("unit", WithFirst("Common area", Lookups.AllUnits()));
                f.SetOptions("resident", WithFirst("None", Lookups.Residents()));
                if (f.ShowDialog(this.FindForm()) != DialogResult.OK) return;

                using (var conn = Db.GetConnection())
                using (var cmd = new MySqlCommand(
                    "INSERT INTO maintenance_request " +
                    "(UNIT_ID, RESIDENT_ID, PROBLEM, MAINTENANCE_TYPE, PRIORITY, DATE_REPORTED) " +
                    "VALUES (@unit, @resident, @problem, @type, @priority, @reported)", conn))
                {
                    AddRequestParams(cmd, f.Values);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                Refresh_();
            }
        }

        // ---------- VIEW (everyone) ----------
        private void mnuView_Click(object? sender, EventArgs e) => ViewSelected();

        private void ViewSelected()
        {
            if (!RequireSelection(out int id)) return;

            using (var f = new MaintenanceDetailForm(id))
            {
                if (!f.Found) { Refresh_(); return; }   // deleted by someone else
                f.ShowDialog(this.FindForm());
            }
        }

        // ---------- EDIT (admin and manager) ----------
        private void mnuEdit_Click(object? sender, EventArgs e) => EditSelected();
        private void btnEditRequest_Click(object? sender, EventArgs e) => EditSelected();

        private void EditSelected()
        {
            if (!CanEdit) return;
            if (!RequireSelection(out int id)) return;

            Dictionary<string, object> current;
            int? assignedId = null;
            using (var conn = Db.GetConnection())
            using (var cmd = new MySqlCommand(
                "SELECT UNIT_ID, RESIDENT_ID, PROBLEM, MAINTENANCE_TYPE, PRIORITY, DATE_REPORTED, STATUS, " +
                "PERSONNEL_ID, DATE_COMPLETED, COST, REPAIR_DETAILS " +
                "FROM maintenance_request WHERE REPORT_ID = @id", conn))
            {
                cmd.Parameters.AddWithValue("@id", id);
                conn.Open();
                using (var r = cmd.ExecuteReader())
                {
                    if (!r.Read()) { Refresh_(); return; }   // deleted by someone else

                    if (!(r["PERSONNEL_ID"] is DBNull)) assignedId = Convert.ToInt32(r["PERSONNEL_ID"]);

                    // a missing unit, reporter or technician selects the "Common area" / "None" choice
                    current = new Dictionary<string, object>
                    {
                        ["unit"] = r["UNIT_ID"] is DBNull ? "Common area" : r["UNIT_ID"],
                        ["resident"] = r["RESIDENT_ID"] is DBNull ? "None" : r["RESIDENT_ID"],
                        ["problem"] = r["PROBLEM"],
                        ["maintenanceType"] = r["MAINTENANCE_TYPE"],
                        ["priority"] = r["PRIORITY"],
                        ["dateReported"] = r["DATE_REPORTED"],
                        ["status"] = r["STATUS"],
                        ["technician"] = r["PERSONNEL_ID"] is DBNull ? "None" : r["PERSONNEL_ID"],
                        ["dateCompleted"] = r["DATE_COMPLETED"],
                        ["cost"] = r["COST"],
                        ["repairDetails"] = r["REPAIR_DETAILS"]
                    };
                }
            }

            using (var f = new RecordForm(FormMode.Edit, "Request", FormDefinitions.Maintenance(FormMode.Edit)))
            {
                f.Validator = FormDefinitions.ValidateMaintenance;
                f.SetOptions("unit", WithFirst("Common area", Lookups.AllUnits()));
                f.SetOptions("resident", WithFirst("None", Lookups.Residents()));
                f.SetOptions("technician", WithFirst("None", Lookups.Technicians(assignedId)));
                f.SetValues(current);                       // DBNull values are skipped
                if (f.ShowDialog(this.FindForm()) != DialogResult.OK) return;

                using (var conn = Db.GetConnection())
                using (var cmd = new MySqlCommand(
                    "UPDATE maintenance_request SET UNIT_ID=@unit, RESIDENT_ID=@resident, PROBLEM=@problem, " +
                    "MAINTENANCE_TYPE=@type, PRIORITY=@priority, DATE_REPORTED=@reported, STATUS=@status, " +
                    "PERSONNEL_ID=@technician, DATE_COMPLETED=@completed, COST=@cost, REPAIR_DETAILS=@repair " +
                    "WHERE REPORT_ID=@id", conn))
                {
                    var v = f.Values;
                    AddRequestParams(cmd, v);
                    cmd.Parameters.AddWithValue("@status", v["status"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@technician", v["technician"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@completed", v["dateCompleted"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@cost", v["cost"] ?? 0m);
                    cmd.Parameters.AddWithValue("@repair", v["repairDetails"] ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                Refresh_();
            }
        }
    }
}