namespace PMS_v1.Pages
{
    partial class SettingsModule
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            tlpMain = new TableLayoutPanel();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblBreadcrumb = new Label();
            tlpBody = new TableLayoutPanel();
            tlpLeft = new TableLayoutPanel();
            pnlPersonnelCard = new RoundedPanel();
            dgvPersonnel = new DataGridView();
            pnlPersonnelTools = new Panel();
            txtSearch = new Krypton.Toolkit.KryptonTextBox();
            cmbFilter = new Krypton.Toolkit.KryptonComboBox();
            lblPersonnelTitle = new Label();
            pnlAdminsCard = new RoundedPanel();
            dgvAdmins = new DataGridView();
            lblAdminsTitle = new Label();
            pnlEditorCard = new RoundedPanel();
            pnlEditorScroll = new Panel();
            tlpEditor = new TableLayoutPanel();
            lblEmployeeTitle = new Label();
            tlpEmployee = new TableLayoutPanel();
            lblEmpNo = new Label();
            lblEmpStatus = new Label();
            pnlEmpNo = new Panel();
            txtEmployeeNo = new Krypton.Toolkit.KryptonTextBox();
            btnGenerate = new Krypton.Toolkit.KryptonButton();
            cmbEmploymentStatus = new Krypton.Toolkit.KryptonComboBox();
            lblFirstName = new Label();
            lblLastName = new Label();
            txtFirstName = new Krypton.Toolkit.KryptonTextBox();
            txtLastName = new Krypton.Toolkit.KryptonTextBox();
            lblPosition = new Label();
            lblContact = new Label();
            txtPosition = new Krypton.Toolkit.KryptonTextBox();
            txtContact = new Krypton.Toolkit.KryptonTextBox();
            lblEmail = new Label();
            txtEmail = new Krypton.Toolkit.KryptonTextBox();
            flpEmployeeButtons = new FlowLayoutPanel();
            btnSaveEmployee = new Krypton.Toolkit.KryptonButton();
            btnNewEmployee = new Krypton.Toolkit.KryptonButton();
            lblAccountTitle = new Label();
            lblAccountHint = new Label();
            tlpAccount = new TableLayoutPanel();
            lblUsername = new Label();
            lblAccountStatus = new Label();
            txtUsername = new Krypton.Toolkit.KryptonTextBox();
            cmbAccountStatus = new Krypton.Toolkit.KryptonComboBox();
            lblRole = new Label();
            lblNewPassword = new Label();
            cmbRole = new Krypton.Toolkit.KryptonComboBox();
            txtNewPassword = new Krypton.Toolkit.KryptonTextBox();
            lblConfirmPassword = new Label();
            lblLastLoginCaption = new Label();
            txtConfirmPassword = new Krypton.Toolkit.KryptonTextBox();
            lblLastLogin = new Label();
            flpAccountButtons = new FlowLayoutPanel();
            btnSaveAccount = new Krypton.Toolkit.KryptonButton();
            btnDeleteAccount = new Krypton.Toolkit.KryptonButton();
            tlpMain.SuspendLayout();
            pnlHeader.SuspendLayout();
            tlpBody.SuspendLayout();
            tlpLeft.SuspendLayout();
            pnlPersonnelCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPersonnel).BeginInit();
            pnlPersonnelTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilter).BeginInit();
            pnlAdminsCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAdmins).BeginInit();
            pnlEditorCard.SuspendLayout();
            pnlEditorScroll.SuspendLayout();
            tlpEditor.SuspendLayout();
            tlpEmployee.SuspendLayout();
            pnlEmpNo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbEmploymentStatus).BeginInit();
            flpEmployeeButtons.SuspendLayout();
            tlpAccount.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbAccountStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbRole).BeginInit();
            flpAccountButtons.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(pnlHeader, 0, 0);
            tlpMain.Controls.Add(tlpBody, 0, 1);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 2;
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.Size = new Size(1314, 1251);
            tlpMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.AutoSize = true;
            pnlHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblBreadcrumb);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Location = new Point(3, 3);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15, 0, 0, 0);
            pnlHeader.Size = new Size(1308, 68);
            pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(15, 31);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(128, 37);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Settings";
            // 
            // lblBreadcrumb
            // 
            lblBreadcrumb.AutoSize = true;
            lblBreadcrumb.Dock = DockStyle.Top;
            lblBreadcrumb.Font = new Font("Century Gothic", 8.5F);
            lblBreadcrumb.ForeColor = Color.FromArgb(108, 117, 125);
            lblBreadcrumb.Location = new Point(15, 0);
            lblBreadcrumb.Name = "lblBreadcrumb";
            lblBreadcrumb.Padding = new Padding(3, 0, 0, 11);
            lblBreadcrumb.Size = new Size(125, 31);
            lblBreadcrumb.TabIndex = 3;
            lblBreadcrumb.Text = "Home / Settings";
            // 
            // tlpBody
            // 
            tlpBody.ColumnCount = 2;
            tlpBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBody.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpBody.Controls.Add(tlpLeft, 0, 0);
            tlpBody.Controls.Add(pnlEditorCard, 1, 0);
            tlpBody.Dock = DockStyle.Fill;
            tlpBody.Location = new Point(15, 77);
            tlpBody.Margin = new Padding(15, 3, 15, 15);
            tlpBody.Name = "tlpBody";
            tlpBody.RowCount = 1;
            tlpBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBody.Size = new Size(1284, 1159);
            tlpBody.TabIndex = 4;
            // 
            // tlpLeft
            // 
            tlpLeft.ColumnCount = 1;
            tlpLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpLeft.Controls.Add(pnlPersonnelCard, 0, 0);
            tlpLeft.Controls.Add(pnlAdminsCard, 0, 1);
            tlpLeft.Dock = DockStyle.Fill;
            tlpLeft.Location = new Point(0, 0);
            tlpLeft.Margin = new Padding(0, 0, 8, 0);
            tlpLeft.Name = "tlpLeft";
            tlpLeft.RowCount = 2;
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 62F));
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 38F));
            tlpLeft.Size = new Size(634, 1159);
            tlpLeft.TabIndex = 5;
            // 
            // pnlPersonnelCard
            // 
            pnlPersonnelCard.BackColor = Color.White;
            pnlPersonnelCard.BorderColor = Color.Transparent;
            pnlPersonnelCard.BorderRadius = 10;
            pnlPersonnelCard.Controls.Add(dgvPersonnel);
            pnlPersonnelCard.Controls.Add(pnlPersonnelTools);
            pnlPersonnelCard.Controls.Add(lblPersonnelTitle);
            pnlPersonnelCard.Dock = DockStyle.Fill;
            pnlPersonnelCard.Location = new Point(0, 0);
            pnlPersonnelCard.Margin = new Padding(0, 0, 0, 8);
            pnlPersonnelCard.Name = "pnlPersonnelCard";
            pnlPersonnelCard.Padding = new Padding(12, 10, 12, 12);
            pnlPersonnelCard.ShadowColor = Color.Black;
            pnlPersonnelCard.ShadowOpacity = 28;
            pnlPersonnelCard.ShadowSize = 4;
            pnlPersonnelCard.Size = new Size(634, 710);
            pnlPersonnelCard.TabIndex = 6;
            // 
            // dgvPersonnel
            // 
            dgvPersonnel.BackgroundColor = Color.White;
            dgvPersonnel.BorderStyle = BorderStyle.None;
            dgvPersonnel.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPersonnel.ColumnHeadersHeight = 42;
            dgvPersonnel.Dock = DockStyle.Fill;
            dgvPersonnel.GridColor = Color.FromArgb(233, 236, 239);
            dgvPersonnel.Location = new Point(16, 100);
            dgvPersonnel.Margin = new Padding(0);
            dgvPersonnel.Name = "dgvPersonnel";
            dgvPersonnel.RowHeadersVisible = false;
            dgvPersonnel.RowHeadersWidth = 51;
            dgvPersonnel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPersonnel.Size = new Size(602, 592);
            dgvPersonnel.TabIndex = 11;
            // 
            // pnlPersonnelTools
            // 
            pnlPersonnelTools.Controls.Add(txtSearch);
            pnlPersonnelTools.Controls.Add(cmbFilter);
            pnlPersonnelTools.Dock = DockStyle.Top;
            pnlPersonnelTools.Location = new Point(16, 50);
            pnlPersonnelTools.Name = "pnlPersonnelTools";
            pnlPersonnelTools.Padding = new Padding(0, 6, 0, 6);
            pnlPersonnelTools.Size = new Size(602, 50);
            pnlPersonnelTools.TabIndex = 8;
            // 
            // txtSearch
            // 
            txtSearch.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtSearch.CueHint.CueHintText = "⌕  Search name, employee no. or position...";
            txtSearch.CueHint.Font = new Font("Century Gothic", 8.5F);
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Location = new Point(0, 6);
            txtSearch.Margin = new Padding(0);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(432, 35);
            txtSearch.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 255);
            txtSearch.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtSearch.StateCommon.Border.Rounding = 12F;
            txtSearch.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtSearch.TabIndex = 9;
            // 
            // cmbFilter
            // 
            cmbFilter.Dock = DockStyle.Right;
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Location = new Point(432, 6);
            cmbFilter.Margin = new Padding(8, 0, 0, 0);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(170, 38);
            cmbFilter.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbFilter.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbFilter.StateCommon.ComboBox.Border.Rounding = 12F;
            cmbFilter.StateCommon.ComboBox.Content.Font = new Font("Century Gothic", 9.5F);
            cmbFilter.TabIndex = 10;
            // 
            // lblPersonnelTitle
            // 
            lblPersonnelTitle.Dock = DockStyle.Top;
            lblPersonnelTitle.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblPersonnelTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblPersonnelTitle.Location = new Point(16, 16);
            lblPersonnelTitle.Margin = new Padding(0);
            lblPersonnelTitle.Name = "lblPersonnelTitle";
            lblPersonnelTitle.Size = new Size(602, 34);
            lblPersonnelTitle.TabIndex = 7;
            lblPersonnelTitle.Text = "Personnel";
            lblPersonnelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlAdminsCard
            // 
            pnlAdminsCard.BackColor = Color.White;
            pnlAdminsCard.BorderColor = Color.Transparent;
            pnlAdminsCard.BorderRadius = 10;
            pnlAdminsCard.Controls.Add(dgvAdmins);
            pnlAdminsCard.Controls.Add(lblAdminsTitle);
            pnlAdminsCard.Dock = DockStyle.Fill;
            pnlAdminsCard.Location = new Point(0, 718);
            pnlAdminsCard.Margin = new Padding(0);
            pnlAdminsCard.Name = "pnlAdminsCard";
            pnlAdminsCard.Padding = new Padding(12, 10, 12, 12);
            pnlAdminsCard.ShadowColor = Color.Black;
            pnlAdminsCard.ShadowOpacity = 28;
            pnlAdminsCard.ShadowSize = 4;
            pnlAdminsCard.Size = new Size(634, 441);
            pnlAdminsCard.TabIndex = 12;
            // 
            // dgvAdmins
            // 
            dgvAdmins.BackgroundColor = Color.White;
            dgvAdmins.BorderStyle = BorderStyle.None;
            dgvAdmins.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAdmins.ColumnHeadersHeight = 42;
            dgvAdmins.Dock = DockStyle.Fill;
            dgvAdmins.GridColor = Color.FromArgb(233, 236, 239);
            dgvAdmins.Location = new Point(16, 50);
            dgvAdmins.Margin = new Padding(0);
            dgvAdmins.Name = "dgvAdmins";
            dgvAdmins.RowHeadersVisible = false;
            dgvAdmins.RowHeadersWidth = 51;
            dgvAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdmins.Size = new Size(602, 373);
            dgvAdmins.TabIndex = 14;
            // 
            // lblAdminsTitle
            // 
            lblAdminsTitle.Dock = DockStyle.Top;
            lblAdminsTitle.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblAdminsTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblAdminsTitle.Location = new Point(16, 16);
            lblAdminsTitle.Margin = new Padding(0);
            lblAdminsTitle.Name = "lblAdminsTitle";
            lblAdminsTitle.Size = new Size(602, 34);
            lblAdminsTitle.TabIndex = 13;
            lblAdminsTitle.Text = "System Administrators";
            lblAdminsTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlEditorCard
            // 
            pnlEditorCard.BackColor = Color.White;
            pnlEditorCard.BorderColor = Color.Transparent;
            pnlEditorCard.BorderRadius = 10;
            pnlEditorCard.Controls.Add(pnlEditorScroll);
            pnlEditorCard.Dock = DockStyle.Fill;
            pnlEditorCard.Location = new Point(650, 0);
            pnlEditorCard.Margin = new Padding(8, 0, 0, 0);
            pnlEditorCard.Name = "pnlEditorCard";
            pnlEditorCard.ShadowColor = Color.Black;
            pnlEditorCard.ShadowOpacity = 28;
            pnlEditorCard.ShadowSize = 4;
            pnlEditorCard.Size = new Size(634, 1159);
            pnlEditorCard.TabIndex = 15;
            // 
            // pnlEditorScroll
            // 
            pnlEditorScroll.AutoScroll = true;
            pnlEditorScroll.BackColor = Color.White;
            pnlEditorScroll.Controls.Add(tlpEditor);
            pnlEditorScroll.Dock = DockStyle.Fill;
            pnlEditorScroll.Location = new Point(4, 6);
            pnlEditorScroll.Name = "pnlEditorScroll";
            pnlEditorScroll.Padding = new Padding(24, 16, 24, 16);
            pnlEditorScroll.Size = new Size(626, 1147);
            pnlEditorScroll.TabIndex = 16;
            // 
            // tlpEditor
            // 
            tlpEditor.AutoSize = true;
            tlpEditor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpEditor.ColumnCount = 1;
            tlpEditor.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpEditor.Controls.Add(lblEmployeeTitle, 0, 0);
            tlpEditor.Controls.Add(tlpEmployee, 0, 1);
            tlpEditor.Controls.Add(flpEmployeeButtons, 0, 2);
            tlpEditor.Controls.Add(lblAccountTitle, 0, 3);
            tlpEditor.Controls.Add(lblAccountHint, 0, 4);
            tlpEditor.Controls.Add(tlpAccount, 0, 5);
            tlpEditor.Controls.Add(flpAccountButtons, 0, 6);
            tlpEditor.Dock = DockStyle.Top;
            tlpEditor.Location = new Point(24, 16);
            tlpEditor.Name = "tlpEditor";
            tlpEditor.RowCount = 7;
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.Size = new Size(578, 748);
            tlpEditor.TabIndex = 17;
            // 
            // lblEmployeeTitle
            // 
            lblEmployeeTitle.Dock = DockStyle.Fill;
            lblEmployeeTitle.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblEmployeeTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblEmployeeTitle.Location = new Point(0, 6);
            lblEmployeeTitle.Margin = new Padding(0, 6, 0, 4);
            lblEmployeeTitle.Name = "lblEmployeeTitle";
            lblEmployeeTitle.Size = new Size(578, 34);
            lblEmployeeTitle.TabIndex = 18;
            lblEmployeeTitle.Text = "New Employee";
            lblEmployeeTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tlpEmployee
            // 
            tlpEmployee.AutoSize = true;
            tlpEmployee.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpEmployee.ColumnCount = 2;
            tlpEmployee.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpEmployee.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpEmployee.Controls.Add(lblEmpNo, 0, 0);
            tlpEmployee.Controls.Add(lblEmpStatus, 1, 0);
            tlpEmployee.Controls.Add(pnlEmpNo, 0, 1);
            tlpEmployee.Controls.Add(cmbEmploymentStatus, 1, 1);
            tlpEmployee.Controls.Add(lblFirstName, 0, 2);
            tlpEmployee.Controls.Add(lblLastName, 1, 2);
            tlpEmployee.Controls.Add(txtFirstName, 0, 3);
            tlpEmployee.Controls.Add(txtLastName, 1, 3);
            tlpEmployee.Controls.Add(lblPosition, 0, 4);
            tlpEmployee.Controls.Add(lblContact, 1, 4);
            tlpEmployee.Controls.Add(txtPosition, 0, 5);
            tlpEmployee.Controls.Add(txtContact, 1, 5);
            tlpEmployee.Controls.Add(lblEmail, 0, 6);
            tlpEmployee.Controls.Add(txtEmail, 0, 7);
            tlpEmployee.Dock = DockStyle.Fill;
            tlpEmployee.Location = new Point(0, 44);
            tlpEmployee.Margin = new Padding(0);
            tlpEmployee.Name = "tlpEmployee";
            tlpEmployee.RowCount = 8;
            tlpEmployee.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpEmployee.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tlpEmployee.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpEmployee.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tlpEmployee.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpEmployee.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tlpEmployee.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpEmployee.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tlpEmployee.Size = new Size(578, 280);
            tlpEmployee.TabIndex = 19;
            // 
            // lblEmpNo
            // 
            lblEmpNo.Dock = DockStyle.Fill;
            lblEmpNo.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblEmpNo.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmpNo.Location = new Point(0, 0);
            lblEmpNo.Margin = new Padding(0, 0, 8, 0);
            lblEmpNo.Name = "lblEmpNo";
            lblEmpNo.Size = new Size(281, 24);
            lblEmpNo.TabIndex = 20;
            lblEmpNo.Text = "Employee No.";
            lblEmpNo.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblEmpStatus
            // 
            lblEmpStatus.Dock = DockStyle.Fill;
            lblEmpStatus.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblEmpStatus.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmpStatus.Location = new Point(297, 0);
            lblEmpStatus.Margin = new Padding(8, 0, 0, 0);
            lblEmpStatus.Name = "lblEmpStatus";
            lblEmpStatus.Size = new Size(281, 24);
            lblEmpStatus.TabIndex = 21;
            lblEmpStatus.Text = "Employment Status";
            lblEmpStatus.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlEmpNo
            // 
            pnlEmpNo.Controls.Add(txtEmployeeNo);
            pnlEmpNo.Controls.Add(btnGenerate);
            pnlEmpNo.Dock = DockStyle.Fill;
            pnlEmpNo.Location = new Point(0, 27);
            pnlEmpNo.Margin = new Padding(0, 3, 8, 3);
            pnlEmpNo.Name = "pnlEmpNo";
            pnlEmpNo.Size = new Size(281, 40);
            pnlEmpNo.TabIndex = 22;
            // 
            // txtEmployeeNo
            // 
            txtEmployeeNo.Dock = DockStyle.Fill;
            txtEmployeeNo.Location = new Point(0, 0);
            txtEmployeeNo.Margin = new Padding(0);
            txtEmployeeNo.Name = "txtEmployeeNo";
            txtEmployeeNo.ReadOnly = true;
            txtEmployeeNo.Size = new Size(181, 35);
            txtEmployeeNo.StateCommon.Back.Color1 = Color.FromArgb(241, 243, 245);
            txtEmployeeNo.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtEmployeeNo.StateCommon.Border.Rounding = 12F;
            txtEmployeeNo.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtEmployeeNo.TabIndex = 23;
            // 
            // btnGenerate
            // 
            btnGenerate.Dock = DockStyle.Right;
            btnGenerate.Location = new Point(181, 0);
            btnGenerate.Margin = new Padding(6, 0, 0, 0);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(100, 40);
            btnGenerate.StateCommon.Back.Color1 = Color.FromArgb(74, 151, 196);
            btnGenerate.StateCommon.Back.Color2 = Color.FromArgb(52, 120, 165);
            btnGenerate.StateCommon.Back.ColorAngle = 90F;
            btnGenerate.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnGenerate.StateCommon.Border.Rounding = 12F;
            btnGenerate.StateCommon.Content.ShortText.Color1 = Color.White;
            btnGenerate.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 9F, FontStyle.Bold);
            btnGenerate.TabIndex = 24;
            btnGenerate.Values.DropDownArrowColor = Color.Empty;
            btnGenerate.Values.Text = "Generate";
            btnGenerate.Click += btnGenerate_Click;
            // 
            // cmbEmploymentStatus
            // 
            cmbEmploymentStatus.Dock = DockStyle.Fill;
            cmbEmploymentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmploymentStatus.Location = new Point(297, 27);
            cmbEmploymentStatus.Margin = new Padding(8, 3, 0, 3);
            cmbEmploymentStatus.Name = "cmbEmploymentStatus";
            cmbEmploymentStatus.Size = new Size(281, 40);
            cmbEmploymentStatus.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbEmploymentStatus.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbEmploymentStatus.StateCommon.ComboBox.Border.Rounding = 12F;
            cmbEmploymentStatus.StateCommon.ComboBox.Content.Font = new Font("Century Gothic", 9.5F);
            cmbEmploymentStatus.TabIndex = 25;
            // 
            // lblFirstName
            // 
            lblFirstName.Dock = DockStyle.Fill;
            lblFirstName.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.FromArgb(73, 80, 87);
            lblFirstName.Location = new Point(0, 70);
            lblFirstName.Margin = new Padding(0, 0, 8, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(281, 24);
            lblFirstName.TabIndex = 26;
            lblFirstName.Text = "First Name";
            lblFirstName.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblLastName
            // 
            lblLastName.Dock = DockStyle.Fill;
            lblLastName.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(73, 80, 87);
            lblLastName.Location = new Point(297, 70);
            lblLastName.Margin = new Padding(8, 0, 0, 0);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(281, 24);
            lblLastName.TabIndex = 27;
            lblLastName.Text = "Last Name";
            lblLastName.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtFirstName
            // 
            txtFirstName.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtFirstName.CueHint.CueHintText = "First name";
            txtFirstName.CueHint.Font = new Font("Century Gothic", 8.5F);
            txtFirstName.Dock = DockStyle.Fill;
            txtFirstName.Location = new Point(0, 97);
            txtFirstName.Margin = new Padding(0, 3, 8, 3);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(281, 35);
            txtFirstName.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 255);
            txtFirstName.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtFirstName.StateCommon.Border.Rounding = 12F;
            txtFirstName.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtFirstName.TabIndex = 28;
            // 
            // txtLastName
            // 
            txtLastName.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtLastName.CueHint.CueHintText = "Last name";
            txtLastName.CueHint.Font = new Font("Century Gothic", 8.5F);
            txtLastName.Dock = DockStyle.Fill;
            txtLastName.Location = new Point(297, 97);
            txtLastName.Margin = new Padding(8, 3, 0, 3);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(281, 35);
            txtLastName.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 255);
            txtLastName.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtLastName.StateCommon.Border.Rounding = 12F;
            txtLastName.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtLastName.TabIndex = 29;
            // 
            // lblPosition
            // 
            lblPosition.Dock = DockStyle.Fill;
            lblPosition.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblPosition.ForeColor = Color.FromArgb(73, 80, 87);
            lblPosition.Location = new Point(0, 140);
            lblPosition.Margin = new Padding(0, 0, 8, 0);
            lblPosition.Name = "lblPosition";
            lblPosition.Size = new Size(281, 24);
            lblPosition.TabIndex = 30;
            lblPosition.Text = "Position";
            lblPosition.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblContact
            // 
            lblContact.Dock = DockStyle.Fill;
            lblContact.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblContact.ForeColor = Color.FromArgb(73, 80, 87);
            lblContact.Location = new Point(297, 140);
            lblContact.Margin = new Padding(8, 0, 0, 0);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(281, 24);
            lblContact.TabIndex = 31;
            lblContact.Text = "Contact No.";
            lblContact.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtPosition
            // 
            txtPosition.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtPosition.CueHint.CueHintText = "e.g. Clerk";
            txtPosition.CueHint.Font = new Font("Century Gothic", 8.5F);
            txtPosition.Dock = DockStyle.Fill;
            txtPosition.Location = new Point(0, 167);
            txtPosition.Margin = new Padding(0, 3, 8, 3);
            txtPosition.Name = "txtPosition";
            txtPosition.Size = new Size(281, 35);
            txtPosition.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 255);
            txtPosition.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtPosition.StateCommon.Border.Rounding = 12F;
            txtPosition.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtPosition.TabIndex = 32;
            // 
            // txtContact
            // 
            txtContact.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtContact.CueHint.CueHintText = "09123456789";
            txtContact.CueHint.Font = new Font("Century Gothic", 8.5F);
            txtContact.Dock = DockStyle.Fill;
            txtContact.Location = new Point(297, 167);
            txtContact.Margin = new Padding(8, 3, 0, 3);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(281, 35);
            txtContact.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 255);
            txtContact.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtContact.StateCommon.Border.Rounding = 12F;
            txtContact.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtContact.TabIndex = 33;
            // 
            // lblEmail
            // 
            tlpEmployee.SetColumnSpan(lblEmail, 2);
            lblEmail.Dock = DockStyle.Fill;
            lblEmail.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmail.Location = new Point(0, 210);
            lblEmail.Margin = new Padding(0);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(578, 24);
            lblEmail.TabIndex = 34;
            lblEmail.Text = "Email";
            lblEmail.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtEmail
            // 
            tlpEmployee.SetColumnSpan(txtEmail, 2);
            txtEmail.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtEmail.CueHint.CueHintText = "name@example.com";
            txtEmail.CueHint.Font = new Font("Century Gothic", 8.5F);
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Location = new Point(0, 237);
            txtEmail.Margin = new Padding(0, 3, 0, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(578, 35);
            txtEmail.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 255);
            txtEmail.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtEmail.StateCommon.Border.Rounding = 12F;
            txtEmail.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtEmail.TabIndex = 35;
            // 
            // flpEmployeeButtons
            // 
            flpEmployeeButtons.AutoSize = true;
            flpEmployeeButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpEmployeeButtons.Controls.Add(btnSaveEmployee);
            flpEmployeeButtons.Controls.Add(btnNewEmployee);
            flpEmployeeButtons.Dock = DockStyle.Fill;
            flpEmployeeButtons.FlowDirection = FlowDirection.RightToLeft;
            flpEmployeeButtons.Location = new Point(0, 324);
            flpEmployeeButtons.Margin = new Padding(0);
            flpEmployeeButtons.Name = "flpEmployeeButtons";
            flpEmployeeButtons.Padding = new Padding(0, 10, 0, 6);
            flpEmployeeButtons.Size = new Size(578, 62);
            flpEmployeeButtons.TabIndex = 36;
            // 
            // btnSaveEmployee
            // 
            btnSaveEmployee.Location = new Point(408, 10);
            btnSaveEmployee.Margin = new Padding(8, 0, 0, 0);
            btnSaveEmployee.Name = "btnSaveEmployee";
            btnSaveEmployee.Size = new Size(170, 46);
            btnSaveEmployee.StateCommon.Back.Color1 = Color.FromArgb(141, 198, 63);
            btnSaveEmployee.StateCommon.Back.Color2 = Color.FromArgb(91, 154, 42);
            btnSaveEmployee.StateCommon.Back.ColorAngle = 90F;
            btnSaveEmployee.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnSaveEmployee.StateCommon.Border.Rounding = 12F;
            btnSaveEmployee.StateCommon.Content.ShortText.Color1 = Color.White;
            btnSaveEmployee.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            btnSaveEmployee.TabIndex = 37;
            btnSaveEmployee.Values.DropDownArrowColor = Color.Empty;
            btnSaveEmployee.Values.Text = "Add Employee";
            btnSaveEmployee.Click += btnSaveEmployee_Click;
            // 
            // btnNewEmployee
            // 
            btnNewEmployee.Location = new Point(280, 10);
            btnNewEmployee.Margin = new Padding(8, 0, 0, 0);
            btnNewEmployee.Name = "btnNewEmployee";
            btnNewEmployee.Size = new Size(120, 46);
            btnNewEmployee.StateCommon.Back.Color1 = Color.FromArgb(74, 151, 196);
            btnNewEmployee.StateCommon.Back.Color2 = Color.FromArgb(52, 120, 165);
            btnNewEmployee.StateCommon.Back.ColorAngle = 90F;
            btnNewEmployee.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnNewEmployee.StateCommon.Border.Rounding = 12F;
            btnNewEmployee.StateCommon.Content.ShortText.Color1 = Color.White;
            btnNewEmployee.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            btnNewEmployee.TabIndex = 38;
            btnNewEmployee.Values.DropDownArrowColor = Color.Empty;
            btnNewEmployee.Values.Text = "＋  New";
            btnNewEmployee.Click += btnNewEmployee_Click;
            // 
            // lblAccountTitle
            // 
            lblAccountTitle.Dock = DockStyle.Fill;
            lblAccountTitle.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblAccountTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblAccountTitle.Location = new Point(0, 392);
            lblAccountTitle.Margin = new Padding(0, 6, 0, 4);
            lblAccountTitle.Name = "lblAccountTitle";
            lblAccountTitle.Size = new Size(578, 34);
            lblAccountTitle.TabIndex = 39;
            lblAccountTitle.Text = "Account Details";
            lblAccountTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAccountHint
            // 
            lblAccountHint.Dock = DockStyle.Fill;
            lblAccountHint.Font = new Font("Century Gothic", 8.5F);
            lblAccountHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblAccountHint.Location = new Point(0, 430);
            lblAccountHint.Margin = new Padding(0, 0, 0, 6);
            lblAccountHint.Name = "lblAccountHint";
            lblAccountHint.Size = new Size(578, 40);
            lblAccountHint.TabIndex = 40;
            // 
            // tlpAccount
            // 
            tlpAccount.AutoSize = true;
            tlpAccount.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tlpAccount.ColumnCount = 2;
            tlpAccount.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpAccount.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpAccount.Controls.Add(lblUsername, 0, 0);
            tlpAccount.Controls.Add(lblAccountStatus, 1, 0);
            tlpAccount.Controls.Add(txtUsername, 0, 1);
            tlpAccount.Controls.Add(cmbAccountStatus, 1, 1);
            tlpAccount.Controls.Add(lblRole, 0, 2);
            tlpAccount.Controls.Add(lblNewPassword, 1, 2);
            tlpAccount.Controls.Add(cmbRole, 0, 3);
            tlpAccount.Controls.Add(txtNewPassword, 1, 3);
            tlpAccount.Controls.Add(lblConfirmPassword, 0, 4);
            tlpAccount.Controls.Add(lblLastLoginCaption, 1, 4);
            tlpAccount.Controls.Add(txtConfirmPassword, 0, 5);
            tlpAccount.Controls.Add(lblLastLogin, 1, 5);
            tlpAccount.Dock = DockStyle.Fill;
            tlpAccount.Location = new Point(0, 476);
            tlpAccount.Margin = new Padding(0);
            tlpAccount.Name = "tlpAccount";
            tlpAccount.RowCount = 6;
            tlpAccount.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpAccount.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tlpAccount.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpAccount.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tlpAccount.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpAccount.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tlpAccount.Size = new Size(578, 210);
            tlpAccount.TabIndex = 41;
            // 
            // lblUsername
            // 
            lblUsername.Dock = DockStyle.Fill;
            lblUsername.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(73, 80, 87);
            lblUsername.Location = new Point(0, 0);
            lblUsername.Margin = new Padding(0, 0, 8, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(281, 24);
            lblUsername.TabIndex = 42;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblAccountStatus
            // 
            lblAccountStatus.Dock = DockStyle.Fill;
            lblAccountStatus.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblAccountStatus.ForeColor = Color.FromArgb(73, 80, 87);
            lblAccountStatus.Location = new Point(297, 0);
            lblAccountStatus.Margin = new Padding(8, 0, 0, 0);
            lblAccountStatus.Name = "lblAccountStatus";
            lblAccountStatus.Size = new Size(281, 24);
            lblAccountStatus.TabIndex = 43;
            lblAccountStatus.Text = "Account Status";
            lblAccountStatus.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtUsername
            // 
            txtUsername.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtUsername.CueHint.CueHintText = "Username";
            txtUsername.CueHint.Font = new Font("Century Gothic", 8.5F);
            txtUsername.Dock = DockStyle.Fill;
            txtUsername.Location = new Point(0, 27);
            txtUsername.Margin = new Padding(0, 3, 8, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(281, 35);
            txtUsername.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 255);
            txtUsername.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtUsername.StateCommon.Border.Rounding = 12F;
            txtUsername.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtUsername.TabIndex = 44;
            // 
            // cmbAccountStatus
            // 
            cmbAccountStatus.Dock = DockStyle.Fill;
            cmbAccountStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccountStatus.Location = new Point(297, 27);
            cmbAccountStatus.Margin = new Padding(8, 3, 0, 3);
            cmbAccountStatus.Name = "cmbAccountStatus";
            cmbAccountStatus.Size = new Size(281, 40);
            cmbAccountStatus.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbAccountStatus.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbAccountStatus.StateCommon.ComboBox.Border.Rounding = 12F;
            cmbAccountStatus.StateCommon.ComboBox.Content.Font = new Font("Century Gothic", 9.5F);
            cmbAccountStatus.TabIndex = 45;
            // 
            // lblRole
            // 
            lblRole.Dock = DockStyle.Fill;
            lblRole.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblRole.ForeColor = Color.FromArgb(73, 80, 87);
            lblRole.Location = new Point(0, 70);
            lblRole.Margin = new Padding(0, 0, 8, 0);
            lblRole.Name = "lblRole";
            lblRole.Size = new Size(281, 24);
            lblRole.TabIndex = 46;
            lblRole.Text = "Role";
            lblRole.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblNewPassword
            // 
            lblNewPassword.Dock = DockStyle.Fill;
            lblNewPassword.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblNewPassword.ForeColor = Color.FromArgb(73, 80, 87);
            lblNewPassword.Location = new Point(297, 70);
            lblNewPassword.Margin = new Padding(8, 0, 0, 0);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(281, 24);
            lblNewPassword.TabIndex = 47;
            lblNewPassword.Text = "New Password";
            lblNewPassword.TextAlign = ContentAlignment.BottomLeft;
            // 
            // cmbRole
            // 
            cmbRole.Dock = DockStyle.Fill;
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Location = new Point(0, 97);
            cmbRole.Margin = new Padding(0, 3, 8, 3);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(281, 40);
            cmbRole.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbRole.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbRole.StateCommon.ComboBox.Border.Rounding = 12F;
            cmbRole.StateCommon.ComboBox.Content.Font = new Font("Century Gothic", 9.5F);
            cmbRole.TabIndex = 48;
            // 
            // txtNewPassword
            // 
            txtNewPassword.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtNewPassword.CueHint.CueHintText = "Leave blank to keep current";
            txtNewPassword.CueHint.Font = new Font("Century Gothic", 8.5F);
            txtNewPassword.Dock = DockStyle.Fill;
            txtNewPassword.Location = new Point(297, 97);
            txtNewPassword.Margin = new Padding(8, 3, 0, 3);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '●';
            txtNewPassword.Size = new Size(281, 35);
            txtNewPassword.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 255);
            txtNewPassword.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtNewPassword.StateCommon.Border.Rounding = 12F;
            txtNewPassword.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtNewPassword.TabIndex = 49;
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Dock = DockStyle.Fill;
            lblConfirmPassword.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.FromArgb(73, 80, 87);
            lblConfirmPassword.Location = new Point(0, 140);
            lblConfirmPassword.Margin = new Padding(0, 0, 8, 0);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(281, 24);
            lblConfirmPassword.TabIndex = 50;
            lblConfirmPassword.Text = "Confirm Password";
            lblConfirmPassword.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblLastLoginCaption
            // 
            lblLastLoginCaption.Dock = DockStyle.Fill;
            lblLastLoginCaption.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblLastLoginCaption.ForeColor = Color.FromArgb(73, 80, 87);
            lblLastLoginCaption.Location = new Point(297, 140);
            lblLastLoginCaption.Margin = new Padding(8, 0, 0, 0);
            lblLastLoginCaption.Name = "lblLastLoginCaption";
            lblLastLoginCaption.Size = new Size(281, 24);
            lblLastLoginCaption.TabIndex = 51;
            lblLastLoginCaption.Text = "Last Login";
            lblLastLoginCaption.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtConfirmPassword.CueHint.CueHintText = "Re-enter new password";
            txtConfirmPassword.CueHint.Font = new Font("Century Gothic", 8.5F);
            txtConfirmPassword.Dock = DockStyle.Fill;
            txtConfirmPassword.Location = new Point(0, 167);
            txtConfirmPassword.Margin = new Padding(0, 3, 8, 3);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.Size = new Size(281, 35);
            txtConfirmPassword.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 255);
            txtConfirmPassword.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtConfirmPassword.StateCommon.Border.Rounding = 12F;
            txtConfirmPassword.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtConfirmPassword.TabIndex = 52;
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblLastLogin
            // 
            lblLastLogin.Dock = DockStyle.Fill;
            lblLastLogin.Font = new Font("Century Gothic", 9.5F);
            lblLastLogin.ForeColor = Color.FromArgb(44, 49, 53);
            lblLastLogin.Location = new Point(297, 167);
            lblLastLogin.Margin = new Padding(8, 3, 0, 3);
            lblLastLogin.Name = "lblLastLogin";
            lblLastLogin.Size = new Size(281, 40);
            lblLastLogin.TabIndex = 53;
            lblLastLogin.Text = "—";
            lblLastLogin.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flpAccountButtons
            // 
            flpAccountButtons.AutoSize = true;
            flpAccountButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flpAccountButtons.Controls.Add(btnSaveAccount);
            flpAccountButtons.Controls.Add(btnDeleteAccount);
            flpAccountButtons.Dock = DockStyle.Fill;
            flpAccountButtons.FlowDirection = FlowDirection.RightToLeft;
            flpAccountButtons.Location = new Point(0, 686);
            flpAccountButtons.Margin = new Padding(0);
            flpAccountButtons.Name = "flpAccountButtons";
            flpAccountButtons.Padding = new Padding(0, 10, 0, 6);
            flpAccountButtons.Size = new Size(578, 62);
            flpAccountButtons.TabIndex = 54;
            // 
            // btnSaveAccount
            // 
            btnSaveAccount.Location = new Point(418, 10);
            btnSaveAccount.Margin = new Padding(8, 0, 0, 0);
            btnSaveAccount.Name = "btnSaveAccount";
            btnSaveAccount.Size = new Size(160, 46);
            btnSaveAccount.StateCommon.Back.Color1 = Color.FromArgb(74, 151, 196);
            btnSaveAccount.StateCommon.Back.Color2 = Color.FromArgb(52, 120, 165);
            btnSaveAccount.StateCommon.Back.ColorAngle = 90F;
            btnSaveAccount.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnSaveAccount.StateCommon.Border.Rounding = 12F;
            btnSaveAccount.StateCommon.Content.ShortText.Color1 = Color.White;
            btnSaveAccount.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            btnSaveAccount.TabIndex = 55;
            btnSaveAccount.Values.DropDownArrowColor = Color.Empty;
            btnSaveAccount.Values.Text = "Save Account";
            btnSaveAccount.Click += btnSaveAccount_Click;
            // 
            // btnDeleteAccount
            // 
            btnDeleteAccount.Location = new Point(250, 10);
            btnDeleteAccount.Margin = new Padding(8, 0, 0, 0);
            btnDeleteAccount.Name = "btnDeleteAccount";
            btnDeleteAccount.Size = new Size(160, 46);
            btnDeleteAccount.StateCommon.Back.Color1 = Color.FromArgb(226, 92, 88);
            btnDeleteAccount.StateCommon.Back.Color2 = Color.FromArgb(192, 57, 53);
            btnDeleteAccount.StateCommon.Back.ColorAngle = 90F;
            btnDeleteAccount.StateCommon.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.Linear;
            btnDeleteAccount.StateCommon.Border.Rounding = 12F;
            btnDeleteAccount.StateCommon.Content.ShortText.Color1 = Color.White;
            btnDeleteAccount.StateCommon.Content.ShortText.Font = new Font("Century Gothic", 10F, FontStyle.Bold);
            btnDeleteAccount.TabIndex = 56;
            btnDeleteAccount.Values.DropDownArrowColor = Color.Empty;
            btnDeleteAccount.Values.Text = "Delete Account";
            btnDeleteAccount.Click += btnDeleteAccount_Click;
            // 
            // SettingsModule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(237, 240, 241);
            Controls.Add(tlpMain);
            Margin = new Padding(3, 4, 3, 4);
            Name = "SettingsModule";
            Size = new Size(1314, 1251);
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            tlpBody.ResumeLayout(false);
            tlpLeft.ResumeLayout(false);
            pnlPersonnelCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPersonnel).EndInit();
            pnlPersonnelTools.ResumeLayout(false);
            pnlPersonnelTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilter).EndInit();
            pnlAdminsCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvAdmins).EndInit();
            pnlEditorCard.ResumeLayout(false);
            pnlEditorScroll.ResumeLayout(false);
            pnlEditorScroll.PerformLayout();
            tlpEditor.ResumeLayout(false);
            tlpEditor.PerformLayout();
            tlpEmployee.ResumeLayout(false);
            tlpEmployee.PerformLayout();
            pnlEmpNo.ResumeLayout(false);
            pnlEmpNo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbEmploymentStatus).EndInit();
            flpEmployeeButtons.ResumeLayout(false);
            tlpAccount.ResumeLayout(false);
            tlpAccount.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbAccountStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbRole).EndInit();
            flpAccountButtons.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblBreadcrumb;
        private TableLayoutPanel tlpBody;
        private TableLayoutPanel tlpLeft;
        private RoundedPanel pnlPersonnelCard;
        private Label lblPersonnelTitle;
        private Panel pnlPersonnelTools;
        private Krypton.Toolkit.KryptonTextBox txtSearch;
        private Krypton.Toolkit.KryptonComboBox cmbFilter;
        private DataGridView dgvPersonnel;
        private RoundedPanel pnlAdminsCard;
        private Label lblAdminsTitle;
        private DataGridView dgvAdmins;
        private RoundedPanel pnlEditorCard;
        private Panel pnlEditorScroll;
        private TableLayoutPanel tlpEditor;
        private Label lblEmployeeTitle;
        private TableLayoutPanel tlpEmployee;
        private Label lblEmpNo;
        private Label lblEmpStatus;
        private Panel pnlEmpNo;
        private Krypton.Toolkit.KryptonTextBox txtEmployeeNo;
        private Krypton.Toolkit.KryptonButton btnGenerate;
        private Krypton.Toolkit.KryptonComboBox cmbEmploymentStatus;
        private Label lblFirstName;
        private Label lblLastName;
        private Krypton.Toolkit.KryptonTextBox txtFirstName;
        private Krypton.Toolkit.KryptonTextBox txtLastName;
        private Label lblPosition;
        private Label lblContact;
        private Krypton.Toolkit.KryptonTextBox txtPosition;
        private Krypton.Toolkit.KryptonTextBox txtContact;
        private Label lblEmail;
        private Krypton.Toolkit.KryptonTextBox txtEmail;
        private FlowLayoutPanel flpEmployeeButtons;
        private Krypton.Toolkit.KryptonButton btnSaveEmployee;
        private Krypton.Toolkit.KryptonButton btnNewEmployee;
        private Label lblAccountTitle;
        private Label lblAccountHint;
        private TableLayoutPanel tlpAccount;
        private Label lblUsername;
        private Label lblAccountStatus;
        private Krypton.Toolkit.KryptonTextBox txtUsername;
        private Krypton.Toolkit.KryptonComboBox cmbAccountStatus;
        private Label lblRole;
        private Label lblNewPassword;
        private Krypton.Toolkit.KryptonComboBox cmbRole;
        private Krypton.Toolkit.KryptonTextBox txtNewPassword;
        private Label lblConfirmPassword;
        private Label lblLastLoginCaption;
        private Krypton.Toolkit.KryptonTextBox txtConfirmPassword;
        private Label lblLastLogin;
        private FlowLayoutPanel flpAccountButtons;
        private Krypton.Toolkit.KryptonButton btnSaveAccount;
        private Krypton.Toolkit.KryptonButton btnDeleteAccount;
    }
}