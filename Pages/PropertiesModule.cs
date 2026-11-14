namespace PMS_v1.Pages
{
    public partial class PropertiesModule : UserControl
    {

        public event Action<string>? PropertySearchChanged;
        public event Action<string>? PropertyStatusChanged;
        public event EventHandler? NewPropertyRequested;

        public PropertiesModule()
        {
            InitializeComponent();
            ConfigurePropertyActions();
            LayoutActionRow();
            pnlActions.Resize += (_, _) => LayoutActionRow();
        }

        private void ConfigurePropertyActions()
        {
            cmbFilter.Items.AddRange(new object[]
            {
                "All Properties", "Occupied", "Vacant"
            });
            cmbFilter.SelectedIndex = 0;
            btnNewProperty.Values.Text = "＋  New Property";


            txtSearch.TextChanged += (_, _) =>
                PropertySearchChanged?.Invoke(txtSearch.Text.Trim());
            cmbFilter.SelectedIndexChanged += (_, _) =>
                PropertyStatusChanged?.Invoke(Convert.ToString(cmbFilter.SelectedItem) ?? "All Properties");
            btnNewProperty.Click += (_, _) => NewPropertyRequested?.Invoke(this, EventArgs.Empty);
        }

        private void LayoutActionRow()
        {
            PMS_v1.UserControls.ModulePageLayout.LayoutActions(
                pnlActions, txtSearch, cmbFilter, btnNewProperty);
        }
    }
}
