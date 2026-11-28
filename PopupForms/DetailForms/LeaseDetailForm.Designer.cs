namespace PMS_v1.PopupForms.DetailForms
{
    partial class LeaseDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tlpRoot = new TableLayoutPanel();
            lblHeader = new Label();
            pnlPhoto = new Panel();
            picUnit = new PictureBox();
            lblNoPhoto = new Label();
            pnlBody = new Panel();
            tlpDetails = new TableLayoutPanel();
            lblCapStatus = new Label();
            lblStatus = new Label();
            lblCapTenant = new Label();
            lblTenant = new Label();
            lblCapUnit = new Label();
            lblUnit = new Label();
            lblCapFloor = new Label();
            lblFloor = new Label();
            lblCapUnitType = new Label();
            lblUnitType = new Label();
            lblCapStartDate = new Label();
            lblStartDate = new Label();
            lblCapEndDate = new Label();
            lblEndDate = new Label();
            lblCapMonthlyRent = new Label();
            lblMonthlyRent = new Label();
            lblCapDeposit = new Label();
            lblDeposit = new Label();
            lblCapRecordedBy = new Label();
            lblRecordedBy = new Label();
            lblCapLastUpdated = new Label();
            lblLastUpdated = new Label();
            pnlFooter = new FlowLayoutPanel();
            btnClose = new Button();
            tlpRoot.SuspendLayout();
            pnlPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picUnit).BeginInit();
            picUnit.SuspendLayout();
            pnlBody.SuspendLayout();
            tlpDetails.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // tlpRoot
            // 
            tlpRoot.ColumnCount = 1;
            tlpRoot.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpRoot.Controls.Add(lblHeader, 0, 0);
            tlpRoot.Controls.Add(pnlPhoto, 0, 1);
            tlpRoot.Controls.Add(pnlBody, 0, 2);
            tlpRoot.Controls.Add(pnlFooter, 0, 3);
            tlpRoot.Dock = DockStyle.Fill;
            tlpRoot.Location = new Point(0, 0);
            tlpRoot.Margin = new Padding(0);
            tlpRoot.Name = "tlpRoot";
            tlpRoot.RowCount = 4;
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 270F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            tlpRoot.Size = new Size(540, 780);
            tlpRoot.TabIndex = 0;
            // 
            // lblHeader
            // 
            lblHeader.BackColor = Color.FromArgb(72, 149, 199);
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Margin = new Padding(0);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(24, 0, 0, 0);
            lblHeader.Size = new Size(540, 56);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "Lease";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlPhoto
            // 
            pnlPhoto.BackColor = Color.White;
            pnlPhoto.Controls.Add(picUnit);
            pnlPhoto.Dock = DockStyle.Fill;
            pnlPhoto.Location = new Point(0, 56);
            pnlPhoto.Margin = new Padding(0);
            pnlPhoto.Name = "pnlPhoto";
            pnlPhoto.Padding = new Padding(24, 16, 24, 8);
            pnlPhoto.Size = new Size(540, 270);
            pnlPhoto.TabIndex = 1;
            // 
            // picUnit
            // 
            picUnit.BackColor = Color.FromArgb(244, 245, 246);
            picUnit.BorderStyle = BorderStyle.FixedSingle;
            picUnit.Controls.Add(lblNoPhoto);
            picUnit.Dock = DockStyle.Fill;
            picUnit.Location = new Point(24, 16);
            picUnit.Name = "picUnit";
            picUnit.Size = new Size(492, 246);
            picUnit.SizeMode = PictureBoxSizeMode.Zoom;
            picUnit.TabIndex = 0;
            picUnit.TabStop = false;
            // 
            // lblNoPhoto
            // 
            lblNoPhoto.BackColor = Color.Transparent;
            lblNoPhoto.Dock = DockStyle.Fill;
            lblNoPhoto.ForeColor = Color.FromArgb(120, 120, 120);
            lblNoPhoto.Location = new Point(0, 0);
            lblNoPhoto.Name = "lblNoPhoto";
            lblNoPhoto.Size = new Size(490, 244);
            lblNoPhoto.TabIndex = 0;
            lblNoPhoto.Text = "No photo yet";
            lblNoPhoto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            pnlBody.AutoScroll = true;
            pnlBody.Controls.Add(tlpDetails);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 326);
            pnlBody.Margin = new Padding(0);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(540, 390);
            pnlBody.TabIndex = 2;
            // 
            // tlpDetails
            // 
            tlpDetails.AutoSize = true;
            tlpDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpDetails.ColumnCount = 2;
            tlpDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tlpDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350F));
            tlpDetails.Controls.Add(lblCapStatus, 0, 0);
            tlpDetails.Controls.Add(lblStatus, 1, 0);
            tlpDetails.Controls.Add(lblCapTenant, 0, 1);
            tlpDetails.Controls.Add(lblTenant, 1, 1);
            tlpDetails.Controls.Add(lblCapUnit, 0, 2);
            tlpDetails.Controls.Add(lblUnit, 1, 2);
            tlpDetails.Controls.Add(lblCapFloor, 0, 3);
            tlpDetails.Controls.Add(lblFloor, 1, 3);
            tlpDetails.Controls.Add(lblCapUnitType, 0, 4);
            tlpDetails.Controls.Add(lblUnitType, 1, 4);
            tlpDetails.Controls.Add(lblCapStartDate, 0, 5);
            tlpDetails.Controls.Add(lblStartDate, 1, 5);
            tlpDetails.Controls.Add(lblCapEndDate, 0, 6);
            tlpDetails.Controls.Add(lblEndDate, 1, 6);
            tlpDetails.Controls.Add(lblCapMonthlyRent, 0, 7);
            tlpDetails.Controls.Add(lblMonthlyRent, 1, 7);
            tlpDetails.Controls.Add(lblCapDeposit, 0, 8);
            tlpDetails.Controls.Add(lblDeposit, 1, 8);
            tlpDetails.Controls.Add(lblCapRecordedBy, 0, 9);
            tlpDetails.Controls.Add(lblRecordedBy, 1, 9);
            tlpDetails.Controls.Add(lblCapLastUpdated, 0, 10);
            tlpDetails.Controls.Add(lblLastUpdated, 1, 10);
            tlpDetails.Dock = DockStyle.Top;
            tlpDetails.Location = new Point(0, 0);
            tlpDetails.Margin = new Padding(0);
            tlpDetails.Name = "tlpDetails";
            tlpDetails.Padding = new Padding(24, 8, 0, 8);
            tlpDetails.RowCount = 11;
            tlpDetails.RowStyles.Add(new RowStyle());
            tlpDetails.RowStyles.Add(new RowStyle());
            tlpDetails.RowStyles.Add(new RowStyle());
            tlpDetails.RowStyles.Add(new RowStyle());
            tlpDetails.RowStyles.Add(new RowStyle());
            tlpDetails.RowStyles.Add(new RowStyle());
            tlpDetails.RowStyles.Add(new RowStyle());
            tlpDetails.RowStyles.Add(new RowStyle());
            tlpDetails.RowStyles.Add(new RowStyle());
            tlpDetails.RowStyles.Add(new RowStyle());
            tlpDetails.RowStyles.Add(new RowStyle());
            tlpDetails.Size = new Size(540, 400);
            tlpDetails.TabIndex = 0;
            // 
            // lblCapStatus
            // 
            lblCapStatus.AutoSize = true;
            lblCapStatus.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapStatus.Location = new Point(24, 15);
            lblCapStatus.Margin = new Padding(0, 7, 8, 7);
            lblCapStatus.Name = "lblCapStatus";
            lblCapStatus.Size = new Size(60, 17);
            lblCapStatus.TabIndex = 0;
            lblCapStatus.Text = "Status";
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.ForeColor = Color.FromArgb(44, 49, 53);
            lblStatus.Location = new Point(154, 15);
            lblStatus.Margin = new Padding(0, 7, 0, 7);
            lblStatus.MaximumSize = new Size(340, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(10, 17);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "-";
            // 
            // lblCapTenant
            // 
            lblCapTenant.AutoSize = true;
            lblCapTenant.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapTenant.Location = new Point(24, 15);
            lblCapTenant.Margin = new Padding(0, 7, 8, 7);
            lblCapTenant.Name = "lblCapTenant";
            lblCapTenant.Size = new Size(60, 17);
            lblCapTenant.TabIndex = 2;
            lblCapTenant.Text = "Tenant";
            // 
            // lblTenant
            // 
            lblTenant.AutoSize = true;
            lblTenant.ForeColor = Color.FromArgb(44, 49, 53);
            lblTenant.Location = new Point(154, 15);
            lblTenant.Margin = new Padding(0, 7, 0, 7);
            lblTenant.MaximumSize = new Size(340, 0);
            lblTenant.Name = "lblTenant";
            lblTenant.Size = new Size(10, 17);
            lblTenant.TabIndex = 3;
            lblTenant.Text = "-";
            // 
            // lblCapUnit
            // 
            lblCapUnit.AutoSize = true;
            lblCapUnit.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapUnit.Location = new Point(24, 15);
            lblCapUnit.Margin = new Padding(0, 7, 8, 7);
            lblCapUnit.Name = "lblCapUnit";
            lblCapUnit.Size = new Size(60, 17);
            lblCapUnit.TabIndex = 4;
            lblCapUnit.Text = "Unit";
            // 
            // lblUnit
            // 
            lblUnit.AutoSize = true;
            lblUnit.ForeColor = Color.FromArgb(44, 49, 53);
            lblUnit.Location = new Point(154, 15);
            lblUnit.Margin = new Padding(0, 7, 0, 7);
            lblUnit.MaximumSize = new Size(340, 0);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(10, 17);
            lblUnit.TabIndex = 5;
            lblUnit.Text = "-";
            // 
            // lblCapFloor
            // 
            lblCapFloor.AutoSize = true;
            lblCapFloor.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapFloor.Location = new Point(24, 15);
            lblCapFloor.Margin = new Padding(0, 7, 8, 7);
            lblCapFloor.Name = "lblCapFloor";
            lblCapFloor.Size = new Size(60, 17);
            lblCapFloor.TabIndex = 6;
            lblCapFloor.Text = "Floor";
            // 
            // lblFloor
            // 
            lblFloor.AutoSize = true;
            lblFloor.ForeColor = Color.FromArgb(44, 49, 53);
            lblFloor.Location = new Point(154, 15);
            lblFloor.Margin = new Padding(0, 7, 0, 7);
            lblFloor.MaximumSize = new Size(340, 0);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(10, 17);
            lblFloor.TabIndex = 7;
            lblFloor.Text = "-";
            // 
            // lblCapUnitType
            // 
            lblCapUnitType.AutoSize = true;
            lblCapUnitType.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapUnitType.Location = new Point(24, 15);
            lblCapUnitType.Margin = new Padding(0, 7, 8, 7);
            lblCapUnitType.Name = "lblCapUnitType";
            lblCapUnitType.Size = new Size(60, 17);
            lblCapUnitType.TabIndex = 8;
            lblCapUnitType.Text = "Unit type";
            // 
            // lblUnitType
            // 
            lblUnitType.AutoSize = true;
            lblUnitType.ForeColor = Color.FromArgb(44, 49, 53);
            lblUnitType.Location = new Point(154, 15);
            lblUnitType.Margin = new Padding(0, 7, 0, 7);
            lblUnitType.MaximumSize = new Size(340, 0);
            lblUnitType.Name = "lblUnitType";
            lblUnitType.Size = new Size(10, 17);
            lblUnitType.TabIndex = 9;
            lblUnitType.Text = "-";
            // 
            // lblCapStartDate
            // 
            lblCapStartDate.AutoSize = true;
            lblCapStartDate.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapStartDate.Location = new Point(24, 15);
            lblCapStartDate.Margin = new Padding(0, 7, 8, 7);
            lblCapStartDate.Name = "lblCapStartDate";
            lblCapStartDate.Size = new Size(60, 17);
            lblCapStartDate.TabIndex = 10;
            lblCapStartDate.Text = "Start date";
            // 
            // lblStartDate
            // 
            lblStartDate.AutoSize = true;
            lblStartDate.ForeColor = Color.FromArgb(44, 49, 53);
            lblStartDate.Location = new Point(154, 15);
            lblStartDate.Margin = new Padding(0, 7, 0, 7);
            lblStartDate.MaximumSize = new Size(340, 0);
            lblStartDate.Name = "lblStartDate";
            lblStartDate.Size = new Size(10, 17);
            lblStartDate.TabIndex = 11;
            lblStartDate.Text = "-";
            // 
            // lblCapEndDate
            // 
            lblCapEndDate.AutoSize = true;
            lblCapEndDate.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapEndDate.Location = new Point(24, 15);
            lblCapEndDate.Margin = new Padding(0, 7, 8, 7);
            lblCapEndDate.Name = "lblCapEndDate";
            lblCapEndDate.Size = new Size(60, 17);
            lblCapEndDate.TabIndex = 12;
            lblCapEndDate.Text = "End date";
            // 
            // lblEndDate
            // 
            lblEndDate.AutoSize = true;
            lblEndDate.ForeColor = Color.FromArgb(44, 49, 53);
            lblEndDate.Location = new Point(154, 15);
            lblEndDate.Margin = new Padding(0, 7, 0, 7);
            lblEndDate.MaximumSize = new Size(340, 0);
            lblEndDate.Name = "lblEndDate";
            lblEndDate.Size = new Size(10, 17);
            lblEndDate.TabIndex = 13;
            lblEndDate.Text = "-";
            // 
            // lblCapMonthlyRent
            // 
            lblCapMonthlyRent.AutoSize = true;
            lblCapMonthlyRent.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapMonthlyRent.Location = new Point(24, 15);
            lblCapMonthlyRent.Margin = new Padding(0, 7, 8, 7);
            lblCapMonthlyRent.Name = "lblCapMonthlyRent";
            lblCapMonthlyRent.Size = new Size(60, 17);
            lblCapMonthlyRent.TabIndex = 14;
            lblCapMonthlyRent.Text = "Monthly rent";
            // 
            // lblMonthlyRent
            // 
            lblMonthlyRent.AutoSize = true;
            lblMonthlyRent.ForeColor = Color.FromArgb(44, 49, 53);
            lblMonthlyRent.Location = new Point(154, 15);
            lblMonthlyRent.Margin = new Padding(0, 7, 0, 7);
            lblMonthlyRent.MaximumSize = new Size(340, 0);
            lblMonthlyRent.Name = "lblMonthlyRent";
            lblMonthlyRent.Size = new Size(10, 17);
            lblMonthlyRent.TabIndex = 15;
            lblMonthlyRent.Text = "-";
            // 
            // lblCapDeposit
            // 
            lblCapDeposit.AutoSize = true;
            lblCapDeposit.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapDeposit.Location = new Point(24, 15);
            lblCapDeposit.Margin = new Padding(0, 7, 8, 7);
            lblCapDeposit.Name = "lblCapDeposit";
            lblCapDeposit.Size = new Size(60, 17);
            lblCapDeposit.TabIndex = 16;
            lblCapDeposit.Text = "Deposit";
            // 
            // lblDeposit
            // 
            lblDeposit.AutoSize = true;
            lblDeposit.ForeColor = Color.FromArgb(44, 49, 53);
            lblDeposit.Location = new Point(154, 15);
            lblDeposit.Margin = new Padding(0, 7, 0, 7);
            lblDeposit.MaximumSize = new Size(340, 0);
            lblDeposit.Name = "lblDeposit";
            lblDeposit.Size = new Size(10, 17);
            lblDeposit.TabIndex = 17;
            lblDeposit.Text = "-";
            // 
            // lblCapRecordedBy
            // 
            lblCapRecordedBy.AutoSize = true;
            lblCapRecordedBy.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapRecordedBy.Location = new Point(24, 15);
            lblCapRecordedBy.Margin = new Padding(0, 7, 8, 7);
            lblCapRecordedBy.Name = "lblCapRecordedBy";
            lblCapRecordedBy.Size = new Size(60, 17);
            lblCapRecordedBy.TabIndex = 18;
            lblCapRecordedBy.Text = "Recorded by";
            // 
            // lblRecordedBy
            // 
            lblRecordedBy.AutoSize = true;
            lblRecordedBy.ForeColor = Color.FromArgb(44, 49, 53);
            lblRecordedBy.Location = new Point(154, 15);
            lblRecordedBy.Margin = new Padding(0, 7, 0, 7);
            lblRecordedBy.MaximumSize = new Size(340, 0);
            lblRecordedBy.Name = "lblRecordedBy";
            lblRecordedBy.Size = new Size(10, 17);
            lblRecordedBy.TabIndex = 19;
            lblRecordedBy.Text = "-";
            // 
            // lblCapLastUpdated
            // 
            lblCapLastUpdated.AutoSize = true;
            lblCapLastUpdated.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapLastUpdated.Location = new Point(24, 15);
            lblCapLastUpdated.Margin = new Padding(0, 7, 8, 7);
            lblCapLastUpdated.Name = "lblCapLastUpdated";
            lblCapLastUpdated.Size = new Size(60, 17);
            lblCapLastUpdated.TabIndex = 20;
            lblCapLastUpdated.Text = "Last updated";
            // 
            // lblLastUpdated
            // 
            lblLastUpdated.AutoSize = true;
            lblLastUpdated.ForeColor = Color.FromArgb(44, 49, 53);
            lblLastUpdated.Location = new Point(154, 15);
            lblLastUpdated.Margin = new Padding(0, 7, 0, 7);
            lblLastUpdated.MaximumSize = new Size(340, 0);
            lblLastUpdated.Name = "lblLastUpdated";
            lblLastUpdated.Size = new Size(10, 17);
            lblLastUpdated.TabIndex = 21;
            lblLastUpdated.Text = "-";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(244, 245, 246);
            pnlFooter.Controls.Add(btnClose);
            pnlFooter.Dock = DockStyle.Fill;
            pnlFooter.FlowDirection = FlowDirection.RightToLeft;
            pnlFooter.Location = new Point(0, 716);
            pnlFooter.Margin = new Padding(0);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Padding = new Padding(24, 13, 24, 0);
            pnlFooter.Size = new Size(540, 64);
            pnlFooter.TabIndex = 3;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.White;
            btnClose.Cursor = Cursors.Hand;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.FlatAppearance.BorderColor = Color.Silver;
            btnClose.FlatAppearance.BorderSize = 1;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.FromArgb(44, 49, 53);
            btnClose.Location = new Point(406, 13);
            btnClose.Margin = new Padding(8, 0, 0, 0);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 38);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // LeaseDetailForm
            // 
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(540, 780);
            Controls.Add(tlpRoot);
            Font = new Font("Century Gothic", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "LeaseDetailForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Lease";
            tlpRoot.ResumeLayout(false);
            pnlPhoto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picUnit).EndInit();
            picUnit.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            tlpDetails.ResumeLayout(false);
            tlpDetails.PerformLayout();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpRoot;
        private Label lblHeader;
        private Panel pnlPhoto;
        private PictureBox picUnit;
        private Label lblNoPhoto;
        private Panel pnlBody;
        private TableLayoutPanel tlpDetails;
        private Label lblCapStatus;
        private Label lblStatus;
        private Label lblCapTenant;
        private Label lblTenant;
        private Label lblCapUnit;
        private Label lblUnit;
        private Label lblCapFloor;
        private Label lblFloor;
        private Label lblCapUnitType;
        private Label lblUnitType;
        private Label lblCapStartDate;
        private Label lblStartDate;
        private Label lblCapEndDate;
        private Label lblEndDate;
        private Label lblCapMonthlyRent;
        private Label lblMonthlyRent;
        private Label lblCapDeposit;
        private Label lblDeposit;
        private Label lblCapRecordedBy;
        private Label lblRecordedBy;
        private Label lblCapLastUpdated;
        private Label lblLastUpdated;
        private FlowLayoutPanel pnlFooter;
        private Button btnClose;
    }
}