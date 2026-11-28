namespace PMS_v1.Models.Responses
{
    // The outcome of a login attempt: either a message to show, or the details for the welcome box.
    public class LoginResponse
    {
        public bool Success { get; private set; }
        public string Message { get; private set; } = "";
        public string FullName { get; private set; } = "";
        public string Position { get; private set; } = "";
        public string EmployeeNo { get; private set; } = "";

        public static LoginResponse Fail(string message) =>
            new LoginResponse { Success = false, Message = message };

        public static LoginResponse Ok(string fullName, string position, string employeeNo) =>
            new LoginResponse { Success = true, FullName = fullName, Position = position, EmployeeNo = employeeNo };
    }
}
