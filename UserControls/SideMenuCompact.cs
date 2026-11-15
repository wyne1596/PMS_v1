using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Windows.Forms;

namespace PMS_v1.UserControls
{
    public partial class SideMenuCompact : UserControl
    {
        public event Action<string>? PageRequested;
        private readonly Dictionary<Button, Action> buttonStyleRefreshers = new();
        private Button? activePageButton;
        private const int ActiveButtonHeightIncrease = 6;
        private static readonly Color ActiveBackColor = Color.FromArgb(0, 98, 204);
        private static readonly Color ActiveBorderColor = Color.FromArgb(135, 206, 250);

        public SideMenuCompact()
        {
            InitializeComponent();
            // Normal color, hover color
            StyleButtons(this, Color.White, Color.FromArgb(140, 224, 78)); // green

            // Different hover color for specific buttons
            StyleButton(btnLogout, Color.White, Color.FromArgb(235, 80, 90)); // red

            var tip = new ToolTip();
            tip.SetToolTip(btnDashboard, "Dashboard");
            tip.SetToolTip(btnUnits, "Units");
            tip.SetToolTip(btnLeasing, "Leasing");
            tip.SetToolTip(btnBilling, "Billing");
            tip.SetToolTip(btnPayment, "Payment");
            tip.SetToolTip(btnMaintenance, "Maintenance");
            tip.SetToolTip(btnReports, "Reports");
            tip.SetToolTip(btnSettings, "Settings");
            tip.SetToolTip(btnLogout, "Logout");

            btnDashboard.Click += (s, e) => PageRequested?.Invoke("Dashboard");
            btnUnits.Click += (s, e) => PageRequested?.Invoke("Units");
            btnLeasing.Click += (s, e) => PageRequested?.Invoke("Leasing");
            btnBilling.Click += (s, e) => PageRequested?.Invoke("Billing");
            btnPayment.Click += (s, e) => PageRequested?.Invoke("Payment");
            btnMaintenance.Click += (s, e) => PageRequested?.Invoke("Maintenance");
            btnReports.Click += (s, e) => PageRequested?.Invoke("Reports");
            btnSettings.Click += (s, e) => PageRequested?.Invoke("Settings");
            btnLogout.Click += (s, e) => PageRequested?.Invoke("Logout");
        }

        public void SetActivePage(string page)
        {
            activePageButton = page switch
            {
                "Dashboard" => btnDashboard,
                "Units" => btnUnits,
                "Leasing" => btnLeasing,
                "Billing" => btnBilling,
                "Payment" => btnPayment,
                "Maintenance" => btnMaintenance,
                "Reports" => btnReports,
                "Settings" => btnSettings,
                _ => null
            };

            foreach (Action refreshStyle in buttonStyleRefreshers.Values)
                refreshStyle();
        }

        private void StyleButtons(Control root, Color normal, Color hover)
        {
            foreach (Control c in root.Controls)
            {
                if (c is Button b && c != btnLogout)
                    StyleButton(b, normal, hover);
                if (c.HasChildren) StyleButtons(c, normal, hover);
            }
        }

        private void StyleButton(Button b, Color normal, Color hover)
        {
            int normalHeight = b.Height;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.FlatAppearance.MouseOverBackColor = Color.Transparent;
            b.FlatAppearance.MouseDownBackColor = Color.Transparent;
            b.BackColor = Color.Transparent;
            b.UseVisualStyleBackColor = false;
            b.Cursor = Cursors.Arrow;
            b.ForeColor = normal;

            Image? src = b.Image;
            Image? normalImg = src != null ? Tint(src, normal) : null;
            Image? hoverImg = src != null ? Tint(src, hover) : null;

            void ApplyStyle(bool hovered)
            {
                bool active = b == activePageButton;
                b.ForeColor = active ? normal : hovered ? hover : normal;
                b.BackColor = active ? ActiveBackColor : Color.Transparent;
                b.FlatAppearance.BorderSize = active ? 2 : 0;
                b.FlatAppearance.BorderColor = ActiveBorderColor;
                b.Height = active ? normalHeight + ActiveButtonHeightIncrease : normalHeight;

                if (!active && hovered && hoverImg != null) b.Image = hoverImg;
                else if (normalImg != null) b.Image = normalImg;
            }

            buttonStyleRefreshers[b] = () =>
                ApplyStyle(b.ClientRectangle.Contains(b.PointToClient(Cursor.Position)));
            b.MouseEnter += (s, e) => ApplyStyle(true);
            b.MouseLeave += (s, e) => ApplyStyle(false);
            ApplyStyle(false);
        }

        // Recolors an image to one color, keeping its transparency
        private static Image Tint(Image src, Color color)
        {
            var bmp = new Bitmap(src.Width, src.Height);
            using (var g = Graphics.FromImage(bmp))
            using (var attrs = new ImageAttributes())
            {
                attrs.SetColorMatrix(new ColorMatrix(new float[][]
                {
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 0, 0 },
                new float[] { 0, 0, 0, 1, 0 },
                new float[] { color.R / 255f, color.G / 255f, color.B / 255f, 0, 1 }
                }));
                g.DrawImage(src, new Rectangle(0, 0, src.Width, src.Height),
                            0, 0, src.Width, src.Height, GraphicsUnit.Pixel, attrs);
            }
            return bmp;
        }
    }
}
