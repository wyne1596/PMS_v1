using System.Text.RegularExpressions;

namespace PMS_v1.Validators
{
    // Checks what was typed in the Account section on the Settings page BEFORE the database is touched.
    // Validate() returns the message to show, or null when everything is fine.
    public static class AccountValidator
    {
        private const int MinPassLen = 6;     // same rule as the Sign Up form

        public static string? Validate(string username, string role, string status, string password, string confirmPassword)
        {
            return
                !Regex.IsMatch(username, @"^[A-Za-z0-9_]{4,20}$") ? "Username must be 4-20 letters, numbers, or underscores." :
                string.IsNullOrEmpty(role) || string.IsNullOrEmpty(status) ? "Choose a role and an account status." :
                password.Length > 0 && password.Length < MinPassLen ? $"Password must be at least {MinPassLen} characters." :
                password != confirmPassword ? "Passwords do not match." : null;
        }
    }
}
