using System.Text.RegularExpressions;
using PMS_v1.Models.Requests;

namespace PMS_v1.Validators
{
    // Checks what was typed on the Sign Up form BEFORE the database is touched.
    // Validate() returns the message to show, or null when everything is fine.
    public static class SignUpValidator
    {
        private const int minPassLen = 6;

        public static string? Validate(SignUpRequest request)
        {
            if (string.IsNullOrEmpty(request.EmployeeNo) || string.IsNullOrEmpty(request.LastName) ||
                string.IsNullOrEmpty(request.Username) || string.IsNullOrEmpty(request.Password))
                return "Please fill in all fields.";

            if (!Regex.IsMatch(request.EmployeeNo, @"^\d{4}-\d{5}$"))
                return "Employee No. looks like 2026-12345.";

            if (!Regex.IsMatch(request.Username, @"^[A-Za-z0-9_]{4,20}$"))
                return "Username must be 4-20 letters, numbers, or underscores.";

            if (request.Password.Length < minPassLen)
                return $"Password must be at least {minPassLen} characters.";

            if (request.Password != request.ConfirmPassword)
                return "Passwords do not match.";

            return null;
        }
    }
}
