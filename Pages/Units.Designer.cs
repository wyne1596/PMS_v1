namespace PMS_v1.Pages
{
    partial class Units
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            lblPage = new Label();
            lblLoc = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnSearch = new Krypton.Toolkit.ButtonSpecAny();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoScroll = true;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 18.5542164F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 13.6144581F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 67.83132F));
            tableLayoutPanel1.Size = new Size(914, 679);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.Controls.Add(lblPage);
            panel1.Controls.Add(lblLoc);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(3, 2);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(13, 0, 0, 0);
            panel1.Size = new Size(908, 52);
            panel1.TabIndex = 0;
            // 
            // lblPage
            // 
            lblPage.AutoSize = true;
            lblPage.Dock = DockStyle.Top;
            lblPage.Font = new Font("Century Gothic", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPage.Location = new Point(13, 25);
            lblPage.Name = "lblPage";
            lblPage.Size = new Size(61, 26);
            lblPage.TabIndex = 1;
            lblPage.Text = "Units";
            // 
            // lblLoc
            // 
            lblLoc.AutoSize = true;
            lblLoc.Dock = DockStyle.Top;
            lblLoc.Font = new Font("Century Gothic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblLoc.ForeColor = Color.DimGray;
            lblLoc.Location = new Point(13, 0);
            lblLoc.Name = "lblLoc";
            lblLoc.Padding = new Padding(3, 0, 0, 8);
            lblLoc.Size = new Size(85, 25);
            lblLoc.TabIndex = 0;
            lblLoc.Text = "Home / Units";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 58);
            tableLayoutPanel2.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Size = new Size(908, 111);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60.9914932F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.5042515F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 19.5042515F));
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 173);
            tableLayoutPanel3.Margin = new Padding(3, 2, 3, 2);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(908, 80);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // btnSearch
            // 
            btnSearch.Edge = Krypton.Toolkit.PaletteRelativeEdgeAlign.Near;
            btnSearch.Image = Resources.Resources.Search;
            btnSearch.Style = Krypton.Toolkit.PaletteButtonStyle.LowProfile;
            btnSearch.ToolTipShadow = false;
            btnSearch.UniqueName = "10437e8b346441a98f6afb9b5e57af75";
            // 
            // Units
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Units";
            Size = new Size(914, 679);
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label lblPage;
        private Label lblLoc;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Krypton.Toolkit.ButtonSpecAny btnSearch;
        private UserControls.Statcard statcard1;
    }
}
