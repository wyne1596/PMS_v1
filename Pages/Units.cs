using MySql.Data.MySqlClient;
using PMS_v1.Database;

namespace PMS_v1.Pages
{
    public partial class Units : UserControl
    {
        private const string SearchPlaceholder = "⌕  Search properties...";

        public event Action<string>? PropertySearchChanged;
        public event Action<string>? UnitAvailabilityChanged;
        public event EventHandler? NewPropertyRequested;

        public Units()
        {
            InitializeComponent();
            ConfigureUnitActions();
            LayoutActionRow();
            pnlActions.Resize += (_, _) => LayoutActionRow();
            LoadStats();
        }

        private void ConfigureUnitActions()
        {
            txtSearch.Text = SearchPlaceholder;
            cmbFilter.Items.AddRange(new object[]
            {
                "All Units", "Vacant", "Occupied"
            });
            cmbFilter.SelectedIndex = 0;
            btnNewProperty.Values.Text = "＋  New Property";

            txtSearch.Enter += (_, _) =>
            {
                if (txtSearch.Text == SearchPlaceholder)
                    txtSearch.Text = string.Empty;
            };
            txtSearch.Leave += (_, _) =>
            {
                if (string.IsNullOrWhiteSpace(txtSearch.Text))
                    txtSearch.Text = SearchPlaceholder;
            };

            txtSearch.TextChanged += (_, _) =>
                PropertySearchChanged?.Invoke(txtSearch.Text == SearchPlaceholder ? string.Empty : txtSearch.Text.Trim());
            cmbFilter.SelectedIndexChanged += (_, _) =>
                UnitAvailabilityChanged?.Invoke(Convert.ToString(cmbFilter.SelectedItem) ?? "All Units");
            btnNewProperty.Click += (_, _) => NewPropertyRequested?.Invoke(this, EventArgs.Empty);
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
    }
}
