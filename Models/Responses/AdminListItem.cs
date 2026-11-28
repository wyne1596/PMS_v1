using System;

namespace PMS_v1.Models.Responses
{
    // One row of the Settings page "system admins" table.
    public class AdminListItem
    {
        public int PersonnelId { get; set; }
        public string EmployeeNo { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Username { get; set; } = "";
        public string AccountStatus { get; set; } = "";

        // null = has never signed in
        public DateTime? LastLogin { get; set; }
    }
}
