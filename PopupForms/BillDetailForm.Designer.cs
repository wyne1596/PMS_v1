namespace PMS_v1.Pages
{
    partial class BillDetailForm
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
            lblCapTenant = new Label();
            lblTenant = new Label();
            lblCapUnit = new Label();
            lblUnit = new Label();
            lblCapBillType = new Label();
            lblBillType = new Label();
            lblCapBillDate = new Label();
            lblBillDate = new Label();
            lblCapDueDate = new Label();
            lblDueDate = new Label();
            pnlDivider1 = new Panel();
            lblCapAmount = new Label();
            lblAmount = new Label();
            lblCapPaid = new Label();
            lblPaid = new Label();
            lblCapBalance = new Label();
            lblBalance = new Label();
            pnlDivider2 = new Panel();
            lblCapStatus = new Label();
            lblStatus = new Label();
            lblCapLastPayment = new Label();
            lblLastPayment = new Label();
            lblCapRefNo = new Label();
            lblRefNo = new Label();
            lblHeader = new Label();
            pnlFooter = new Panel();
            btnClose = new Button();
            tlpBill = new TableLayoutPanel();
            pnlFooter.SuspendLayout();
            tlpBill.SuspendLayout();
            SuspendLayout();
            // 
            // lblCapTenant
            // 
            lblCapTenant.Dock = DockStyle.Fill;
            lblCapTenant.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapTenant.Location = new Point(27, 12);
            lblCapTenant.Name = "lblCapTenant";
            lblCapTenant.Size = new Size(134, 36);
            lblCapTenant.TabIndex = 0;
            lblCapTenant.Text = "Billed to";
            lblCapTenant.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTenant
            // 
            lblTenant.AutoEllipsis = true;
            lblTenant.Dock = DockStyle.Fill;
            lblTenant.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            lblTenant.ForeColor = Color.FromArgb(40, 40, 40);
            lblTenant.Location = new Point(167, 12);
            lblTenant.Name = "lblTenant";
            lblTenant.Size = new Size(266, 36);
            lblTenant.TabIndex = 1;
            lblTenant.Text = "Name";
            lblTenant.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapUnit
            // 
            lblCapUnit.Dock = DockStyle.Fill;
            lblCapUnit.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapUnit.Location = new Point(27, 48);
            lblCapUnit.Name = "lblCapUnit";
            lblCapUnit.Size = new Size(134, 36);
            lblCapUnit.TabIndex = 2;
            lblCapUnit.Text = "Unit";
            lblCapUnit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblUnit
            // 
            lblUnit.AutoEllipsis = true;
            lblUnit.Dock = DockStyle.Fill;
            lblUnit.Font = new Font("Century Gothic", 10F);
            lblUnit.ForeColor = Color.FromArgb(40, 40, 40);
            lblUnit.Location = new Point(167, 48);
            lblUnit.Name = "lblUnit";
            lblUnit.Size = new Size(266, 36);
            lblUnit.TabIndex = 3;
            lblUnit.Text = "000";
            lblUnit.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapBillType
            // 
            lblCapBillType.Dock = DockStyle.Fill;
            lblCapBillType.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapBillType.Location = new Point(27, 84);
            lblCapBillType.Name = "lblCapBillType";
            lblCapBillType.Size = new Size(134, 36);
            lblCapBillType.TabIndex = 4;
            lblCapBillType.Text = "Bill type";
            lblCapBillType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBillType
            // 
            lblBillType.AutoEllipsis = true;
            lblBillType.Dock = DockStyle.Fill;
            lblBillType.Font = new Font("Century Gothic", 10F);
            lblBillType.ForeColor = Color.FromArgb(40, 40, 40);
            lblBillType.Location = new Point(167, 84);
            lblBillType.Name = "lblBillType";
            lblBillType.Size = new Size(266, 36);
            lblBillType.TabIndex = 5;
            lblBillType.Text = "Rent";
            lblBillType.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapBillDate
            // 
            lblCapBillDate.Dock = DockStyle.Fill;
            lblCapBillDate.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapBillDate.Location = new Point(27, 120);
            lblCapBillDate.Name = "lblCapBillDate";
            lblCapBillDate.Size = new Size(134, 36);
            lblCapBillDate.TabIndex = 6;
            lblCapBillDate.Text = "Bill date";
            lblCapBillDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBillDate
            // 
            lblBillDate.AutoEllipsis = true;
            lblBillDate.Dock = DockStyle.Fill;
            lblBillDate.Font = new Font("Century Gothic", 10F);
            lblBillDate.ForeColor = Color.FromArgb(40, 40, 40);
            lblBillDate.Location = new Point(167, 120);
            lblBillDate.Name = "lblBillDate";
            lblBillDate.Size = new Size(266, 36);
            lblBillDate.TabIndex = 7;
            lblBillDate.Text = "MM dd, yyyy";
            lblBillDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapDueDate
            // 
            lblCapDueDate.Dock = DockStyle.Fill;
            lblCapDueDate.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapDueDate.Location = new Point(27, 156);
            lblCapDueDate.Name = "lblCapDueDate";
            lblCapDueDate.Size = new Size(134, 36);
            lblCapDueDate.TabIndex = 8;
            lblCapDueDate.Text = "Due date";
            lblCapDueDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblDueDate
            // 
            lblDueDate.AutoEllipsis = true;
            lblDueDate.Dock = DockStyle.Fill;
            lblDueDate.Font = new Font("Century Gothic", 10F);
            lblDueDate.ForeColor = Color.FromArgb(40, 40, 40);
            lblDueDate.Location = new Point(167, 156);
            lblDueDate.Name = "lblDueDate";
            lblDueDate.Size = new Size(266, 36);
            lblDueDate.TabIndex = 9;
            lblDueDate.Text = "MM dd, yyyy";
            lblDueDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlDivider1
            // 
            pnlDivider1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pnlDivider1.BackColor = Color.FromArgb(220, 222, 224);
            tlpBill.SetColumnSpan(pnlDivider1, 2);
            pnlDivider1.Location = new Point(27, 200);
            pnlDivider1.Margin = new Padding(3, 0, 3, 0);
            pnlDivider1.Name = "pnlDivider1";
            pnlDivider1.Size = new Size(406, 1);
            pnlDivider1.TabIndex = 10;
            // 
            // lblCapAmount
            // 
            lblCapAmount.Dock = DockStyle.Fill;
            lblCapAmount.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapAmount.Location = new Point(27, 210);
            lblCapAmount.Name = "lblCapAmount";
            lblCapAmount.Size = new Size(134, 36);
            lblCapAmount.TabIndex = 11;
            lblCapAmount.Text = "Amount";
            lblCapAmount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAmount
            // 
            lblAmount.AutoEllipsis = true;
            lblAmount.Dock = DockStyle.Fill;
            lblAmount.Font = new Font("Century Gothic", 10F);
            lblAmount.ForeColor = Color.FromArgb(40, 40, 40);
            lblAmount.Location = new Point(167, 210);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(266, 36);
            lblAmount.TabIndex = 12;
            lblAmount.Text = "000.00";
            lblAmount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapPaid
            // 
            lblCapPaid.Dock = DockStyle.Fill;
            lblCapPaid.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapPaid.Location = new Point(27, 246);
            lblCapPaid.Name = "lblCapPaid";
            lblCapPaid.Size = new Size(134, 36);
            lblCapPaid.TabIndex = 13;
            lblCapPaid.Text = "Amount paid";
            lblCapPaid.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPaid
            // 
            lblPaid.AutoEllipsis = true;
            lblPaid.Dock = DockStyle.Fill;
            lblPaid.Font = new Font("Century Gothic", 10F);
            lblPaid.ForeColor = Color.FromArgb(40, 40, 40);
            lblPaid.Location = new Point(167, 246);
            lblPaid.Name = "lblPaid";
            lblPaid.Size = new Size(266, 36);
            lblPaid.TabIndex = 14;
            lblPaid.Text = "000.00";
            lblPaid.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapBalance
            // 
            lblCapBalance.Dock = DockStyle.Fill;
            lblCapBalance.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapBalance.Location = new Point(27, 282);
            lblCapBalance.Name = "lblCapBalance";
            lblCapBalance.Size = new Size(134, 36);
            lblCapBalance.TabIndex = 15;
            lblCapBalance.Text = "Balance due";
            lblCapBalance.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblBalance
            // 
            lblBalance.AutoEllipsis = true;
            lblBalance.Dock = DockStyle.Fill;
            lblBalance.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblBalance.ForeColor = Color.FromArgb(72, 149, 199);
            lblBalance.Location = new Point(167, 282);
            lblBalance.Name = "lblBalance";
            lblBalance.Size = new Size(266, 36);
            lblBalance.TabIndex = 16;
            lblBalance.Text = "000.00";
            lblBalance.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlDivider2
            // 
            pnlDivider2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            pnlDivider2.BackColor = Color.FromArgb(220, 222, 224);
            tlpBill.SetColumnSpan(pnlDivider2, 2);
            pnlDivider2.Location = new Point(27, 326);
            pnlDivider2.Margin = new Padding(3, 0, 3, 0);
            pnlDivider2.Name = "pnlDivider2";
            pnlDivider2.Size = new Size(406, 1);
            pnlDivider2.TabIndex = 17;
            // 
            // lblCapStatus
            // 
            lblCapStatus.Dock = DockStyle.Fill;
            lblCapStatus.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapStatus.Location = new Point(27, 336);
            lblCapStatus.Name = "lblCapStatus";
            lblCapStatus.Size = new Size(134, 36);
            lblCapStatus.TabIndex = 18;
            lblCapStatus.Text = "Status";
            lblCapStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            lblStatus.AutoEllipsis = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(198, 40, 40);
            lblStatus.Location = new Point(167, 336);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(266, 36);
            lblStatus.TabIndex = 19;
            lblStatus.Text = "status";
            lblStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapLastPayment
            // 
            lblCapLastPayment.Dock = DockStyle.Fill;
            lblCapLastPayment.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapLastPayment.Location = new Point(27, 372);
            lblCapLastPayment.Name = "lblCapLastPayment";
            lblCapLastPayment.Size = new Size(134, 36);
            lblCapLastPayment.TabIndex = 20;
            lblCapLastPayment.Text = "Last payment";
            lblCapLastPayment.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLastPayment
            // 
            lblLastPayment.AutoEllipsis = true;
            lblLastPayment.Dock = DockStyle.Fill;
            lblLastPayment.Font = new Font("Century Gothic", 10F);
            lblLastPayment.ForeColor = Color.FromArgb(40, 40, 40);
            lblLastPayment.Location = new Point(167, 372);
            lblLastPayment.Name = "lblLastPayment";
            lblLastPayment.Size = new Size(266, 36);
            lblLastPayment.TabIndex = 21;
            lblLastPayment.Text = "Date - Mode";
            lblLastPayment.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblCapRefNo
            // 
            lblCapRefNo.Dock = DockStyle.Fill;
            lblCapRefNo.ForeColor = Color.FromArgb(120, 120, 120);
            lblCapRefNo.Location = new Point(27, 408);
            lblCapRefNo.Name = "lblCapRefNo";
            lblCapRefNo.Size = new Size(134, 52);
            lblCapRefNo.TabIndex = 22;
            lblCapRefNo.Text = "Reference no.";
            lblCapRefNo.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblRefNo
            // 
            lblRefNo.AutoEllipsis = true;
            lblRefNo.Dock = DockStyle.Fill;
            lblRefNo.Font = new Font("Century Gothic", 10F);
            lblRefNo.ForeColor = Color.FromArgb(40, 40, 40);
            lblRefNo.Location = new Point(167, 408);
            lblRefNo.Name = "lblRefNo";
            lblRefNo.Size = new Size(266, 52);
            lblRefNo.TabIndex = 23;
            lblRefNo.Text = "Ref no.";
            lblRefNo.TextAlign = ContentAlignment.MiddleLeft;
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
            lblHeader.Size = new Size(460, 56);
            lblHeader.TabIndex = 25;
            lblHeader.Text = "Bill B-0002";
            lblHeader.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlFooter
            // 
            pnlFooter.BackColor = Color.FromArgb(244, 245, 246);
            pnlFooter.Controls.Add(btnClose);
            pnlFooter.Dock = DockStyle.Bottom;
            pnlFooter.Location = new Point(0, 516);
            pnlFooter.Margin = new Padding(0);
            pnlFooter.Name = "pnlFooter";
            pnlFooter.Size = new Size(460, 64);
            pnlFooter.TabIndex = 26;
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
            btnClose.Location = new Point(326, 13);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 38);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            // 
            // tlpBill
            // 
            tlpBill.ColumnCount = 2;
            tlpBill.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 140F));
            tlpBill.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpBill.Controls.Add(lblCapTenant, 0, 0);
            tlpBill.Controls.Add(lblTenant, 1, 0);
            tlpBill.Controls.Add(lblCapUnit, 0, 1);
            tlpBill.Controls.Add(lblUnit, 1, 1);
            tlpBill.Controls.Add(lblCapBillType, 0, 2);
            tlpBill.Controls.Add(lblBillType, 1, 2);
            tlpBill.Controls.Add(lblCapBillDate, 0, 3);
            tlpBill.Controls.Add(lblBillDate, 1, 3);
            tlpBill.Controls.Add(lblCapDueDate, 0, 4);
            tlpBill.Controls.Add(lblDueDate, 1, 4);
            tlpBill.Controls.Add(pnlDivider1, 0, 5);
            tlpBill.Controls.Add(lblCapAmount, 0, 6);
            tlpBill.Controls.Add(lblAmount, 1, 6);
            tlpBill.Controls.Add(lblCapPaid, 0, 7);
            tlpBill.Controls.Add(lblPaid, 1, 7);
            tlpBill.Controls.Add(lblCapBalance, 0, 8);
            tlpBill.Controls.Add(lblBalance, 1, 8);
            tlpBill.Controls.Add(pnlDivider2, 0, 9);
            tlpBill.Controls.Add(lblCapStatus, 0, 10);
            tlpBill.Controls.Add(lblStatus, 1, 10);
            tlpBill.Controls.Add(lblCapLastPayment, 0, 11);
            tlpBill.Controls.Add(lblLastPayment, 1, 11);
            tlpBill.Controls.Add(lblCapRefNo, 0, 12);
            tlpBill.Controls.Add(lblRefNo, 1, 12);
            tlpBill.Dock = DockStyle.Fill;
            tlpBill.Location = new Point(0, 56);
            tlpBill.Margin = new Padding(0);
            tlpBill.Name = "tlpBill";
            tlpBill.Padding = new Padding(24, 12, 24, 0);
            tlpBill.RowCount = 13;
            tlpBill.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlpBill.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlpBill.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlpBill.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlpBill.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlpBill.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
            tlpBill.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlpBill.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlpBill.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlpBill.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));
            tlpBill.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlpBill.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlpBill.RowStyles.Add(new RowStyle(SizeType.Absolute, 36F));
            tlpBill.Size = new Size(460, 460);
            tlpBill.TabIndex = 24;
            // 
            // BillPrintForm
            // 
            AcceptButton = btnClose;
            AutoScaleDimensions = new SizeF(120F, 120F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = Color.White;
            CancelButton = btnClose;
            ClientSize = new Size(460, 580);
            Controls.Add(tlpBill);
            Controls.Add(pnlFooter);
            Controls.Add(lblHeader);
            Font = new Font("Century Gothic", 10F);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "BillPrintForm";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Bill";
            pnlFooter.ResumeLayout(false);
            tlpBill.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblCapTenant;
        private Label lblTenant;
        private Label lblCapUnit;
        private Label lblUnit;
        private Label lblCapBillType;
        private Label lblBillType;
        private Label lblCapBillDate;
        private Label lblBillDate;
        private Label lblCapDueDate;
        private Label lblDueDate;
        private Panel pnlDivider1;
        private Label lblCapAmount;
        private Label lblAmount;
        private Label lblCapPaid;
        private Label lblPaid;
        private Label lblCapBalance;
        private Label lblBalance;
        private Panel pnlDivider2;
        private Label lblCapStatus;
        private Label lblStatus;
        private Label lblCapLastPayment;
        private Label lblLastPayment;
        private Label lblCapRefNo;
        private Label lblRefNo;
        private Label lblHeader;
        private Panel pnlFooter;
        private Button btnClose;
        private TableLayoutPanel tlpBill;
    }
}
