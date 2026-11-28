namespace PMS_v1.Models.Responses
{
    // The outcome of a sign-up attempt.
    public class SignUpResponse
    {
        public bool Success { get; private set; }
        public string Message { get; private set; } = "";

        // true when no employee matched; the Sign Up form counts these toward its attempt limit
        public bool EmployeeNotFound { get; private set; }

        public static SignUpResponse Fail(string message) =>
            new SignUpResponse { Success = false, Message = message };

        public static SignUpResponse NotFound(string message) =>
            new SignUpResponse { Success = false, Message = message, EmployeeNotFound = true };

        public static SignUpResponse Ok() =>
            new SignUpResponse { Success = true };
    }
}
