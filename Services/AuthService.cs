using PMS_v1.DataAccess;
using PMS_v1.Helper;
using PMS_v1.Models.Requests;
using PMS_v1.Models.Responses;

namespace PMS_v1.Services
{
    // SERVICE for login and sign-up: the rules and the order of the steps.
    // The forms call this; this calls AuthData for anything that needs the database.
    // Database errors are NOT caught here - they go back to the form, which shows them with ErrorHandler.
    public class AuthService
    {
        private readonly AuthData _data = new AuthData();

        public LoginResponse Login(string username, string password)
        {
            LoginAccount? account = _data.FindLoginAccount(username);

            if (account == null || !BCrypt.Net.BCrypt.Verify(password, account.PasswordHash))
                return LoginResponse.Fail("INVALID USERNAME OR PASSWORD.");

            // Settings can mark an account Inactive / Suspended / Locked; only Active accounts may sign in
            if (account.AccountStatus != "Active")
                return LoginResponse.Fail($"This account is {account.AccountStatus.ToLower()}.\nContact your administrator.");

            // an employee who is on leave, resigned or terminated may not sign in, even with an Active account
            if (account.EmploymentStatus != "Active")
                return LoginResponse.Fail($"This employee record is {account.EmploymentStatus.ToLower()}.\nContact your administrator.");

            Session.Role = account.Role;
            Session.UserId = account.UserId;
            Session.PersonnelId = account.PersonnelId;

            _data.UpdateLastLogin(account.UserId);

            return LoginResponse.Ok(account.FirstName + " " + account.LastName, account.Position, account.EmployeeNo);
        }

        public SignUpResponse SignUp(SignUpRequest request)
        {
            // checking if employee is in db
            SignUpCandidate? employee = _data.FindEmployeeForSignUp(request.EmployeeNo, request.LastName);

            if (employee == null)
                return SignUpResponse.NotFound("Employee No. and last name do not match our records.\n" +
                                               "Contact your administrator.");

            if (employee.EmploymentStatus != "Active")
                return SignUpResponse.Fail("This employee record is not active.");

            if (employee.ExistingUserId != null)
                return SignUpResponse.Fail("This employee already has an account. Please log in.");

            // create the account
            _data.CreateAccount(employee.PersonnelId, request.Username, BCrypt.Net.BCrypt.HashPassword(request.Password));

            return SignUpResponse.Ok();
        }
    }
}
