using Krypton.Toolkit;
using pms_UI.User_Controls;
using PMS_v1.Pages;
using PMS_v1.UserControls;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pms_UI
{
    public partial class Main : Form
    {
        private int fullWidth, compactWidth, targetWidth;
        private bool menuExpanded = true;
        private readonly System.Windows.Forms.Timer menuTimer = new System.Windows.Forms.Timer { Interval = 5 };

        public Main()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            fullWidth = sideMenuFull1.Width;
            compactWidth = sideMenuCompact1.Width;
            pnlSideMenu.Width = fullWidth;
            sideMenuCompact1.Visible = false;

            menuTimer.Tick += MenuTimer_Tick;
            header1.MenuToggleClicked += (s, e) => ToggleMenu();

            sideMenuFull1.PageRequested += SideMenu_PageRequested;
            sideMenuCompact1.PageRequested += SideMenu_PageRequested;
         
        }

        private void ToggleMenu()
        {
            if (menuTimer.Enabled) return;           // ignore clicks while animating

            menuExpanded = !menuExpanded;
            targetWidth = menuExpanded ? fullWidth : compactWidth;

            if (menuExpanded)                        // show the full menu first, then it is revealed as it grows
            {
                sideMenuFull1.Visible = true;            // show before hiding, so there's no blank frame
                sideMenuCompact1.Visible = false;
            }
            pnlContent.SuspendLayout();
            menuTimer.Start();
        }
        private void MenuTimer_Tick(object? sender, EventArgs e)
        {
            int diff = targetWidth - pnlSideMenu.Width;
            int step = Math.Max(Math.Abs(diff) / 2, 2) * Math.Sign(diff);   // fast at first, slows down at the end

            if (Math.Abs(diff) <= Math.Abs(step))
            {
                pnlSideMenu.Width = targetWidth;
                menuTimer.Stop();
                pnlContent.ResumeLayout(true);

                if (!menuExpanded)                   // finished collapsing, so swap to the icon-only menu
                {
                    sideMenuCompact1.Visible = true;
                    sideMenuFull1.Visible = false;
                }
            }
            else
            {
                pnlSideMenu.Width += step;
            }
        }
        private readonly Dictionary<string, UserControl> _pages = new();

        private void ShowPage(string key, Func<UserControl> create)
        {
            if (!_pages.TryGetValue(key, out var page))
                _pages[key] = page = create();

            pnlContent.Controls.Clear();   // don't dispose, since the page is reused
            page.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(page);
        }

        private void SideMenu_PageRequested(string page)
        {
            switch (page)
            {
                //case "Dashboard": ShowPage(new DashboardPage()); break;
                case "Units": ShowPage("Units", () => new Units()); break;
                //case "Tenants": ShowPage(new TenantsPage()); break;
                //case "Leasing": ShowPage(new LeasingPage()); break;
                //case "Billing": ShowPage(new BillingPage()); break;
                //case "Payment": ShowPage(new PaymentPage()); break;
                //case "Maintenance": ShowPage(new MaintenancePage()); break;
                //case "Reports": ShowPage(new ReportsPage()); break;
                //case "Settings": ShowPage(new SettingsPage()); break;
                case "Logout": Logout(); break;
            }
        }

        public bool LoggedOut { get; private set; }

        private void Logout()
        {
            var result = MessageBox.Show(this, "Are you sure you want to log out?",
                "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result != DialogResult.Yes) return;

            LoggedOut = true;
            Close();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED: paints the form as one buffered layer
                return cp;
            }
        }
    }
}
