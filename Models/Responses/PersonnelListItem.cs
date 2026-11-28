namespace PMS_v1.Models.Responses
{
    // One row of the Settings page personnel table: an employee and the status of their system account (if any).
    public class PersonnelListItem
    {
        public int PersonnelId { get; set; }
        public string EmployeeNo { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? Position { get; set; }
        public string EmploymentStatus { get; set; } = "";

        // false = the employee has no system account yet
        public bool HasAccount { get; set; }

        public string? AccountStatus { get; set; }
        public string? Role { get; set; }
    }
}
