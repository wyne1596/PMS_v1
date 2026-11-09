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
    }
}
