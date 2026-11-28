using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.DataAccess;
using PMS_v1.Models.Entities;
using PMS_v1.Models.Requests;
using PMS_v1.Models.Responses;
using PMS_v1.PopupForms.DetailForms;
using PMS_v1.ExceptionHandler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace PMS_v1.Pages.Content.Leasing
{
    public partial class LeasingModule : UserControl
    {
        private readonly LeaseData _leaseData = new LeaseData();

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
            // Main caches its pages, so reload every time this page is shown (other pages change what it displays)
            VisibleChanged += (_, _) => { if (Visible && !DesignMode) { ExpireEndedLeases(); LoadStats(); LoadLease(); } };
            ExpireEndedLeases();
            LoadStats();
            LoadLease();
        }

        // An Active lease whose end date has passed becomes Expired, and its unit goes back to Vacant
        // (unless the unit still has another Active lease that has not ended). Runs whenever the page is shown.
        private void ExpireEndedLeases()
        {
            try
            {
                _leaseData.ExpireEndedLeases();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(this, ex);
            }
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
            LeaseStats? stats = _leaseData.GetStats();

            if (stats != null)
            {
                statCardActive.CardNumber = stats.Active.ToString();
                statCardPending.CardNumber = stats.Pending.ToString();
                statCardExpired.CardNumber = stats.Expired.ToString();
                statCardTerminated.CardNumber = stats.Terminated.ToString();
            }
        }

        private void LoadLease()
        {
            List<LeaseListItem> leases = _leaseData.GetAll();

            dgvLeases.Rows.Clear();

            foreach (LeaseListItem lease in leases)
            {
                string unit = "Unit " + lease.UnitNo +
                    (lease.FloorNo.HasValue ? " · Floor " + lease.FloorNo.Value.ToString() : string.Empty);

                int rowIndex = dgvLeases.Rows.Add(
                    lease.Tenant,
                    unit,
                    lease.StartDate.ToString("MMM dd, yyyy"),
                    lease.EndDate.ToString("MMM dd, yyyy"),
                    lease.Status);

                dgvLeases.Rows[rowIndex].Tag = lease.LeaseId;
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

            Lease? lease = _leaseData.GetById(id);
            if (lease == null) { LoadStats(); LoadLease(); return; }   // deleted by someone else

            int unitId = lease.UnitId;
            string oldStatus = lease.Status;
            decimal oldRent = lease.MonthlyRent;
            DateTime loadedUpdatedAt = lease.UpdatedAt;

            Dictionary<string, object> current = new Dictionary<string, object>
            {
                ["resident"] = lease.ResidentId,
                ["unit"] = lease.UnitId,
                ["startDate"] = lease.StartDate,
                ["endDate"] = lease.EndDate,
                ["monthlyRent"] = lease.MonthlyRent,
                ["deposit"] = lease.Deposit,
                ["status"] = lease.Status
            };

            // tenant and unit are shown but locked; the start date is locked once the lease is no longer Pending
            using (var f = new RecordForm(FormMode.Edit, "Lease",
                FormDefinitions.Lease(FormMode.Edit, startLocked: oldStatus != "Pending")))
            {
                f.Validator = values => ValidateLeaseEdit(values, id, unitId, oldStatus);
                f.SetOptions("resident", LookupData.Residents());
                f.SetOptions("unit", LookupData.AllUnits());
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

            return _leaseData.CheckLease(leaseId, unitId,
                (DateTime)v["startDate"], (DateTime)v["endDate"], oldStatus, (string)v["status"]);
        }

        // saves the lease and keeps the unit's status in step, all or nothing (see LeaseData.SaveEdit).
        // RESIDENT_ID, UNIT_ID and EMPLOYEE_NO are not touched, so whoever recorded the lease stays on it.
        private void SaveLeaseEdit(int id, int unitId, DateTime loadedUpdatedAt, string oldStatus,
            Dictionary<string, object> v)
        {
            string? problem = null;   // set when nothing could be saved

            try
            {
                problem = _leaseData.SaveEdit(id, unitId, loadedUpdatedAt, oldStatus, new UpdateLeaseRequest
                {
                    StartDate = (DateTime)v["startDate"],
                    EndDate = (DateTime)v["endDate"],
                    MonthlyRent = (decimal)v["monthlyRent"],
                    Deposit = (decimal?)v["deposit"] ?? 0m,
                    Status = (string)v["status"]
                });
            }
            catch (Exception ex)
            {
                problem = ErrorHandler.Describe(ex, ErrorRules.Lease);
            }

            if (problem != null)
                MessageBox.Show(this, problem, "Lease not saved", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            LoadStats();
            LoadLease();
        }

        // the checks for a new lease; runs when Save is pressed, so a problem keeps the form open
        private string? ValidateNewLease(Dictionary<string, object> v)
        {
            string? error = FormDefinitions.ValidateLease(v);
            if (error != null) return error;

            return _leaseData.CheckLease(0, (int)v["unit"],
                (DateTime)v["startDate"], (DateTime)v["endDate"], string.Empty, (string)v["status"]);
        }

        // saves a new lease, all or nothing (see LeaseData.SaveNew). The rent is the unit's base rent at this moment
        // (copied, so later changes to the base rent never touch it) and the signed-in employee is recorded on the lease.
        private void SaveNewLease(Dictionary<string, object> v)
        {
            string? problem = null;   // set when nothing could be saved

            try
            {
                problem = _leaseData.SaveNew(new CreateLeaseRequest
                {
                    StartDate = (DateTime)v["startDate"],
                    EndDate = (DateTime)v["endDate"],
                    UnitId = (int)v["unit"],
                    ResidentId = (int)v["resident"],
                    Deposit = (decimal?)v["deposit"] ?? 0m,
                    Status = (string)v["status"],
                    PersonnelId = PMS_v1.Helper.Session.PersonnelId
                });
            }
            catch (Exception ex)
            {
                problem = ErrorHandler.Describe(ex, ErrorRules.Lease);
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
                f.Validator = ValidateNewLease;
                f.SetOptions("unit", LookupData.VacantUnits());       // a list of new ComboItem(unitId, "Unit 101")
                f.SetOptions("resident", LookupData.Residents());
                // the rent is the unit's base rent, copied when the lease is created, and can't be edited
                f.SetLocked("monthlyRent", true);
                f.OnChoiceChanged("unit", () => f.SetValue("monthlyRent", LookupData.BaseRent((int?)f.GetValue("unit"))));
                if (f.ShowDialog(FindForm()) == DialogResult.OK)
                {
                    SaveNewLease(f.Values);
                }
            }
        }
    }
}