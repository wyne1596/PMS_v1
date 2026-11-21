using MySql.Data.MySqlClient;
using PMS_v1.Database;

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
            LoadStats();
            LoadUnits();
        }

        private void ConfigureUnitActions()
        {
            cmbFilter.Items.AddRange(new object[]
            {
                "All Units", "Vacant", "Occupied"
            });
            cmbFilter.SelectedIndex = 0;


            txtSearch.TextChanged += (_, _) =>
                PropertySearchChanged?.Invoke(txtSearch.Text.Trim());
            cmbFilter.SelectedIndexChanged += (_, _) =>
                UnitAvailabilityChanged?.Invoke(Convert.ToString(cmbFilter.SelectedItem) ?? "All Units");
            btnNewProperty.Click += (_, _) => NewPropertyRequested?.Invoke(this, EventArgs.Empty);
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

            PMS_v1.UserControls.ModulePageLayout.AttachStatusBadge(dgvUnits, "Status");
        }

        private void LayoutActionRow()
        {
            PMS_v1.UserControls.ModulePageLayout.LayoutActions(
                pnlActions, txtSearch, cmbFilter, btnNewProperty);
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
                               UNIT_NO, FLOOR_NO, UNIT_TYPE, BASE_RENT, STATUS FROM units     
                               ORDER BY FLOOR_NO ASC";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    dgvUnits.Rows.Clear();

                    while (reader.Read())
                    {
                        string status = reader["STATUS"].ToString() ?? string.Empty;

                        dgvUnits.Rows.Add(
                            Convert.ToInt32(reader["UNIT_NO"]).ToString(),
                            reader["FLOOR_NO"].ToString(),
                            reader["UNIT_TYPE"].ToString(),
                            "₱" + reader["BASE_RENT"].ToString(),
                            status);   
                    }
                }
            }
        }
    }
}
