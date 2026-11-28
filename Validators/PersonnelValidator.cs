using System.Text.RegularExpressions;
using PMS_v1.Models.Requests;

namespace PMS_v1.Validators
{
    // Checks what was typed in the Employee editor on the Settings page BEFORE the database is touched.
    // Validate() returns the message to show, or null when everything is fine.
    public static class PersonnelValidator
    {
        public static string? Validate(SavePersonnelRequest request)
        {
            string first = request.FirstName;
            string last = request.LastName;
            string position = request.Position;
            string contact = request.ContactNo;
            string email = request.Email;
            string status = request.EmploymentStatus;

            return
                first.Length == 0 || last.Length == 0 ? "First name and last name are required." :
                first.Length > 45 || last.Length > 45 || position.Length > 45 ? "Names and position can be at most 45 characters." :
                contact.Length > 0 && !Regex.IsMatch(contact, @"^09\d{9}$") ? "Contact No. must be 11 digits starting with 09, for example 09123456789." :
                email.Length > 0 && (email.Length > 100 || !Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$")) ? "Enter a valid email address." :
                string.IsNullOrEmpty(status) ? "Choose an employment status." : null;
        }
    }
}
