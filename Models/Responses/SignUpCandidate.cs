namespace PMS_v1.Models.Responses
{
    // The personnel row that matches the Employee No. + last name typed on the Sign Up form.
    public class SignUpCandidate
    {
        public int PersonnelId { get; set; }
        public string EmploymentStatus { get; set; } = "";

        // null = this employee has no account yet
        public int? ExistingUserId { get; set; }
    }
}
