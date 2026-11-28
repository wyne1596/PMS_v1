namespace PMS_v1.Models.Requests
{
    // What the Sign Up form sends down: the values the person typed in.
    public class SignUpRequest
    {
        public string EmployeeNo { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";
        public string ConfirmPassword { get; set; } = "";
    }
}
