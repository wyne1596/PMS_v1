namespace PMS_v1.PopupForms.DetailForms
{
    partial class UnitDetailForm
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
            tlpUnit = new TableLayoutPanel();
            lblCapUnitNo = new Label();
            lblUnitNo = new Label();
            lblCapFloor = new Label();
            lblFloor = new Label();
            lblCapType = new Label();
            lblType = new Label();
            lblCapBaseRent = new Label();
            lblBaseRent = new Label();
            lblCapOpenRequests = new Label();
            lblOpenRequests = new Label();
            tlpTenant = new TableLayoutPanel();
            lblCapTenant = new Label();
            lblTenant = new Label();
            lblCapContact = new Label();
            lblContact = new Label();
            lblCapLeasePeriod = new Label();
            lblLeasePeriod = new Label();
            lblCapLeaseRent = new Label();
            lblLeaseRent = new Label();
            lblCapDeposit = new Label();
            lblDeposit = new Label();
            lblSectionUnit = new Label();
            lblSectionTenant = new Label();
            pnlDivider = new Panel();
            lblStatusBadge = new Label();
            picUnit = new PictureBox();
            lblNoPhoto = new Label();
            pnlBody = new Panel();
            pnlFooter = new Panel();
            btnClose = new Button();
            btnEditDetails = new Button();
            btnChangePhoto = new Button();
            btnRemovePhoto = new Button();
            lblHeader = new Label();
            tlpUnit.SuspendLayout();
            tlpTenant.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picUnit).BeginInit();
            picUnit.SuspendLayout();
            pnlBody.SuspendLayout();
            pnlFooter.SuspendLayout();
            SuspendLayout();
            // 
            // tlpUnit
            // 
            tlpUnit.ColumnCount = 2;
            tlpUnit.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpUnit.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpUnit.Controls.Add(lblCapUnitNo, 0, 0);
            tlpUnit.Controls.Add(lblUnitNo, 1, 0);
            tlpUnit.Controls.Add(lblCapFloor, 0, 1);
            tlpUnit.Controls.Add(lblFloor, 1, 1);
            tlpUnit.Controls.Add(lblCapType, 0, 2);
            tlpUnit.Controls.Add(lblType, 1, 2);
            tlpUnit.Controls.Add(lblCapBaseRent, 0, 3);
            tlpUnit.Controls.Add(lblBaseRent, 1, 3);
            tlpUnit.Controls.Add(lblCapOpenRequests, 0, 4);
            tlpUnit.Controls.Add(lblOpenRequests, 1, 4);
            tlpUnit.Location = new Point(348, 46);
            tlpUnit.Margin = new Padding(0);
            tlpUnit.Name = "tlpUnit";
            tlpUnit.RowCount = 5;
            tlpUnit.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpUnit.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpUnit.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpUnit.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpUnit.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpUnit.Size = new Size(388, 180);
            tlpUnit.TabIndex = 20;
            // 
            // lblCapUnitNo
            // 
            lblCapUnitNo.Dock = DockStyle.Fill;
            lblCapUnitNo.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapUnitNo.Location = new Point(3, 0);
            lblCapUnitNo.Name = "lblCapUnitNo";
            lblCapUnitNo.Size = new Size(114, 32);
            lblCapUnitNo.TabIndex = 0;
            lblCapUnitNo.Text = "Unit no.";
            lblCapUnitNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUnitNo
            // 
            lblUnitNo.AutoEllipsis = true;
            lblUnitNo.Dock = DockStyle.Fill;
            lblUnitNo.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            lblUnitNo.ForeColor = Color.FromArgb(40, 40, 40);
            lblUnitNo.Location = new Point(123, 0);
            lblUnitNo.Name = "lblUnitNo";
            lblUnitNo.Size = new Size(262, 32);
            lblUnitNo.TabIndex = 1;
            lblUnitNo.Text = "000";
            lblUnitNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapFloor
            // 
            lblCapFloor.Dock = DockStyle.Fill;
            lblCapFloor.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapFloor.Location = new Point(3, 32);
            lblCapFloor.Name = "lblCapFloor";
            lblCapFloor.Size = new Size(114, 32);
            lblCapFloor.TabIndex = 2;
            lblCapFloor.Text = "Floor";
            lblCapFloor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblFloor
            // 
            lblFloor.AutoEllipsis = true;
            lblFloor.Dock = DockStyle.Fill;
            lblFloor.Font = new Font("Century Gothic", 10F);
            lblFloor.ForeColor = Color.FromArgb(40, 40, 40);
            lblFloor.Location = new Point(123, 32);
            lblFloor.Name = "lblFloor";
            lblFloor.Size = new Size(262, 32);
            lblFloor.TabIndex = 3;
            lblFloor.Text = "0";
            lblFloor.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapType
            // 
            lblCapType.Dock = DockStyle.Fill;
            lblCapType.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapType.Location = new Point(3, 64);
            lblCapType.Name = "lblCapType";
            lblCapType.Size = new Size(114, 32);
            lblCapType.TabIndex = 4;
            lblCapType.Text = "Type";
            lblCapType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblType
            // 
            lblType.AutoEllipsis = true;
            lblType.Dock = DockStyle.Fill;
            lblType.Font = new Font("Century Gothic", 10F);
            lblType.ForeColor = Color.FromArgb(40, 40, 40);
            lblType.Location = new Point(123, 64);
            lblType.Name = "lblType";
            lblType.Size = new Size(262, 32);
            lblType.TabIndex = 5;
            lblType.Text = "Type";
            lblType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapBaseRent
            // 
            lblCapBaseRent.Dock = DockStyle.Fill;
            lblCapBaseRent.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapBaseRent.Location = new Point(3, 96);
            lblCapBaseRent.Name = "lblCapBaseRent";
            lblCapBaseRent.Size = new Size(114, 32);
            lblCapBaseRent.TabIndex = 6;
            lblCapBaseRent.Text = "Base rent";
            lblCapBaseRent.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBaseRent
            // 
            lblBaseRent.AutoEllipsis = true;
            lblBaseRent.Dock = DockStyle.Fill;
            lblBaseRent.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            lblBaseRent.ForeColor = Color.FromArgb(40, 40, 40);
            lblBaseRent.Location = new Point(123, 96);
            lblBaseRent.Name = "lblBaseRent";
            lblBaseRent.Size = new Size(262, 32);
            lblBaseRent.TabIndex = 7;
            lblBaseRent.Text = "000.00";
            lblBaseRent.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapOpenRequests
            // 
            lblCapOpenRequests.Dock = DockStyle.Fill;
            lblCapOpenRequests.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapOpenRequests.Location = new Point(3, 128);
            lblCapOpenRequests.Name = "lblCapOpenRequests";
            lblCapOpenRequests.Size = new Size(114, 52);
            lblCapOpenRequests.TabIndex = 8;
            lblCapOpenRequests.Text = "Pending repairs";
            lblCapOpenRequests.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOpenRequests
            // 
            lblOpenRequests.AutoEllipsis = true;
            lblOpenRequests.Dock = DockStyle.Fill;
            lblOpenRequests.Font = new Font("Century Gothic", 10F);
            lblOpenRequests.ForeColor = Color.FromArgb(40, 40, 40);
            lblOpenRequests.Location = new Point(123, 128);
            lblOpenRequests.Name = "lblOpenRequests";
            lblOpenRequests.Size = new Size(262, 52);
            lblOpenRequests.TabIndex = 9;
            lblOpenRequests.Text = "None";
            lblOpenRequests.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tlpTenant
            // 
            tlpTenant.ColumnCount = 2;
            tlpTenant.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpTenant.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpTenant.Controls.Add(lblCapTenant, 0, 0);
            tlpTenant.Controls.Add(lblTenant, 1, 0);
            tlpTenant.Controls.Add(lblCapContact, 0, 1);
            tlpTenant.Controls.Add(lblContact, 1, 1);
            tlpTenant.Controls.Add(lblCapLeasePeriod, 0, 2);
            tlpTenant.Controls.Add(lblLeasePeriod, 1, 2);
            tlpTenant.Controls.Add(lblCapLeaseRent, 0, 3);
            tlpTenant.Controls.Add(lblLeaseRent, 1, 3);
            tlpTenant.Controls.Add(lblCapDeposit, 0, 4);
            tlpTenant.Controls.Add(lblDeposit, 1, 4);
            tlpTenant.Location = new Point(348, 265);
            tlpTenant.Margin = new Padding(0);
            tlpTenant.Name = "tlpTenant";
            tlpTenant.RowCount = 5;
            tlpTenant.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpTenant.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpTenant.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpTenant.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpTenant.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tlpTenant.Size = new Size(388, 160);
            tlpTenant.TabIndex = 21;
            // 
            // lblCapTenant
            // 
            lblCapTenant.Dock = DockStyle.Fill;
            lblCapTenant.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapTenant.Location = new Point(3, 0);
            lblCapTenant.Name = "lblCapTenant";
            lblCapTenant.Size = new Size(114, 32);
            lblCapTenant.TabIndex = 10;
            lblCapTenant.Text = "Tenant";
            lblCapTenant.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTenant
            // 
            lblTenant.AutoEllipsis = true;
            lblTenant.Dock = DockStyle.Fill;
            lblTenant.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            lblTenant.ForeColor = Color.FromArgb(40, 40, 40);
            lblTenant.Location = new Point(123, 0);
            lblTenant.Name = "lblTenant";
            lblTenant.Size = new Size(262, 32);
            lblTenant.TabIndex = 11;
            lblTenant.Text = "Name";
            lblTenant.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapContact
            // 
            lblCapContact.Dock = DockStyle.Fill;
            lblCapContact.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapContact.Location = new Point(3, 32);
            lblCapContact.Name = "lblCapContact";
            lblCapContact.Size = new Size(114, 32);
            lblCapContact.TabIndex = 12;
            lblCapContact.Text = "Contact no.";
            lblCapContact.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblContact
            // 
            lblContact.AutoEllipsis = true;
            lblContact.Dock = DockStyle.Fill;
            lblContact.Font = new Font("Century Gothic", 10F);
            lblContact.ForeColor = Color.FromArgb(40, 40, 40);
            lblContact.Location = new Point(123, 32);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(262, 32);
            lblContact.TabIndex = 13;
            lblContact.Text = "#";
            lblContact.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapLeasePeriod
            // 
            lblCapLeasePeriod.Dock = DockStyle.Fill;
            lblCapLeasePeriod.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapLeasePeriod.Location = new Point(3, 64);
            lblCapLeasePeriod.Name = "lblCapLeasePeriod";
            lblCapLeasePeriod.Size = new Size(114, 32);
            lblCapLeasePeriod.TabIndex = 14;
            lblCapLeasePeriod.Text = "Lease period";
            lblCapLeasePeriod.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLeasePeriod
            // 
            lblLeasePeriod.AutoEllipsis = true;
            lblLeasePeriod.Dock = DockStyle.Fill;
            lblLeasePeriod.Font = new Font("Century Gothic", 10F);
            lblLeasePeriod.ForeColor = Color.FromArgb(40, 40, 40);
            lblLeasePeriod.Location = new Point(123, 64);
            lblLeasePeriod.Name = "lblLeasePeriod";
            lblLeasePeriod.Size = new Size(262, 32);
            lblLeasePeriod.TabIndex = 15;
            lblLeasePeriod.Text = "mm dd, yyyy to mm dd, yyyy";
            lblLeasePeriod.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapLeaseRent
            // 
            lblCapLeaseRent.Dock = DockStyle.Fill;
            lblCapLeaseRent.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapLeaseRent.Location = new Point(3, 96);
            lblCapLeaseRent.Name = "lblCapLeaseRent";
            lblCapLeaseRent.Size = new Size(114, 32);
            lblCapLeaseRent.TabIndex = 16;
            lblCapLeaseRent.Text = "Monthly rent";
            lblCapLeaseRent.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLeaseRent
            // 
            lblLeaseRent.AutoEllipsis = true;
            lblLeaseRent.Dock = DockStyle.Fill;
            lblLeaseRent.Font = new Font("Century Gothic", 10F);
            lblLeaseRent.ForeColor = Color.FromArgb(40, 40, 40);
            lblLeaseRent.Location = new Point(123, 96);
            lblLeaseRent.Name = "lblLeaseRent";
            lblLeaseRent.Size = new Size(262, 32);
            lblLeaseRent.TabIndex = 17;
            lblLeaseRent.Text = "000.00";
            lblLeaseRent.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapDeposit
            // 
            lblCapDeposit.Dock = DockStyle.Fill;
            lblCapDeposit.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapDeposit.Location = new Point(3, 128);
            lblCapDeposit.Name = "lblCapDeposit";
            lblCapDeposit.Size = new Size(114, 32);
            lblCapDeposit.TabIndex = 18;
            lblCapDeposit.Text = "Deposit";
            lblCapDeposit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDeposit
            // 
            lblDeposit.AutoEllipsis = true;
            lblDeposit.Dock = DockStyle.Fill;
            lblDeposit.Font = new Font("Century Gothic", 10F);
            lblDeposit.ForeColor = Color.FromArgb(40, 40, 40);
            lblDeposit.Location = new Point(123, 128);
            lblDeposit.Name = "lblDeposit";
            lblDeposit.Size = new Size(262, 32);
            lblDeposit.TabIndex = 19;
            lblDeposit.Text = "000.00";
            lblDeposit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSectionUnit
            // 
            lblSectionUnit.AutoSize = true;
            lblSectionUnit.Font = new Font("Century Gothic", 8F, FontStyle.Bold);
            lblSectionUnit.ForeColor = Color.FromArgb(120, 120, 120);
            lblSectionUnit.Location = new Point(348, 24);
            lblSectionUnit.Name = "lblSectionUnit";
            lblSectionUnit.Size = new Size(91, 17);
            lblSectionUnit.TabIndex = 22;
            lblSectionUnit.Text = "UNIT DETAILS";
            // 
            // lblSectionTenant
            // 
            lblSectionTenant.AutoSize = true;
            lblSectionTenant.Font = new Font("Century Gothic", 8F, FontStyle.Bold);
            lblSectionTenant.ForeColor = Color.FromArgb(120, 120, 120);
            lblSectionTenant.Location = new Point(348, 243);
            lblSectionTenant.Name = "lblSectionTenant";
            lblSectionTenant.Size = new Size(120, 17);
            lblSectionTenant.TabIndex = 23;
            lblSectionTenant.Text = "CURRENT TENANT";
            // 
            // pnlDivider
            // 
            pnlDivider.BackColor = Color.FromArgb(220, 222, 224);
            pnlDivider.Location = new Point(348, 216);
            pnlDivider.Name = "pnlDivider";
            pnlDivider.Size = new Size(388, 1);
            pnlDivider.TabIndex = 24;
            // 
            // lblStatusBadge
            // 
            lblStatusBadge.BackColor = Color.FromArgb(232, 245, 233);
            lblStatusBadge.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            lblStatusBadge.ForeColor = Color.FromArgb(46, 125, 50);
            lblStatusBadge.Location = new Point(24, 261);
            lblStatusBadge.Name = "lblStatusBadge";
            lblStatusBadge.Size = new Size(300, 34);
            lblStatusBadge.TabIndex = 25;
            lblStatusBadge.Text = "Status";
            lblStatusBadge.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picUnit
            // 
            picUnit.BackColor = Color.FromArgb(244, 245, 246);
            picUnit.BorderStyle = BorderStyle.FixedSingle;
            picUnit.Controls.Add(lblNoPhoto);
            picUnit.Location = new Point(24, 24);
            picUnit.Name = "picUnit";
            picUnit.Size = new Size(300, 225);
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
            lblNoPhoto.Size = new Size(298, 223);
            lblNoPhoto.TabIndex = 0;
            lblNoPhoto.Text = "No photo yet";
            lblNoPhoto.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pnlBody
            // 
            pnlBody.BackColor = Color.White;
            pnlBody.Controls.Add(picUnit);
            pnlBody.Controls.Add(lblStatusBadge);
            pnlBody.Controls.Add(lblSectionUnit);
            pnlBody.Controls.Add(tlpUnit);
            pnlBody.Controls.Add(pnlDivider);
            pnlBody.Controls.Add(lblSectionTenant);
            pnlBody.Controls.Add(tlpTenant);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 56);
            pnlBody.Margin = new Padding(0);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(760, 474);
            pnlBody.TabIndex = 26;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(244, 245, 246);
            pnlFooter.Controls.Add(btnClose);
            pnlFooter.Controls.Add(btnEditDetails);
            pnlFooter.Controls.Add(btnChangePhoto);
            pnlFooter.Controls.Add(btnRemovePhoto);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 530);
            pnlFooter.Margin = new Padding(0);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(760, 64);
            pnlFooter.TabIndex = 28;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.White;
            btnClose.Cursor = Cursors.Hand;
            btnClose.DialogResult = DialogResult.Cancel;
            btnClose.FlatAppearance.BorderColor = Color.Silver;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.ForeColor = Color.FromArgb(40, 40, 40);
            btnClose.Location = new Point(626, 13);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 38);
            btnClose.TabIndex = 29;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // btnEditDetails
            // 
            btnEditDetails.BackColor = Color.FromArgb(72, 149, 199);
            btnEditDetails.Cursor = Cursors.Hand;
            btnEditDetails.FlatAppearance.BorderSize = 0;
            btnEditDetails.FlatStyle = FlatStyle.Flat;
            btnEditDetails.ForeColor = Color.White;
            btnEditDetails.Location = new Point(24, 13);
            btnEditDetails.Name = "btnEditDetails";
            btnEditDetails.Size = new Size(130, 38);
            btnEditDetails.TabIndex = 30;
            btnEditDetails.Text = "Edit Details";
            btnEditDetails.UseVisualStyleBackColor = false;
            btnEditDetails.Click += btnEditDetails_Click;
            // 
            // btnChangePhoto
            // 
            btnChangePhoto.BackColor = Color.White;
            btnChangePhoto.Cursor = Cursors.Hand;
            btnChangePhoto.FlatAppearance.BorderColor = Color.Silver;
            btnChangePhoto.FlatStyle = FlatStyle.Flat;
            btnChangePhoto.ForeColor = Color.FromArgb(40, 40, 40);
            btnChangePhoto.Location = new Point(166, 13);
            btnChangePhoto.Name = "btnChangePhoto";
            btnChangePhoto.Size = new Size(130, 38);
            btnChangePhoto.TabIndex = 31;
            btnChangePhoto.Text = "Change Photo";
            btnChangePhoto.UseVisualStyleBackColor = false;
            btnChangePhoto.Click += btnChangePhoto_Click;
            // 
            // btnRemovePhoto
            // 
            btnRemovePhoto.BackColor = Color.White;
            btnRemovePhoto.Cursor = Cursors.Hand;
            btnRemovePhoto.FlatAppearance.BorderColor = Color.Silver;
            btnRemovePhoto.FlatStyle = FlatStyle.Flat;
            btnRemovePhoto.ForeColor = Color.FromArgb(40, 40, 40);
            btnRemovePhoto.Location = new Point(308, 13);
            btnRemovePhoto.Name = "btnRemovePhoto";
            btnRemovePhoto.Size = new Size(130, 38);
            btnRemovePhoto.TabIndex = 32;
            btnRemovePhoto.Text = "Remove Photo";
            btnRemovePhoto.UseVisualStyleBackColor = false;
            btnRemovePhoto.Click += btnRemovePhoto_Click;
            // 
            // lblHeader
            // 
            lblHeader.BackColor = Color.FromArgb(72, 149, 199);
            lblHeader.Dock = DockStyle.Top;
            lblHeader.Font = new Font("Century Gothic", 14F, FontStyle.Bold);
            lblHeader.ForeColor = Color.White;
            lblHeader.Location = new Point(0, 0);
            lblHeader.Margin = new Padding(0);
            lblHeader.Name = "lblHeader";
            lblHeader.Padding = new Padding(24, 0, 0, 0);
            lblHeader.Size = new Size(760, 56);
            lblHeader.TabIndex = 27;
            lblHeader.Text = "Unit 101";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // UnitDetailForm
            // 
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(760, 594);
            Controls.Add(pnlBody);
            Controls.Add(pnlFooter);
            Controls.Add(lblHeader);
            Font = new Font("Century Gothic", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UnitDetailForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Unit";
            tlpUnit.ResumeLayout(false);
            tlpTenant.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)picUnit).EndInit();
            picUnit.ResumeLayout(false);
            pnlBody.ResumeLayout(false);
            pnlBody.PerformLayout();
            pnlFooter.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpUnit;
        private Label lblCapUnitNo;
        private Label lblUnitNo;
        private Label lblCapFloor;
        private Label lblFloor;
        private Label lblCapType;
        private Label lblType;
        private Label lblCapBaseRent;
        private Label lblBaseRent;
        private Label lblCapOpenRequests;
        private Label lblOpenRequests;
        private TableLayoutPanel tlpTenant;
        private Label lblCapTenant;
        private Label lblTenant;
        private Label lblCapContact;
        private Label lblContact;
        private Label lblCapLeasePeriod;
        private Label lblLeasePeriod;
        private Label lblCapLeaseRent;
        private Label lblLeaseRent;
        private Label lblCapDeposit;
        private Label lblDeposit;
        private Label lblSectionUnit;
        private Label lblSectionTenant;
        private Panel pnlDivider;
        private Label lblStatusBadge;
        private PictureBox picUnit;
        private Label lblNoPhoto;
        private Panel pnlBody;
        private Panel pnlFooter;
        private Label lblHeader;
        private Button btnClose;
        private Button btnEditDetails;
        private Button btnChangePhoto;
        private Button btnRemovePhoto;
    }
}
