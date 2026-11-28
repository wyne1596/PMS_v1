using System;

namespace PMS_v1.Models.Entities
{
    // One row of the `resident` table.
    public class Resident
    {
        public int ResidentId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? EmergencyContactNo { get; set; }
    }
}
