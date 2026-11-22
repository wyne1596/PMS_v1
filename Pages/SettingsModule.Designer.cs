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
            components = new System.ComponentModel.Container();
            tlpMain = new TableLayoutPanel();
            pnlHeader = new Panel();
            lblTitle = new Label();
            lblBreadcrumb = new Label();
            tlpBody = new TableLayoutPanel();
            tlpLeft = new TableLayoutPanel();
            pnlPersonnelCard = new RoundedPanel();
            lblPersonnelTitle = new Label();
            pnlPersonnelTools = new Panel();
            txtSearch = new Krypton.Toolkit.KryptonTextBox();
            cmbFilter = new Krypton.Toolkit.KryptonComboBox();
            dgvPersonnel = new DataGridView();
            pnlAdminsCard = new RoundedPanel();
            lblAdminsTitle = new Label();
            dgvAdmins = new DataGridView();
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
            pnlPersonnelTools.SuspendLayout();
            pnlAdminsCard.SuspendLayout();
            pnlEditorCard.SuspendLayout();
            pnlEditorScroll.SuspendLayout();
            tlpEditor.SuspendLayout();
            tlpEmployee.SuspendLayout();
            pnlEmpNo.SuspendLayout();
            flpEmployeeButtons.SuspendLayout();
            tlpAccount.SuspendLayout();
            flpAccountButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilter).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvPersonnel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdmins).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbEmploymentStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbAccountStatus).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cmbRole).BeginInit();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 1;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpMain.Controls.Add(pnlHeader, 0, 0);
            tlpMain.Controls.Add(tlpBody, 0, 1);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 2;
            tlpMain.RowStyles.Add(new RowStyle());
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.TabIndex = 0;
            // 
            // pnlHeader
            // 
            pnlHeader.AutoSize = true;
            pnlHeader.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblBreadcrumb);
            pnlHeader.Dock = DockStyle.Fill;
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(15, 0, 0, 0);
            pnlHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Century Gothic", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Name = "lblTitle";
            lblTitle.TabIndex = 2;
            lblTitle.Text = "Settings";
            // 
            // lblBreadcrumb
            // 
            lblBreadcrumb.AutoSize = true;
            lblBreadcrumb.Dock = DockStyle.Top;
            lblBreadcrumb.Font = new Font("Century Gothic", 8.5F);
            lblBreadcrumb.ForeColor = Color.FromArgb(108, 117, 125);
            lblBreadcrumb.Name = "lblBreadcrumb";
            lblBreadcrumb.Padding = new Padding(3, 0, 0, 11);
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
            tlpBody.Margin = new Padding(15, 3, 15, 15);
            tlpBody.Name = "tlpBody";
            tlpBody.RowCount = 1;
            tlpBody.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpBody.TabIndex = 4;
            // 
            // tlpLeft
            // 
            tlpLeft.ColumnCount = 1;
            tlpLeft.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpLeft.Controls.Add(pnlPersonnelCard, 0, 0);
            tlpLeft.Controls.Add(pnlAdminsCard, 0, 1);
            tlpLeft.Dock = DockStyle.Fill;
            tlpLeft.Margin = new Padding(0, 0, 8, 0);
            tlpLeft.Name = "tlpLeft";
            tlpLeft.RowCount = 2;
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 62F));
            tlpLeft.RowStyles.Add(new RowStyle(SizeType.Percent, 38F));
            tlpLeft.TabIndex = 5;
            // 
            // pnlPersonnelCard
            // 
            pnlPersonnelCard.Controls.Add(dgvPersonnel);
            pnlPersonnelCard.Controls.Add(pnlPersonnelTools);
            pnlPersonnelCard.Controls.Add(lblPersonnelTitle);
            pnlPersonnelCard.BackColor = Color.White;
            pnlPersonnelCard.BorderColor = Color.Transparent;
            pnlPersonnelCard.BorderRadius = 10;
            pnlPersonnelCard.Dock = DockStyle.Fill;
            pnlPersonnelCard.Margin = new Padding(0, 0, 0, 8);
            pnlPersonnelCard.Name = "pnlPersonnelCard";
            pnlPersonnelCard.Padding = new Padding(12, 10, 12, 12);
            pnlPersonnelCard.ShadowColor = Color.Black;
            pnlPersonnelCard.ShadowOpacity = 28;
            pnlPersonnelCard.ShadowSize = 4;
            pnlPersonnelCard.TabIndex = 6;
            // 
            // lblPersonnelTitle
            // 
            lblPersonnelTitle.Dock = DockStyle.Top;
            lblPersonnelTitle.Height = 34;
            lblPersonnelTitle.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblPersonnelTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblPersonnelTitle.Margin = new Padding(0, 0, 0, 0);
            lblPersonnelTitle.Name = "lblPersonnelTitle";
            lblPersonnelTitle.TabIndex = 7;
            lblPersonnelTitle.Text = "Personnel";
            lblPersonnelTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // pnlPersonnelTools
            // 
            pnlPersonnelTools.Controls.Add(txtSearch);
            pnlPersonnelTools.Controls.Add(cmbFilter);
            pnlPersonnelTools.Dock = DockStyle.Top;
            pnlPersonnelTools.Height = 50;
            pnlPersonnelTools.Name = "pnlPersonnelTools";
            pnlPersonnelTools.Padding = new Padding(0, 6, 0, 6);
            pnlPersonnelTools.TabIndex = 8;
            // 
            // txtSearch
            // 
            txtSearch.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtSearch.CueHint.CueHintText = "⌕  Search name, employee no. or position...";
            txtSearch.CueHint.Font = new Font("Century Gothic", 8.5F);
            txtSearch.Dock = DockStyle.Fill;
            txtSearch.Margin = new Padding(0);
            txtSearch.Name = "txtSearch";
            txtSearch.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 255);
            txtSearch.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtSearch.StateCommon.Border.Rounding = 12F;
            txtSearch.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtSearch.TabIndex = 9;
            // 
            // cmbFilter
            // 
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.Dock = DockStyle.Right;
            cmbFilter.Size = new Size(170, 34);
            cmbFilter.Margin = new Padding(8, 0, 0, 0);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.StateCommon.ComboBox.Back.Color1 = Color.White;
            cmbFilter.StateCommon.ComboBox.Border.Color1 = Color.FromArgb(222, 226, 230);
            cmbFilter.StateCommon.ComboBox.Border.Rounding = 12F;
            cmbFilter.StateCommon.ComboBox.Content.Font = new Font("Century Gothic", 9.5F);
            cmbFilter.TabIndex = 10;
            // 
            // dgvPersonnel
            // 
            dgvPersonnel.BackgroundColor = Color.White;
            dgvPersonnel.BorderStyle = BorderStyle.None;
            dgvPersonnel.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPersonnel.ColumnHeadersHeight = 42;
            dgvPersonnel.Dock = DockStyle.Fill;
            dgvPersonnel.GridColor = Color.FromArgb(233, 236, 239);
            dgvPersonnel.Margin = new Padding(0);
            dgvPersonnel.Name = "dgvPersonnel";
            dgvPersonnel.RowHeadersVisible = false;
            dgvPersonnel.RowHeadersWidth = 51;
            dgvPersonnel.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPersonnel.TabIndex = 11;
            // 
            // pnlAdminsCard
            // 
            pnlAdminsCard.Controls.Add(dgvAdmins);
            pnlAdminsCard.Controls.Add(lblAdminsTitle);
            pnlAdminsCard.BackColor = Color.White;
            pnlAdminsCard.BorderColor = Color.Transparent;
            pnlAdminsCard.BorderRadius = 10;
            pnlAdminsCard.Dock = DockStyle.Fill;
            pnlAdminsCard.Margin = new Padding(0);
            pnlAdminsCard.Name = "pnlAdminsCard";
            pnlAdminsCard.Padding = new Padding(12, 10, 12, 12);
            pnlAdminsCard.ShadowColor = Color.Black;
            pnlAdminsCard.ShadowOpacity = 28;
            pnlAdminsCard.ShadowSize = 4;
            pnlAdminsCard.TabIndex = 12;
            // 
            // lblAdminsTitle
            // 
            lblAdminsTitle.Dock = DockStyle.Top;
            lblAdminsTitle.Height = 34;
            lblAdminsTitle.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblAdminsTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblAdminsTitle.Margin = new Padding(0, 0, 0, 0);
            lblAdminsTitle.Name = "lblAdminsTitle";
            lblAdminsTitle.TabIndex = 13;
            lblAdminsTitle.Text = "System Administrators";
            lblAdminsTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvAdmins
            // 
            dgvAdmins.BackgroundColor = Color.White;
            dgvAdmins.BorderStyle = BorderStyle.None;
            dgvAdmins.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAdmins.ColumnHeadersHeight = 42;
            dgvAdmins.Dock = DockStyle.Fill;
            dgvAdmins.GridColor = Color.FromArgb(233, 236, 239);
            dgvAdmins.Margin = new Padding(0);
            dgvAdmins.Name = "dgvAdmins";
            dgvAdmins.RowHeadersVisible = false;
            dgvAdmins.RowHeadersWidth = 51;
            dgvAdmins.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAdmins.TabIndex = 14;
            // 
            // pnlEditorCard
            // 
            pnlEditorCard.Controls.Add(pnlEditorScroll);
            pnlEditorCard.BackColor = Color.White;
            pnlEditorCard.BorderColor = Color.Transparent;
            pnlEditorCard.BorderRadius = 10;
            pnlEditorCard.Dock = DockStyle.Fill;
            pnlEditorCard.Margin = new Padding(8, 0, 0, 0);
            pnlEditorCard.Name = "pnlEditorCard";
            pnlEditorCard.Padding = new Padding(0);
            pnlEditorCard.ShadowColor = Color.Black;
            pnlEditorCard.ShadowOpacity = 28;
            pnlEditorCard.ShadowSize = 4;
            pnlEditorCard.TabIndex = 15;
            // 
            // pnlEditorScroll
            // 
            pnlEditorScroll.AutoScroll = true;
            pnlEditorScroll.BackColor = Color.White;
            pnlEditorScroll.Controls.Add(tlpEditor);
            pnlEditorScroll.Dock = DockStyle.Fill;
            pnlEditorScroll.Name = "pnlEditorScroll";
            pnlEditorScroll.Padding = new Padding(24, 16, 24, 16);
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
            tlpEditor.Name = "tlpEditor";
            tlpEditor.RowCount = 7;
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.RowStyles.Add(new RowStyle());
            tlpEditor.TabIndex = 17;
            // 
            // lblEmployeeTitle
            // 
            lblEmployeeTitle.Dock = DockStyle.Fill;
            lblEmployeeTitle.Height = 34;
            lblEmployeeTitle.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblEmployeeTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblEmployeeTitle.Margin = new Padding(0, 6, 0, 4);
            lblEmployeeTitle.Name = "lblEmployeeTitle";
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
            tlpEmployee.SetColumnSpan(lblEmail, 2);
            tlpEmployee.SetColumnSpan(txtEmail, 2);
            tlpEmployee.Dock = DockStyle.Fill;
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
            tlpEmployee.TabIndex = 19;
            // 
            // lblEmpNo
            // 
            lblEmpNo.Dock = DockStyle.Fill;
            lblEmpNo.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblEmpNo.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmpNo.Margin = new Padding(0, 0, 8, 0);
            lblEmpNo.Name = "lblEmpNo";
            lblEmpNo.TabIndex = 20;
            lblEmpNo.Text = "Employee No.";
            lblEmpNo.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblEmpStatus
            // 
            lblEmpStatus.Dock = DockStyle.Fill;
            lblEmpStatus.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblEmpStatus.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmpStatus.Margin = new Padding(8, 0, 0, 0);
            lblEmpStatus.Name = "lblEmpStatus";
            lblEmpStatus.TabIndex = 21;
            lblEmpStatus.Text = "Employment Status";
            lblEmpStatus.TextAlign = ContentAlignment.BottomLeft;
            // 
            // pnlEmpNo
            // 
            pnlEmpNo.Controls.Add(txtEmployeeNo);
            pnlEmpNo.Controls.Add(btnGenerate);
            pnlEmpNo.Dock = DockStyle.Fill;
            pnlEmpNo.Margin = new Padding(0, 3, 8, 3);
            pnlEmpNo.Name = "pnlEmpNo";
            pnlEmpNo.TabIndex = 22;
            // 
            // txtEmployeeNo
            // 
            txtEmployeeNo.Dock = DockStyle.Fill;
            txtEmployeeNo.Margin = new Padding(0);
            txtEmployeeNo.Name = "txtEmployeeNo";
            txtEmployeeNo.ReadOnly = true;
            txtEmployeeNo.StateCommon.Back.Color1 = Color.FromArgb(241, 243, 245);
            txtEmployeeNo.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtEmployeeNo.StateCommon.Border.Rounding = 12F;
            txtEmployeeNo.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtEmployeeNo.TabIndex = 23;
            // 
            // btnGenerate
            // 
            btnGenerate.Dock = DockStyle.Right;
            btnGenerate.Margin = new Padding(6, 0, 0, 0);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(104, 34);
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
            cmbEmploymentStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbEmploymentStatus.Dock = DockStyle.Fill;
            cmbEmploymentStatus.Margin = new Padding(8, 3, 0, 3);
            cmbEmploymentStatus.Name = "cmbEmploymentStatus";
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
            lblFirstName.Margin = new Padding(0, 0, 8, 0);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.TabIndex = 26;
            lblFirstName.Text = "First Name";
            lblFirstName.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblLastName
            // 
            lblLastName.Dock = DockStyle.Fill;
            lblLastName.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(73, 80, 87);
            lblLastName.Margin = new Padding(8, 0, 0, 0);
            lblLastName.Name = "lblLastName";
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
            txtFirstName.Margin = new Padding(0, 3, 8, 3);
            txtFirstName.Name = "txtFirstName";
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
            txtLastName.Margin = new Padding(8, 3, 0, 3);
            txtLastName.Name = "txtLastName";
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
            lblPosition.Margin = new Padding(0, 0, 8, 0);
            lblPosition.Name = "lblPosition";
            lblPosition.TabIndex = 30;
            lblPosition.Text = "Position";
            lblPosition.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblContact
            // 
            lblContact.Dock = DockStyle.Fill;
            lblContact.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblContact.ForeColor = Color.FromArgb(73, 80, 87);
            lblContact.Margin = new Padding(8, 0, 0, 0);
            lblContact.Name = "lblContact";
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
            txtPosition.Margin = new Padding(0, 3, 8, 3);
            txtPosition.Name = "txtPosition";
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
            txtContact.Margin = new Padding(8, 3, 0, 3);
            txtContact.Name = "txtContact";
            txtContact.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 255);
            txtContact.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtContact.StateCommon.Border.Rounding = 12F;
            txtContact.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtContact.TabIndex = 33;
            // 
            // lblEmail
            // 
            lblEmail.Dock = DockStyle.Fill;
            lblEmail.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(73, 80, 87);
            lblEmail.Margin = new Padding(0, 0, 0, 0);
            lblEmail.Name = "lblEmail";
            lblEmail.TabIndex = 34;
            lblEmail.Text = "Email";
            lblEmail.TextAlign = ContentAlignment.BottomLeft;
            // 
            // txtEmail
            // 
            txtEmail.CueHint.Color1 = Color.FromArgb(125, 130, 134);
            txtEmail.CueHint.CueHintText = "name@example.com";
            txtEmail.CueHint.Font = new Font("Century Gothic", 8.5F);
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.Margin = new Padding(0, 3, 0, 3);
            txtEmail.Name = "txtEmail";
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
            flpEmployeeButtons.Margin = new Padding(0);
            flpEmployeeButtons.Name = "flpEmployeeButtons";
            flpEmployeeButtons.Padding = new Padding(0, 10, 0, 6);
            flpEmployeeButtons.TabIndex = 36;
            // 
            // btnSaveEmployee
            // 
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
            lblAccountTitle.Height = 34;
            lblAccountTitle.Font = new Font("Century Gothic", 12F, FontStyle.Bold);
            lblAccountTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblAccountTitle.Margin = new Padding(0, 6, 0, 4);
            lblAccountTitle.Name = "lblAccountTitle";
            lblAccountTitle.TabIndex = 39;
            lblAccountTitle.Text = "Account Details";
            lblAccountTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblAccountHint
            // 
            lblAccountHint.Dock = DockStyle.Fill;
            lblAccountHint.Height = 40;
            lblAccountHint.Font = new Font("Century Gothic", 8.5F);
            lblAccountHint.ForeColor = Color.FromArgb(108, 117, 125);
            lblAccountHint.Margin = new Padding(0, 0, 0, 6);
            lblAccountHint.Name = "lblAccountHint";
            lblAccountHint.TabIndex = 40;
            lblAccountHint.Text = "";
            lblAccountHint.TextAlign = ContentAlignment.TopLeft;
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
            tlpAccount.Margin = new Padding(0);
            tlpAccount.Name = "tlpAccount";
            tlpAccount.RowCount = 6;
            tlpAccount.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpAccount.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tlpAccount.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpAccount.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tlpAccount.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpAccount.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            tlpAccount.TabIndex = 41;
            // 
            // lblUsername
            // 
            lblUsername.Dock = DockStyle.Fill;
            lblUsername.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(73, 80, 87);
            lblUsername.Margin = new Padding(0, 0, 8, 0);
            lblUsername.Name = "lblUsername";
            lblUsername.TabIndex = 42;
            lblUsername.Text = "Username";
            lblUsername.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblAccountStatus
            // 
            lblAccountStatus.Dock = DockStyle.Fill;
            lblAccountStatus.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblAccountStatus.ForeColor = Color.FromArgb(73, 80, 87);
            lblAccountStatus.Margin = new Padding(8, 0, 0, 0);
            lblAccountStatus.Name = "lblAccountStatus";
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
            txtUsername.Margin = new Padding(0, 3, 8, 3);
            txtUsername.Name = "txtUsername";
            txtUsername.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 255);
            txtUsername.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtUsername.StateCommon.Border.Rounding = 12F;
            txtUsername.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtUsername.TabIndex = 44;
            // 
            // cmbAccountStatus
            // 
            cmbAccountStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccountStatus.Dock = DockStyle.Fill;
            cmbAccountStatus.Margin = new Padding(8, 3, 0, 3);
            cmbAccountStatus.Name = "cmbAccountStatus";
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
            lblRole.Margin = new Padding(0, 0, 8, 0);
            lblRole.Name = "lblRole";
            lblRole.TabIndex = 46;
            lblRole.Text = "Role";
            lblRole.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblNewPassword
            // 
            lblNewPassword.Dock = DockStyle.Fill;
            lblNewPassword.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblNewPassword.ForeColor = Color.FromArgb(73, 80, 87);
            lblNewPassword.Margin = new Padding(8, 0, 0, 0);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.TabIndex = 47;
            lblNewPassword.Text = "New Password";
            lblNewPassword.TextAlign = ContentAlignment.BottomLeft;
            // 
            // cmbRole
            // 
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Dock = DockStyle.Fill;
            cmbRole.Margin = new Padding(0, 3, 8, 3);
            cmbRole.Name = "cmbRole";
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
            txtNewPassword.Margin = new Padding(8, 3, 0, 3);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.UseSystemPasswordChar = true;
            txtNewPassword.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 255);
            txtNewPassword.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtNewPassword.StateCommon.Border.Rounding = 12F;
            txtNewPassword.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtNewPassword.TabIndex = 49;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.Dock = DockStyle.Fill;
            lblConfirmPassword.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblConfirmPassword.ForeColor = Color.FromArgb(73, 80, 87);
            lblConfirmPassword.Margin = new Padding(0, 0, 8, 0);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.TabIndex = 50;
            lblConfirmPassword.Text = "Confirm Password";
            lblConfirmPassword.TextAlign = ContentAlignment.BottomLeft;
            // 
            // lblLastLoginCaption
            // 
            lblLastLoginCaption.Dock = DockStyle.Fill;
            lblLastLoginCaption.Font = new Font("Century Gothic", 8.5F, FontStyle.Bold);
            lblLastLoginCaption.ForeColor = Color.FromArgb(73, 80, 87);
            lblLastLoginCaption.Margin = new Padding(8, 0, 0, 0);
            lblLastLoginCaption.Name = "lblLastLoginCaption";
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
            txtConfirmPassword.Margin = new Padding(0, 3, 8, 3);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.StateCommon.Back.Color1 = Color.FromArgb(255, 255, 255);
            txtConfirmPassword.StateCommon.Border.Color1 = Color.FromArgb(222, 226, 230);
            txtConfirmPassword.StateCommon.Border.Rounding = 12F;
            txtConfirmPassword.StateCommon.Content.Font = new Font("Century Gothic", 9.5F);
            txtConfirmPassword.TabIndex = 52;
            // 
            // lblLastLogin
            // 
            lblLastLogin.Dock = DockStyle.Fill;
            lblLastLogin.Font = new Font("Century Gothic", 9.5F);
            lblLastLogin.ForeColor = Color.FromArgb(44, 49, 53);
            lblLastLogin.Margin = new Padding(8, 3, 0, 3);
            lblLastLogin.Name = "lblLastLogin";
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
            flpAccountButtons.Margin = new Padding(0);
            flpAccountButtons.Name = "flpAccountButtons";
            flpAccountButtons.Padding = new Padding(0, 10, 0, 6);
            flpAccountButtons.TabIndex = 54;
            // 
            // btnSaveAccount
            // 
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
            flpAccountButtons.ResumeLayout(false);
            tlpAccount.ResumeLayout(false);
            flpEmployeeButtons.ResumeLayout(false);
            pnlEmpNo.ResumeLayout(false);
            tlpEmployee.ResumeLayout(false);
            tlpEditor.ResumeLayout(false);
            pnlEditorScroll.ResumeLayout(false);
            pnlEditorCard.ResumeLayout(false);
            pnlAdminsCard.ResumeLayout(false);
            pnlPersonnelTools.ResumeLayout(false);
            pnlPersonnelCard.ResumeLayout(false);
            tlpLeft.ResumeLayout(false);
            tlpBody.ResumeLayout(false);
            pnlHeader.ResumeLayout(false);
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)cmbFilter).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvPersonnel).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAdmins).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbEmploymentStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbAccountStatus).EndInit();
            ((System.ComponentModel.ISupportInitialize)cmbRole).EndInit();
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