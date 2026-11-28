using System;

namespace PMS_v1.Models.Responses
{
    // One employee as shown in the Settings page editor, with their system account (if they have one).
    public class EmployeeDetail
    {
        public string EmployeeNo { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Position { get; set; } = "";
        public string ContactNo { get; set; } = "";
        public string Email { get; set; } = "";
        public string EmploymentStatus { get; set; } = "";

        // null = the employee has no system account
        public AccountSummary? Account { get; set; }
    }

    // The system account of an employee.
    public class AccountSummary
    {
        public int UserId { get; set; }
        public string Username { get; set; } = "";
        public string Role { get; set; } = "Staff";
        public string Status { get; set; } = "Active";

        // null = has never signed in
        public DateTime? LastLogin { get; set; }
    }
}
