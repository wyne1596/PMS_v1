using System;

namespace PMS_v1.Models.Requests
{
    // The values the New / Edit Resident form sends down to be saved. Optional fields are null when left blank.
    public class SaveResidentRequest
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? EmergencyContactNo { get; set; }
    }
}
