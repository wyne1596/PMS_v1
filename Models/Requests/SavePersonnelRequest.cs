namespace PMS_v1.Models.Requests
{
    // The values the Employee editor on the Settings page sends down to be saved.
    // Optional fields are empty strings when left blank (they are saved as NULL).
    public class SavePersonnelRequest
    {
        // only used when adding a new employee (an existing employee keeps their number)
        public string EmployeeNo { get; set; } = "";

        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Position { get; set; } = "";
        public string ContactNo { get; set; } = "";
        public string Email { get; set; } = "";
        public string EmploymentStatus { get; set; } = "";
    }
}
