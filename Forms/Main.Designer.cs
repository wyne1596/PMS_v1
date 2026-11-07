namespace pms_UI
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            pnlRight = new Panel();
            pnlContent = new Panel();
            header1 = new PMS_v1.UserControls.Header();
            pnlSideMenu = new Panel();
            sideMenuCompact1 = new PMS_v1.UserControls.SideMenuCompact();
            sideMenuFull1 = new pms_UI.User_Controls.SideMenuFull();
            pnlRight.SuspendLayout();
            pnlSideMenu.SuspendLayout();
            SuspendLayout();
            // 
            // pnlRight
            // 
            pnlRight.Controls.Add(pnlContent);
            pnlRight.Controls.Add(header1);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(290, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Size = new Size(1132, 977);
            pnlRight.TabIndex = 3;
            // 
            // pnlContent
            // 
            pnlContent.Dock = DockStyle.Fill;
            pnlContent.Location = new Point(0, 75);
            pnlContent.Name = "pnlContent";
            pnlContent.Size = new Size(1132, 902);
            pnlContent.TabIndex = 1;
            // 
            // header1
            // 
            header1.Dock = DockStyle.Top;
            header1.Location = new Point(0, 0);
            header1.Name = "header1";
            header1.Size = new Size(1132, 75);
            header1.TabIndex = 0;
            // 
            // pnlSideMenu
            // 
            pnlSideMenu.BackColor = Color.SteelBlue;
            pnlSideMenu.BackgroundImage = PMS_v1.Resources.Resources.SideMenu;
            pnlSideMenu.BackgroundImageLayout = ImageLayout.Stretch;
            pnlSideMenu.Controls.Add(sideMenuCompact1);
            pnlSideMenu.Controls.Add(sideMenuFull1);
            pnlSideMenu.Dock = DockStyle.Left;
            pnlSideMenu.Location = new Point(0, 0);
            pnlSideMenu.Name = "pnlSideMenu";
            pnlSideMenu.Size = new Size(290, 977);
            pnlSideMenu.TabIndex = 0;
            // 
            // sideMenuCompact1
            // 
            sideMenuCompact1.BackColor = Color.Transparent;
            sideMenuCompact1.BackgroundImage = (Image)resources.GetObject("sideMenuCompact1.BackgroundImage");
            sideMenuCompact1.BackgroundImageLayout = ImageLayout.Stretch;
            sideMenuCompact1.Dock = DockStyle.Left;
            sideMenuCompact1.Location = new Point(290, 0);
            sideMenuCompact1.Name = "sideMenuCompact1";
            sideMenuCompact1.Size = new Size(80, 977);
            sideMenuCompact1.TabIndex = 1;
            // 
            // sideMenuFull1
            // 
            sideMenuFull1.BackgroundImage = (Image)resources.GetObject("sideMenuFull1.BackgroundImage");
            sideMenuFull1.BackgroundImageLayout = ImageLayout.Stretch;
            sideMenuFull1.Dock = DockStyle.Left;
            sideMenuFull1.Location = new Point(0, 0);
            sideMenuFull1.Name = "sideMenuFull1";
            sideMenuFull1.Size = new Size(290, 977);
            sideMenuFull1.TabIndex = 0;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1422, 977);
            Controls.Add(pnlRight);
            Controls.Add(pnlSideMenu);
            Name = "Main";
            Text = "BaktuTenant";
            WindowState = FormWindowState.Maximized;
            pnlRight.ResumeLayout(false);
            pnlSideMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlRight;
        private Panel pnlContent;
        private PMS_v1.UserControls.Header header1;
        private Panel pnlSideMenu;
        private PMS_v1.UserControls.SideMenuCompact sideMenuCompact1;
        private User_Controls.SideMenuFull sideMenuFull1;
    }
}
