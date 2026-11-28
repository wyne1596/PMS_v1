namespace PMS_v1.Models.Responses
{
    // One system_user row joined with its personnel row, as read for a login attempt.
    public class LoginAccount
    {
        public int UserId { get; set; }
        public int PersonnelId { get; set; }
        public string PasswordHash { get; set; } = "";
        public string Role { get; set; } = "";
        public string AccountStatus { get; set; } = "";
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Position { get; set; } = "";
        public string EmployeeNo { get; set; } = "";
        public string EmploymentStatus { get; set; } = "";
    }
}
