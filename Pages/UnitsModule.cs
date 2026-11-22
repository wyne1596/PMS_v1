using MySql.Data.MySqlClient;
using PMS_v1.Database;
using PMS_v1.Helper;

namespace PMS_v1.Pages
{
    public partial class UnitsModule : UserControl
    {

        public event Action<string>? PropertySearchChanged;
        public event Action<string>? UnitAvailabilityChanged;
        public event EventHandler? NewPropertyRequested;

        public UnitsModule()
        {
            InitializeComponent();
            PMS_v1.UserControls.ModulePageLayout.ApplyStandardLayout(
                tlpMain, pnlHeader, tlpMetrics, pnlActions, roundedPanelTable);
            PMS_v1.UserControls.ModulePageLayout.FitGridToRoundedPanel(roundedPanelTable, dgvUnits);
            ConfigureUnitActions();
            ConfigureUnitsGrid();
            LayoutActionRow();
            pnlActions.Resize += (_, _) => LayoutActionRow();
            txtSearch.TextChanged += (_, _) => ApplyUnitFilters();
            cmbFilter.SelectedIndexChanged += (_, _) => ApplyUnitFilters();
            dgvUnits.CellDoubleClick += (_, e) => { if (e.RowIndex >= 0) ViewSelected(); };
            dgvUnits.CellMouseDown += (_, e) =>
            {
                // right-click selects the row under the mouse so the menu acts on it
                if (e.Button == MouseButtons.Right && e.RowIndex >= 0)
                    dgvUnits.CurrentCell = dgvUnits.Rows[e.RowIndex].Cells[0];
            };
            ctxRow.Opening += (_, e) =>
            {
                if (SelectedId == null) { e.Cancel = true; return; }   // nothing under the mouse
            };
            LoadStats();
            LoadUnits();
        }

        private void ConfigureUnitActions()
        {
            cmbFilter.Items.AddRange(new object[]
            {
                "All Units", "Vacant", "Occupied", "Under Maintenance"
            });
            cmbFilter.SelectedIndex = 0;


            txtSearch.TextChanged += (_, _) =>
                PropertySearchChanged?.Invoke(txtSearch.Text.Trim());
            cmbFilter.SelectedIndexChanged += (_, _) =>
                UnitAvailabilityChanged?.Invoke(Convert.ToString(cmbFilter.SelectedItem) ?? "All Units");
            btnNewProperty.Click += (_, _) => NewPropertyRequested?.Invoke(this, EventArgs.Empty);

            btnNewProperty.Click += (_, _) => EditSelected();
        }

        // Table: same look as the other pages (columns follow the units table)
        private void ConfigureUnitsGrid()
        {
            PMS_v1.UserControls.ModulePageLayout.ApplyStandardGridStyle(dgvUnits);

            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Unit",
                HeaderText = "UNIT",
                FillWeight = 16,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Floor",
                HeaderText = "FLOOR",
                FillWeight = 14,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Type",
                HeaderText = "TYPE",
                FillWeight = 26,
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BaseRent",
                HeaderText = "BASE RENT",
                FillWeight = 22,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleRight,
                    Padding = new Padding(8, 0, 14, 0)
                }
            });
            dgvUnits.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Status",
                HeaderText = "STATUS",
                FillWeight = 22,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Padding = new Padding(4, 0, 4, 0)
                }
            });

            PMS_v1.UserControls.StatusBadge.Attach(dgvUnits, "Status");
        }

        private void ApplyUnitFilters()
        {
            string search = txtSearch.Text.Trim();
            string status = cmbFilter.SelectedIndex <= 0 ? string.Empty : cmbFilter.Text;

            PMS_v1.UserControls.GridHelper.Filter(dgvUnits, row =>
            {
                bool matchesSearch = string.IsNullOrEmpty(search) ||
                    PMS_v1.UserControls.GridHelper.Has(row, "Unit", search) || PMS_v1.UserControls.GridHelper.Has(row, "Floor", search) ||
                    PMS_v1.UserControls.GridHelper.Has(row, "Type", search) || PMS_v1.UserControls.GridHelper.Has(row, "BaseRent", search) ||
                    PMS_v1.UserControls.GridHelper.Has(row, "Status", search);
                bool matchesStatus = string.IsNullOrEmpty(status) ||
                    string.Equals(row.Cells["Status"].Value?.ToString(), status, StringComparison.OrdinalIgnoreCase);
                return matchesSearch && matchesStatus;
            });
        }

        private void LayoutActionRow()
        {
            PMS_v1.UserControls.ActionRowLayout.PackRight(
                pnlActions, txtSearch, cmbFilter, btnViewUnit, btnNewProperty);
        }

        // Load stats
        private void LoadStats()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                                    COUNT(*) AS TotalUnits,
                                    COUNT(CASE WHEN STATUS = 'Vacant' THEN 1 END) AS VacantUnits,
                                    COUNT(CASE WHEN STATUS = 'Occupied' THEN 1 END) AS OccupiedUnits,
                                    COUNT(CASE WHEN STATUS = 'Under Maintenance' THEN 1 END) AS MaintenanceUnits
                               FROM Units";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        statCardTotalUnits.CardNumber = reader["TotalUnits"].ToString();
                        statCardVacantUnits.CardNumber = reader["VacantUnits"].ToString();
                        statCardOccupiedUnits.CardNumber = reader["OccupiedUnits"].ToString();
                        statCardMaintenanceUnits.CardNumber = reader["MaintenanceUnits"].ToString();
                    }
                }
            }
        }

        private void LoadUnits()
        {
            using (var conn = Db.GetConnection())
            {
                conn.Open();

                string query = @"
                               SELECT
                               UNIT_ID, UNIT_NO, FLOOR_NO, UNIT_TYPE, BASE_RENT, STATUS FROM units
                               ORDER BY CASE WHEN STATUS = 'Vacant' THEN 0 ELSE 1 END,   -- vacant units first
                                        FLOOR_NO ASC, UNIT_NO ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dgvUnits.Rows.Clear();

                    while (reader.Read())
                    {
                        string status = reader["STATUS"].ToString() ?? string.Empty;

                        int rowIndex = dgvUnits.Rows.Add(
                            reader["UNIT_NO"].ToString(),   // UNIT_NO is varchar, so "101A" must not crash
                            reader["FLOOR_NO"].ToString(),
                            reader["UNIT_TYPE"].ToString(),
                            "₱" + Convert.ToDecimal(reader["BASE_RENT"]).ToString("N2"),
                            status);

                        dgvUnits.Rows[rowIndex].Tag = Convert.ToInt32(reader["UNIT_ID"]);
                    }
                }
            }

            ApplyUnitFilters();
        }

        // ---------- helpers ----------
        private int? SelectedId => dgvUnits.CurrentRow?.Tag as int?;

        private bool RequireSelection(out int id)
        {
            if (SelectedId is int value) { id = value; return true; }
            id = 0;
            MessageBox.Show(this, "Select a unit in the table first.", "No unit selected",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            return false;
        }

        private void Refresh_()
        {
            LoadStats();
            LoadUnits();
        }

        // ---------- VIEW (everyone) ----------
        private void btnViewUnit_Click(object? sender, EventArgs e) => ViewSelected();
        private void mnuView_Click(object? sender, EventArgs e) => ViewSelected();

        private void ViewSelected()
        {
            if (!RequireSelection(out int id)) return;

            using (var f = new UnitDetailForm(id))
            {
                if (!f.Found) { Refresh_(); return; }   // deleted by someone else
                f.ShowDialog(this.FindForm());
                if (f.Changed) Refresh_();               // an admin edited it in the form
            }
        }

        // ---------- EDIT ----------
        private void mnuEdit_Click(object? sender, EventArgs e) => EditSelected();

        private void EditSelected()
        {
            if (!RequireSelection(out int id)) return;

            if (UnitDetailForm.EditUnit(this.FindForm(), id))
                Refresh_();
        }
    }
}