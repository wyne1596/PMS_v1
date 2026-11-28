using MySql.Data.MySqlClient;
using PMS_v1.Data;
using PMS_v1.DataAccess;
using PMS_v1.ExceptionHandler;
using PMS_v1.Helper;
using PMS_v1.Models.Requests;
using PMS_v1.Models.Responses;
using PMS_v1.Services;
using PMS_v1.UserControls;
using PMS_v1.Validators;
using System;
using System.Drawing;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PMS_v1.Pages.Content.Settings
{
    /// <summary>
    /// Settings (admins full access; managers can view and add employees only). Left half: personnel table + system admins list.
    /// Right half: add / edit an employee and manage that employee's system account.
    /// </summary>
    public partial class SettingsModule : UserControl
    {
        private readonly PersonnelData _personnelData = new PersonnelData();
        private readonly UserAccountData _userAccountData = new UserAccountData();
        private readonly AccountService _accountService = new AccountService();

        private static readonly string[] EmploymentStatuses = { "Active", "On Leave", "Resigned", "Terminated" };
        private static readonly string[] Roles = { "Admin", "Manager", "Staff" };
        private static readonly string[] AccountStatuses = { "Active", "Inactive", "Suspended", "Locked" };

        private int? _personnelId;      // null = the editor is adding a new employee
        private int? _userId;           // null = the selected employee has no account
        private string _loadedUsername = "";
        private bool _loading;          // true while code (not the user) changes the grid selection

        public SettingsModule()
        {
            InitializeComponent();

            // Admins and managers only. The menu hides the button and Main refuses the page too; this is the last guard.
            if (!Session.CanOpenSettings) { tlpMain.Enabled = false; return; }

            ModulePageLayout.ApplyStandardGridStyle(dgvPersonnel);
            ModulePageLayout.ApplyStandardGridStyle(dgvAdmins);
            ConfigureGrids();

            cmbFilter.Items.AddRange(new object[] { "All Personnel", "With Account", "No Account", "System Admins" });
            cmbFilter.SelectedIndex = 0;
            cmbEmploymentStatus.Items.AddRange(EmploymentStatuses);
            cmbRole.Items.AddRange(Roles);
            cmbAccountStatus.Items.AddRange(AccountStatuses);

            txtSearch.TextChanged += (_, _) => ApplyFilters();
            cmbFilter.SelectedIndexChanged += (_, _) => ApplyFilters();
            dgvPersonnel.SelectionChanged += DgvPersonnel_SelectionChanged;
            dgvPersonnel.CellPainting += (_, e) =>
            {
                StatusBadge.Paint(dgvPersonnel, e, "Employment");
                StatusBadge.Paint(dgvPersonnel, e, "Account", s => s == "None" ? "No account" : s);
            };
            StatusBadge.Attach(dgvAdmins, "Status");
            dgvAdmins.CellClick += (_, e) =>
            {
                // clicking an admin opens that person in the editor
                if (e.RowIndex >= 0 && dgvAdmins.Rows[e.RowIndex].Tag is int id)
                {
                    _personnelId = id;
                    RefreshGrids();
                    LoadEditor(id);
                }
            };

            ClearEditor();
        }

        // refresh every time the page is opened (Main keeps the page alive between visits)
        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);
            if (Visible && Session.CanOpenSettings && dgvPersonnel.Columns.Count > 0)
                RefreshGrids();
        }

        // ---------- grids ----------
        private void ConfigureGrids()
        {
            AddColumn(dgvPersonnel, "EmpNo", "EMPLOYEE NO.", 17);
            AddColumn(dgvPersonnel, "Name", "NAME", 27);
            AddColumn(dgvPersonnel, "Position", "POSITION", 18);
            AddColumn(dgvPersonnel, "Employment", "EMPLOYMENT", 19, DataGridViewContentAlignment.MiddleCenter);
            AddColumn(dgvPersonnel, "Account", "ACCOUNT", 19, DataGridViewContentAlignment.MiddleCenter);
            AddColumn(dgvPersonnel, "Role", "ROLE", 10);
            dgvPersonnel.Columns["Role"].Visible = false;       // only used by the "System Admins" filter

            AddColumn(dgvAdmins, "EmpNo", "EMPLOYEE NO.", 18);
            AddColumn(dgvAdmins, "Name", "NAME", 26);
            AddColumn(dgvAdmins, "Username", "USERNAME", 20);
            AddColumn(dgvAdmins, "Status", "STATUS", 16, DataGridViewContentAlignment.MiddleCenter);
            AddColumn(dgvAdmins, "LastLogin", "LAST LOGIN", 20);
        }

        private static void AddColumn(DataGridView grid, string name, string header, float weight,
            DataGridViewContentAlignment align = DataGridViewContentAlignment.MiddleLeft)
        {
            grid.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = name,
                HeaderText = header,
                FillWeight = weight,
                SortMode = DataGridViewColumnSortMode.NotSortable,
                DefaultCellStyle = new DataGridViewCellStyle { Alignment = align }
            });
        }

        private void RefreshGrids()
        {
            LoadPersonnel();
            LoadAdmins();
        }

        private void LoadPersonnel()
        {
            _loading = true;
            try
            {
                List<PersonnelListItem> people = _personnelData.GetAll();

                dgvPersonnel.Rows.Clear();
                foreach (PersonnelListItem p in people)
                {
                    int i = dgvPersonnel.Rows.Add(
                        p.EmployeeNo,
                        p.FirstName + " " + p.LastName,
                        Show(p.Position),
                        p.EmploymentStatus,
                        p.HasAccount ? p.AccountStatus : "None",
                        p.HasAccount ? p.Role : "");
                    dgvPersonnel.Rows[i].Tag = p.PersonnelId;
                }
            }
            finally { _loading = false; }

            ApplyFilters();
        }

        private void LoadAdmins()
        {
            List<AdminListItem> admins = _userAccountData.GetAdmins();

            dgvAdmins.Rows.Clear();
            foreach (AdminListItem a in admins)
            {
                int i = dgvAdmins.Rows.Add(
                    a.EmployeeNo,
                    a.FirstName + " " + a.LastName,
                    a.Username,
                    a.AccountStatus,
                    a.LastLogin is DateTime d ? d.ToString("MMM dd, yyyy h:mm tt") : "Never");
                dgvAdmins.Rows[i].Tag = a.PersonnelId;
            }
            dgvAdmins.ClearSelection();
        }

        private void ApplyFilters()
        {
            string search = txtSearch.Text.Trim();
            int filter = cmbFilter.SelectedIndex;      // 0 all, 1 with account, 2 no account, 3 admins

            _loading = true;
            try
            {
                GridHelper.Filter(dgvPersonnel, row =>
                {
                    bool matchesSearch = string.IsNullOrEmpty(search) ||
                        GridHelper.Has(row, "EmpNo", search) ||
                        GridHelper.Has(row, "Name", search) ||
                        GridHelper.Has(row, "Position", search);

                    string account = row.Cells["Account"].Value?.ToString() ?? "None";
                    string role = row.Cells["Role"].Value?.ToString() ?? "";
                    bool matchesFilter = filter <= 0 ||
                        (filter == 1 && account != "None") ||
                        (filter == 2 && account == "None") ||
                        (filter == 3 && role == "Admin");

                    return matchesSearch && matchesFilter;
                });

                // keep the employee being edited highlighted
                if (_personnelId is int id)
                    foreach (DataGridViewRow row in dgvPersonnel.Rows)
                        if (row.Visible && row.Tag is int rid && rid == id)
                        {
                            dgvPersonnel.CurrentCell = row.Cells[0];
                            break;
                        }
            }
            finally { _loading = false; }
        }

        private void DgvPersonnel_SelectionChanged(object? sender, EventArgs e)
        {
            if (_loading) return;
            if (dgvPersonnel.CurrentRow?.Tag is int id && id != _personnelId)
                LoadEditor(id);
        }

        // ---------- editor ----------
        private void ClearEditor()
        {
            _personnelId = null;
            _userId = null;
            _loadedUsername = "";

            _loading = true;
            dgvPersonnel.CurrentCell = null;
            dgvPersonnel.ClearSelection();
            _loading = false;

            lblEmployeeTitle.Text = "New Employee";
            txtEmployeeNo.Text = GenerateEmployeeNo();
            btnGenerate.Enabled = true;
            txtFirstName.Clear();
            txtLastName.Clear();
            txtPosition.Clear();
            txtContact.Clear();
            txtEmail.Clear();
            cmbEmploymentStatus.SelectedItem = "Active";
            btnSaveEmployee.Values.Text = "Add Employee";
            tlpEmployee.Enabled = true;                    // admins and managers can both add
            SetEmployeeFieldsReadOnly(false);
            btnSaveEmployee.Enabled = true;
            flpEmployeeButtons.Enabled = true;

            ShowAccount(null);
            txtFirstName.Focus();
        }

        private void LoadEditor(int personnelId)
        {
            EmployeeDetail? emp = _personnelData.GetDetail(personnelId);

            if (emp == null)      // deleted elsewhere
            {
                ClearEditor();
                RefreshGrids();
                return;
            }

            _personnelId = personnelId;
            lblEmployeeTitle.Text = "Edit Employee";
            txtEmployeeNo.Text = emp.EmployeeNo;
            btnGenerate.Enabled = false;                   // an existing employee keeps their number
            txtFirstName.Text = emp.FirstName;
            txtLastName.Text = emp.LastName;
            txtPosition.Text = emp.Position;
            txtContact.Text = emp.ContactNo;
            txtEmail.Text = emp.Email;
            cmbEmploymentStatus.SelectedItem = emp.EmploymentStatus;
            btnSaveEmployee.Values.Text = "Save Changes";
            btnGenerate.Enabled = false;
            tlpEmployee.Enabled = true;
            SetEmployeeFieldsReadOnly(!Session.IsAdmin);   // managers can only change the employment status
            flpEmployeeButtons.Enabled = true;
            btnSaveEmployee.Enabled = true;
            if (!Session.IsAdmin) btnSaveEmployee.Values.Text = "Update Status";

            ShowAccount(emp.Account == null ? null : new AccountInfo
            {
                UserId = emp.Account.UserId,
                Username = emp.Account.Username,
                Role = emp.Account.Role,
                Status = emp.Account.Status,
                LastLogin = emp.Account.LastLogin
            });
        }

        // everything except Employment Status becomes read-only (used for managers on existing employees)
        private void SetEmployeeFieldsReadOnly(bool readOnly)
        {
            txtFirstName.ReadOnly = readOnly;
            txtLastName.ReadOnly = readOnly;
            txtPosition.ReadOnly = readOnly;
            txtContact.ReadOnly = readOnly;
            txtEmail.ReadOnly = readOnly;
        }

        private sealed class AccountInfo
        {
            public int UserId;
            public string Username = "";
            public string Role = "Staff";
            public string Status = "Active";
            public DateTime? LastLogin;
        }

        private void ShowAccount(AccountInfo? a)
        {
            _userId = a?.UserId;
            _loadedUsername = a?.Username ?? "";

            txtUsername.Text = a?.Username ?? "";
            cmbRole.SelectedItem = a?.Role;
            cmbAccountStatus.SelectedItem = a?.Status;
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
            lblLastLogin.Text = a == null ? "—" : a.LastLogin is DateTime d ? d.ToString("MMM dd, yyyy h:mm tt") : "Never";

            bool has = a != null;
            tlpAccount.Enabled = has && Session.IsAdmin;       // managers can't edit accounts
            flpAccountButtons.Enabled = has && Session.IsAdmin;
            lblAccountHint.Text = has
                ? (Session.IsAdmin ? "Leave the password blank to keep the current one." : "Only administrators can change accounts.")
                : _personnelId == null
                    ? "Save the employee first. They can then create their own account on the Sign Up screen using their Employee No. and last name."
                    : "This employee has no account yet. They can create one on the Sign Up screen using their Employee No. and last name.";
        }

        // ---------- random employee number ----------
        // Format YYYY-NNNNN (same as the existing records and the Sign Up check), unique in the personnel table.
        private static string GenerateEmployeeNo() => PersonnelService.GenerateEmployeeNo();

        private void btnGenerate_Click(object? sender, EventArgs e)
        {
            if (_personnelId == null) txtEmployeeNo.Text = GenerateEmployeeNo();
        }

        private void btnNewEmployee_Click(object? sender, EventArgs e) => ClearEditor();

        // ---------- save employee ----------
        private void btnSaveEmployee_Click(object? sender, EventArgs e)
        {
            string first = txtFirstName.Text.Trim();
            string last = txtLastName.Text.Trim();
            string position = txtPosition.Text.Trim();
            string contact = txtContact.Text.Trim();
            string email = txtEmail.Text.Trim();
            string status = cmbEmploymentStatus.Text;

            // managers can add employees and change the employment status of existing ones, nothing else
            if (_personnelId != null && !Session.IsAdmin)
            {
                SaveStatusOnly(status);
                return;
            }

            var request = new SavePersonnelRequest
            {
                FirstName = first,
                LastName = last,
                Position = position,
                ContactNo = contact,
                Email = email,
                EmploymentStatus = status
            };

            string? error = PersonnelValidator.Validate(request);

            if (error != null) { MessageBox.Show(this, error, "Check the form"); return; }

            bool isNew = _personnelId == null;

            for (int attempt = 0; attempt < 3; attempt++)
            {
                try
                {
                    int id;
                    request.EmployeeNo = txtEmployeeNo.Text;
                    if (isNew)
                    {
                        id = _personnelData.Create(request);
                    }
                    else
                    {
                        id = _personnelId!.Value;
                        _personnelData.Update(id, request);
                    }

                    _personnelId = id;
                    RefreshGrids();
                    LoadEditor(id);

                    if (isNew)
                        MessageBox.Show(this, $"Employee added.\nEmployee No.: {txtEmployeeNo.Text}", "Employee added");
                    return;
                }
                catch (MySqlException ex) when (ex.Number == 1062 && isNew && !ex.Message.Contains(ErrorRules.PersonnelEmailKey))
                {
                    txtEmployeeNo.Text = GenerateEmployeeNo();      // number was taken a moment ago: draw another
                }
                catch (Exception ex)
                {
                    ErrorHandler.Show(this, ex, ErrorRules.Personnel);
                    return;
                }
            }

            MessageBox.Show(this, "Couldn't generate a free employee number. Please try again.");
        }

        private void SaveStatusOnly(string status)
        {
            if (_personnelId is not int id) return;
            if (Array.IndexOf(EmploymentStatuses, status) < 0)
            {
                MessageBox.Show(this, "Choose an employment status.", "Check the form");
                return;
            }

            try
            {
                _personnelData.UpdateStatus(id, status);
                RefreshGrids();
                LoadEditor(id);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(this, ex);
            }
        }

        // ---------- save account ----------
        private void btnSaveAccount_Click(object? sender, EventArgs e)
        {
            if (!Session.IsAdmin || _userId is not int userId) return;

            string username = txtUsername.Text.Trim();
            string role = cmbRole.Text;
            string status = cmbAccountStatus.Text;
            string password = txtNewPassword.Text;

            string? error = AccountValidator.Validate(username, role, status, password, txtConfirmPassword.Text);

            if (error != null) { MessageBox.Show(this, error, "Check the form"); return; }

            bool losesAdminAccess = role != "Admin" || status != "Active";
            if (userId == Session.UserId && losesAdminAccess)
            {
                MessageBox.Show(this, "You can't remove your own admin access or deactivate your own account.");
                return;
            }
            if (losesAdminAccess && _accountService.IsLastActiveAdmin(userId))
            {
                MessageBox.Show(this, "This is the last active admin. Make another account an active admin first.");
                return;
            }

            try
            {
                _accountService.UpdateAccount(userId, username, role, status, password);

                int pid = _personnelId!.Value;
                RefreshGrids();
                LoadEditor(pid);
                MessageBox.Show(this, "Account updated.");
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(this, ex, ErrorRules.Account);
            }
        }

        // ---------- delete account ----------
        private void btnDeleteAccount_Click(object? sender, EventArgs e)
        {
            if (!Session.IsAdmin || _userId is not int userId) return;

            if (userId == Session.UserId)
            {
                MessageBox.Show(this, "You can't delete the account you are signed in with.");
                return;
            }
            if (_accountService.IsLastActiveAdmin(userId))
            {
                MessageBox.Show(this, "This is the last active admin and can't be deleted.");
                return;
            }

            if (MessageBox.Show(this,
                    $"Delete the account \"{_loadedUsername}\"?\n\nThe employee record stays, and they can sign up for a new account later.",
                    "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes) return;

            try
            {
                _userAccountData.DeleteAccount(userId);

                int pid = _personnelId!.Value;
                RefreshGrids();
                LoadEditor(pid);
            }
            catch (Exception ex)
            {
                ErrorHandler.Show(this, ex);
            }
        }

        // ---------- small helpers ----------
        private static string Show(object value) =>
            value == null || value is DBNull || string.IsNullOrWhiteSpace(value.ToString()) ? "—" : value.ToString()!;

        private static string Str(object value) => value is DBNull ? "" : Convert.ToString(value) ?? "";

        private static object NullIfEmpty(string s) => s.Length == 0 ? DBNull.Value : s;
    }
}