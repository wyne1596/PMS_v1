namespace PMS_v1.Pages
{
    partial class MaintenanceDetailForm
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
            statusTracker = new PMS_v1.UserControls.StatusTracker();
            pnlBody = new Panel();
            tlpDetails = new TableLayoutPanel();
            lblCapUnit = new Label();
            lblUnit = new Label();
            lblCapReportedBy = new Label();
            lblReportedBy = new Label();
            lblCapAssignedTo = new Label();
            lblAssignedTo = new Label();
            lblCapType = new Label();
            lblType = new Label();
            lblCapPriority = new Label();
            lblPriority = new Label();
            lblCapDateReported = new Label();
            lblDateReported = new Label();
            lblCapDateCompleted = new Label();
            lblDateCompleted = new Label();
            lblCapCost = new Label();
            lblCost = new Label();
            lblCapLastUpdated = new Label();
            lblLastUpdated = new Label();
            lblCapProblem = new Label();
            lblProblem = new Label();
            lblCapRepairDetails = new Label();
            lblRepairDetails = new Label();
            pnlFooter = new FlowLayoutPanel();
            btnClose = new Button();
            tlpRoot.SuspendLayout();
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
            tlpRoot.Controls.Add(statusTracker, 0, 1);
            tlpRoot.Controls.Add(pnlBody, 0, 2);
            tlpRoot.Controls.Add(pnlFooter, 0, 3);
            tlpRoot.Dock = DockStyle.Fill;
            tlpRoot.Location = new Point(0, 0);
            tlpRoot.Margin = new Padding(0);
            tlpRoot.Name = "tlpRoot";
            tlpRoot.RowCount = 4;
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 56F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpRoot.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            tlpRoot.Size = new Size(540, 660);
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
            lblHeader.Text = "Request";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // statusTracker
            // 
            statusTracker.BackColor = Color.White;
            statusTracker.Dock = DockStyle.Fill;
            statusTracker.Location = new Point(0, 56);
            statusTracker.Margin = new Padding(0);
            statusTracker.Name = "statusTracker";
            statusTracker.Size = new Size(540, 96);
            statusTracker.TabIndex = 1;
            // 
            // pnlBody
            // 
            pnlBody.AutoScroll = true;
            pnlBody.Controls.Add(tlpDetails);
            pnlBody.Dock = DockStyle.Fill;
            pnlBody.Location = new Point(0, 152);
            pnlBody.Margin = new Padding(0);
            pnlBody.Name = "pnlBody";
            pnlBody.Size = new Size(540, 444);
            pnlBody.TabIndex = 2;
            // 
            // tlpDetails
            // 
            tlpDetails.AutoSize = true;
            tlpDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpDetails.ColumnCount = 2;
            tlpDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            tlpDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 350F));
            tlpDetails.Controls.Add(lblCapUnit, 0, 0);
            tlpDetails.Controls.Add(lblUnit, 1, 0);
            tlpDetails.Controls.Add(lblCapReportedBy, 0, 1);
            tlpDetails.Controls.Add(lblReportedBy, 1, 1);
            tlpDetails.Controls.Add(lblCapAssignedTo, 0, 2);
            tlpDetails.Controls.Add(lblAssignedTo, 1, 2);
            tlpDetails.Controls.Add(lblCapType, 0, 3);
            tlpDetails.Controls.Add(lblType, 1, 3);
            tlpDetails.Controls.Add(lblCapPriority, 0, 4);
            tlpDetails.Controls.Add(lblPriority, 1, 4);
            tlpDetails.Controls.Add(lblCapDateReported, 0, 5);
            tlpDetails.Controls.Add(lblDateReported, 1, 5);
            tlpDetails.Controls.Add(lblCapDateCompleted, 0, 6);
            tlpDetails.Controls.Add(lblDateCompleted, 1, 6);
            tlpDetails.Controls.Add(lblCapCost, 0, 7);
            tlpDetails.Controls.Add(lblCost, 1, 7);
            tlpDetails.Controls.Add(lblCapLastUpdated, 0, 8);
            tlpDetails.Controls.Add(lblLastUpdated, 1, 8);
            tlpDetails.Controls.Add(lblCapProblem, 0, 9);
            tlpDetails.Controls.Add(lblProblem, 1, 9);
            tlpDetails.Controls.Add(lblCapRepairDetails, 0, 10);
            tlpDetails.Controls.Add(lblRepairDetails, 1, 10);
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
            tlpDetails.Size = new Size(540, 420);
            tlpDetails.TabIndex = 0;
            // 
            // lblCapUnit
            // 
            lblCapUnit.AutoSize = true;
            lblCapUnit.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapUnit.Location = new Point(24, 15);
            lblCapUnit.Margin = new Padding(0, 7, 8, 7);
            lblCapUnit.Name = "lblCapUnit";
            lblCapUnit.Size = new Size(60, 17);
            lblCapUnit.TabIndex = 0;
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
            lblUnit.TabIndex = 1;
            lblUnit.Text = "-";
            // 
            // lblCapReportedBy
            // 
            lblCapReportedBy.AutoSize = true;
            lblCapReportedBy.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapReportedBy.Location = new Point(24, 15);
            lblCapReportedBy.Margin = new Padding(0, 7, 8, 7);
            lblCapReportedBy.Name = "lblCapReportedBy";
            lblCapReportedBy.Size = new Size(60, 17);
            lblCapReportedBy.TabIndex = 2;
            lblCapReportedBy.Text = "Reported by";
            // 
            // lblReportedBy
            // 
            lblReportedBy.AutoSize = true;
            lblReportedBy.ForeColor = Color.FromArgb(44, 49, 53);
            lblReportedBy.Location = new Point(154, 15);
            lblReportedBy.Margin = new Padding(0, 7, 0, 7);
            lblReportedBy.MaximumSize = new Size(340, 0);
            lblReportedBy.Name = "lblReportedBy";
            lblReportedBy.Size = new Size(10, 17);
            lblReportedBy.TabIndex = 3;
            lblReportedBy.Text = "-";
            // 
            // lblCapAssignedTo
            // 
            lblCapAssignedTo.AutoSize = true;
            lblCapAssignedTo.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapAssignedTo.Location = new Point(24, 15);
            lblCapAssignedTo.Margin = new Padding(0, 7, 8, 7);
            lblCapAssignedTo.Name = "lblCapAssignedTo";
            lblCapAssignedTo.Size = new Size(60, 17);
            lblCapAssignedTo.TabIndex = 4;
            lblCapAssignedTo.Text = "Assigned to";
            // 
            // lblAssignedTo
            // 
            lblAssignedTo.AutoSize = true;
            lblAssignedTo.ForeColor = Color.FromArgb(44, 49, 53);
            lblAssignedTo.Location = new Point(154, 15);
            lblAssignedTo.Margin = new Padding(0, 7, 0, 7);
            lblAssignedTo.MaximumSize = new Size(340, 0);
            lblAssignedTo.Name = "lblAssignedTo";
            lblAssignedTo.Size = new Size(10, 17);
            lblAssignedTo.TabIndex = 5;
            lblAssignedTo.Text = "-";
            // 
            // lblCapType
            // 
            lblCapType.AutoSize = true;
            lblCapType.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapType.Location = new Point(24, 15);
            lblCapType.Margin = new Padding(0, 7, 8, 7);
            lblCapType.Name = "lblCapType";
            lblCapType.Size = new Size(60, 17);
            lblCapType.TabIndex = 6;
            lblCapType.Text = "Type";
            // 
            // lblType
            // 
            lblType.AutoSize = true;
            lblType.ForeColor = Color.FromArgb(44, 49, 53);
            lblType.Location = new Point(154, 15);
            lblType.Margin = new Padding(0, 7, 0, 7);
            lblType.MaximumSize = new Size(340, 0);
            lblType.Name = "lblType";
            lblType.Size = new Size(10, 17);
            lblType.TabIndex = 7;
            lblType.Text = "-";
            // 
            // lblCapPriority
            // 
            lblCapPriority.AutoSize = true;
            lblCapPriority.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapPriority.Location = new Point(24, 15);
            lblCapPriority.Margin = new Padding(0, 7, 8, 7);
            lblCapPriority.Name = "lblCapPriority";
            lblCapPriority.Size = new Size(60, 17);
            lblCapPriority.TabIndex = 8;
            lblCapPriority.Text = "Priority";
            // 
            // lblPriority
            // 
            lblPriority.AutoSize = true;
            lblPriority.ForeColor = Color.FromArgb(44, 49, 53);
            lblPriority.Location = new Point(154, 15);
            lblPriority.Margin = new Padding(0, 7, 0, 7);
            lblPriority.MaximumSize = new Size(340, 0);
            lblPriority.Name = "lblPriority";
            lblPriority.Size = new Size(10, 17);
            lblPriority.TabIndex = 9;
            lblPriority.Text = "-";
            // 
            // lblCapDateReported
            // 
            lblCapDateReported.AutoSize = true;
            lblCapDateReported.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapDateReported.Location = new Point(24, 15);
            lblCapDateReported.Margin = new Padding(0, 7, 8, 7);
            lblCapDateReported.Name = "lblCapDateReported";
            lblCapDateReported.Size = new Size(60, 17);
            lblCapDateReported.TabIndex = 10;
            lblCapDateReported.Text = "Date reported";
            // 
            // lblDateReported
            // 
            lblDateReported.AutoSize = true;
            lblDateReported.ForeColor = Color.FromArgb(44, 49, 53);
            lblDateReported.Location = new Point(154, 15);
            lblDateReported.Margin = new Padding(0, 7, 0, 7);
            lblDateReported.MaximumSize = new Size(340, 0);
            lblDateReported.Name = "lblDateReported";
            lblDateReported.Size = new Size(10, 17);
            lblDateReported.TabIndex = 11;
            lblDateReported.Text = "-";
            // 
            // lblCapDateCompleted
            // 
            lblCapDateCompleted.AutoSize = true;
            lblCapDateCompleted.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapDateCompleted.Location = new Point(24, 15);
            lblCapDateCompleted.Margin = new Padding(0, 7, 8, 7);
            lblCapDateCompleted.Name = "lblCapDateCompleted";
            lblCapDateCompleted.Size = new Size(60, 17);
            lblCapDateCompleted.TabIndex = 12;
            lblCapDateCompleted.Text = "Date completed";
            // 
            // lblDateCompleted
            // 
            lblDateCompleted.AutoSize = true;
            lblDateCompleted.ForeColor = Color.FromArgb(44, 49, 53);
            lblDateCompleted.Location = new Point(154, 15);
            lblDateCompleted.Margin = new Padding(0, 7, 0, 7);
            lblDateCompleted.MaximumSize = new Size(340, 0);
            lblDateCompleted.Name = "lblDateCompleted";
            lblDateCompleted.Size = new Size(10, 17);
            lblDateCompleted.TabIndex = 13;
            lblDateCompleted.Text = "-";
            // 
            // lblCapCost
            // 
            lblCapCost.AutoSize = true;
            lblCapCost.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapCost.Location = new Point(24, 15);
            lblCapCost.Margin = new Padding(0, 7, 8, 7);
            lblCapCost.Name = "lblCapCost";
            lblCapCost.Size = new Size(60, 17);
            lblCapCost.TabIndex = 14;
            lblCapCost.Text = "Cost";
            // 
            // lblCost
            // 
            lblCost.AutoSize = true;
            lblCost.ForeColor = Color.FromArgb(44, 49, 53);
            lblCost.Location = new Point(154, 15);
            lblCost.Margin = new Padding(0, 7, 0, 7);
            lblCost.MaximumSize = new Size(340, 0);
            lblCost.Name = "lblCost";
            lblCost.Size = new Size(10, 17);
            lblCost.TabIndex = 15;
            lblCost.Text = "-";
            // 
            // lblCapLastUpdated
            // 
            lblCapLastUpdated.AutoSize = true;
            lblCapLastUpdated.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapLastUpdated.Location = new Point(24, 15);
            lblCapLastUpdated.Margin = new Padding(0, 7, 8, 7);
            lblCapLastUpdated.Name = "lblCapLastUpdated";
            lblCapLastUpdated.Size = new Size(60, 17);
            lblCapLastUpdated.TabIndex = 16;
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
            lblLastUpdated.TabIndex = 17;
            lblLastUpdated.Text = "-";
            // 
            // lblCapProblem
            // 
            lblCapProblem.AutoSize = true;
            lblCapProblem.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapProblem.Location = new Point(24, 15);
            lblCapProblem.Margin = new Padding(0, 7, 8, 7);
            lblCapProblem.Name = "lblCapProblem";
            lblCapProblem.Size = new Size(60, 17);
            lblCapProblem.TabIndex = 18;
            lblCapProblem.Text = "Problem";
            // 
            // lblProblem
            // 
            lblProblem.AutoSize = true;
            lblProblem.ForeColor = Color.FromArgb(44, 49, 53);
            lblProblem.Location = new Point(154, 15);
            lblProblem.Margin = new Padding(0, 7, 0, 7);
            lblProblem.MaximumSize = new Size(340, 0);
            lblProblem.Name = "lblProblem";
            lblProblem.Size = new Size(10, 17);
            lblProblem.TabIndex = 19;
            lblProblem.Text = "-";
            // 
            // lblCapRepairDetails
            // 
            lblCapRepairDetails.AutoSize = true;
            lblCapRepairDetails.ForeColor = Color.FromArgb(108, 117, 125);
            lblCapRepairDetails.Location = new Point(24, 15);
            lblCapRepairDetails.Margin = new Padding(0, 7, 8, 7);
            lblCapRepairDetails.Name = "lblCapRepairDetails";
            lblCapRepairDetails.Size = new Size(60, 17);
            lblCapRepairDetails.TabIndex = 20;
            lblCapRepairDetails.Text = "Repair details";
            // 
            // lblRepairDetails
            // 
            lblRepairDetails.AutoSize = true;
            lblRepairDetails.ForeColor = Color.FromArgb(44, 49, 53);
            lblRepairDetails.Location = new Point(154, 15);
            lblRepairDetails.Margin = new Padding(0, 7, 0, 7);
            lblRepairDetails.MaximumSize = new Size(340, 0);
            lblRepairDetails.Name = "lblRepairDetails";
            lblRepairDetails.Size = new Size(10, 17);
            lblRepairDetails.TabIndex = 21;
            lblRepairDetails.Text = "-";
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(244, 245, 246);
            pnlFooter.Controls.Add(btnClose);
            pnlFooter.Dock = DockStyle.Fill;
            pnlFooter.FlowDirection = FlowDirection.RightToLeft;
            pnlFooter.Location = new Point(0, 596);
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
            // MaintenanceDetailForm
            // 
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(540, 660);
            Controls.Add(tlpRoot);
            Font = new Font("Century Gothic", 9.5F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "MaintenanceDetailForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Request";
            tlpRoot.ResumeLayout(false);
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
        private PMS_v1.UserControls.StatusTracker statusTracker;
        private Panel pnlBody;
        private TableLayoutPanel tlpDetails;
        private Label lblCapUnit;
        private Label lblUnit;
        private Label lblCapReportedBy;
        private Label lblReportedBy;
        private Label lblCapAssignedTo;
        private Label lblAssignedTo;
        private Label lblCapType;
        private Label lblType;
        private Label lblCapPriority;
        private Label lblPriority;
        private Label lblCapDateReported;
        private Label lblDateReported;
        private Label lblCapDateCompleted;
        private Label lblDateCompleted;
        private Label lblCapCost;
        private Label lblCost;
        private Label lblCapLastUpdated;
        private Label lblLastUpdated;
        private Label lblCapProblem;
        private Label lblProblem;
        private Label lblCapRepairDetails;
        private Label lblRepairDetails;
        private FlowLayoutPanel pnlFooter;
        private Button btnClose;
    }
}