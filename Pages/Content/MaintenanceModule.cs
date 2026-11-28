using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.DataAccess;
using PMS_v1.Models.Entities;
using PMS_v1.Models.Requests;
using PMS_v1.Models.Responses;
using PMS_v1.PopupForms.DetailForms;
using PMS_v1.ExceptionHandler;
using System.Drawing.Drawing2D;

namespace PMS_v1.Pages.Content.Maintenance
{
    public partial class MaintenanceModule : UserControl
    {
        private readonly MaintenanceData _maintenanceData = new MaintenanceData();

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
            // Main caches its pages, so reload every time this page is shown (other pages change what it displays)
            VisibleChanged += (_, _) => { if (Visible && !DesignMode) Refresh_(); };
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

        private void statCardCanceled_Load(object sender, EventArgs e)
        {

        }

        // Load statcards: one card per database status.
        // statCardCompleted = Resolved, statCardScheduled = Open, statCardInProgress = In Progress, statCardCanceled = Closed
        private void LoadStats()
        {
            MaintenanceStats? stats = _maintenanceData.GetStats();

            if (stats != null)
            {
                statCardCompleted.CardNumber = stats.Resolved.ToString();
                statCardScheduled.CardNumber = stats.Open.ToString();
                statCardInProgress.CardNumber = stats.InProgress.ToString();
                statCardCanceled.CardNumber = stats.Closed.ToString();
            }
        }

        // Load requests into the table.
        // The Status column shows the database status as it is: Open, In Progress, Resolved, Closed.
        // Order: Resolved/Closed sink to the bottom; the rest go Urgent > High > Medium > Low, oldest reported first.
        private void LoadRequests()
        {
            List<MaintenanceListItem> requests = _maintenanceData.GetAll();

            dgvRequests.Rows.Clear();

            foreach (MaintenanceListItem request in requests)
            {
                int rowIndex = dgvRequests.Rows.Add(
                    "R-" + request.ReportId.ToString("D4"),
                    request.UnitNo ?? "Common area",
                    request.Problem,
                    request.MaintenanceType,
                    request.DateReported.ToString("MMM dd, yyyy", System.Globalization.CultureInfo.InvariantCulture),
                    request.Status,
                    request.Priority);

                dgvRequests.Rows[rowIndex].Tag = request.ReportId;
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
        private static CreateMaintenanceRequest ToCreateRequest(Dictionary<string, object> v)
        {
            return new CreateMaintenanceRequest
            {
                UnitId = (int?)v["unit"],
                ResidentId = (int?)v["resident"],
                Problem = (string?)v["problem"],
                MaintenanceType = (string?)v["maintenanceType"],
                Priority = (string?)v["priority"],
                DateReported = (DateTime?)v["dateReported"]
            };
        }

        private static UpdateMaintenanceRequest ToUpdateRequest(Dictionary<string, object> v)
        {
            return new UpdateMaintenanceRequest
            {
                UnitId = (int?)v["unit"],
                ResidentId = (int?)v["resident"],
                Problem = (string?)v["problem"],
                MaintenanceType = (string?)v["maintenanceType"],
                Priority = (string?)v["priority"],
                DateReported = (DateTime?)v["dateReported"],
                Status = (string?)v["status"],
                PersonnelId = (int?)v["technician"],
                DateCompleted = (DateTime?)v["dateCompleted"],
                Cost = (decimal?)v["cost"] ?? 0m,
                RepairDetails = (string?)v["repairDetails"]
            };
        }

        // ---------- CREATE ----------
        private void btnNewRequest_Click(object sender, EventArgs e)
        {
            using (var f = new RecordForm(FormMode.New, "Request", FormDefinitions.Maintenance()))
            {
                f.Validator = FormDefinitions.ValidateMaintenance;
                f.SetOptions("unit", WithFirst("Common area", LookupData.AllUnits()));
                f.SetOptions("resident", WithFirst("None", LookupData.Residents()));
                if (f.ShowDialog(this.FindForm()) != DialogResult.OK) return;

                try
                {
                    _maintenanceData.Create(ToCreateRequest(f.Values));
                    Refresh_();
                }
                catch (Exception ex)
                {
                    ErrorHandler.Show(this, ex);
                }
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

            MaintenanceRequest? request = _maintenanceData.GetById(id);
            if (request == null) { Refresh_(); return; }   // deleted by someone else

            int? assignedId = request.PersonnelId;

            // a missing unit, reporter or technician selects the "Common area" / "None" choice
            Dictionary<string, object> current = new Dictionary<string, object>
            {
                ["unit"] = request.UnitId.HasValue ? (object)request.UnitId.Value : "Common area",
                ["resident"] = request.ResidentId.HasValue ? (object)request.ResidentId.Value : "None",
                ["problem"] = request.Problem,
                ["maintenanceType"] = request.MaintenanceType,
                ["priority"] = request.Priority,
                ["dateReported"] = request.DateReported,
                ["status"] = request.Status,
                ["technician"] = request.PersonnelId.HasValue ? (object)request.PersonnelId.Value : "None",
                ["dateCompleted"] = (object?)request.DateCompleted ?? DBNull.Value,
                ["cost"] = request.Cost,
                ["repairDetails"] = (object?)request.RepairDetails ?? DBNull.Value
            };

            using (var f = new RecordForm(FormMode.Edit, "Request", FormDefinitions.Maintenance(FormMode.Edit)))
            {
                f.Validator = FormDefinitions.ValidateMaintenance;
                f.SetOptions("unit", WithFirst("Common area", LookupData.AllUnits()));
                f.SetOptions("resident", WithFirst("None", LookupData.Residents()));
                f.SetOptions("technician", WithFirst("None", LookupData.Technicians(assignedId)));
                f.SetValues(current);                       // DBNull values are skipped
                if (f.ShowDialog(this.FindForm()) != DialogResult.OK) return;

                try
                {
                    _maintenanceData.Update(id, ToUpdateRequest(f.Values));
                    Refresh_();
                }
                catch (Exception ex)
                {
                    ErrorHandler.Show(this, ex);
                }
            }
        }
    }
}