using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.DataAccess;
using PMS_v1.ExceptionHandler;
using PMS_v1.Models.Entities;
using PMS_v1.Models.Requests;
using PMS_v1.Models.Responses;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PMS_v1.Pages.Content.Residents
{
    public partial class ResidentsModule : UserControl
    {
        private readonly ResidentData _residentData = new ResidentData();

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
            ResidentStats? stats = _residentData.GetStats();

            if (stats != null)
            {
                int total = stats.Total;
                int withLease = stats.WithLease;
                statCardTotal.CardNumber = total.ToString();
                statCardWithLease.CardNumber = withLease.ToString();
                statCardNoLease.CardNumber = Math.Max(0, total - withLease).ToString();
                statCardNew.CardNumber = stats.NewThisMonth.ToString();
            }
        }

        private void LoadResidents()
        {
            List<ResidentListItem> residents = _residentData.GetAll();

            dgvResidents.Rows.Clear();
            foreach (ResidentListItem r in residents)
            {
                int index = dgvResidents.Rows.Add(
                    r.FirstName + " " + r.LastName,
                    Show(r.ContactNo),
                    Show(r.Email),
                    r.Birthdate is DateTime d ? d.ToString("MMM dd, yyyy") : "—",
                    Show(r.EmergencyContactNo),
                    r.HasLease ? "Active" : "None");

                dgvResidents.Rows[index].Tag = r.ResidentId;
            }
            ApplyFilters();
        }

        private static string Show(object? value) =>
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

        private static SaveResidentRequest ToRequest(Dictionary<string, object> v)
        {
            // RecordForm returns null for blank optional fields
            return new SaveResidentRequest
            {
                FirstName = (string)v["firstName"],
                LastName = (string)v["lastName"],
                ContactNo = (string?)v["contact"],
                Email = (string?)v["email"],
                Birthdate = (DateTime?)v["birthdate"],
                EmergencyContactNo = (string?)v["emergencyContact"]
            };
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
                    _residentData.Create(ToRequest(f.Values));
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

            Resident? resident = _residentData.GetById(id);
            if (resident == null) { Refresh_(); return; }   // deleted by someone else

            Dictionary<string, object> current = new Dictionary<string, object>
            {
                ["firstName"] = resident.FirstName,
                ["lastName"] = resident.LastName,
                ["contact"] = (object?)resident.ContactNo ?? DBNull.Value,
                ["email"] = (object?)resident.Email ?? DBNull.Value,
                ["birthdate"] = (object?)resident.Birthdate ?? DBNull.Value,
                ["emergencyContact"] = (object?)resident.EmergencyContactNo ?? DBNull.Value
            };

            using (var f = new RecordForm(FormMode.Edit, "Resident", FormDefinitions.Resident()))
            {
                f.Validator = FormDefinitions.ValidateResident;
                f.SetValues(current);                       // DBNull values are skipped
                if (f.ShowDialog(this.FindForm()) != DialogResult.OK) return;

                try
                {
                    _residentData.Update(id, ToRequest(f.Values));
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
                _residentData.Delete(id);
                Refresh_();
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(this, ex, ErrorRules.ResidentDelete);
            }
        }
    }
}