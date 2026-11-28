using System;

namespace PMS_v1.Models.Responses
{
    // One row of the Residents page table.
    public class ResidentListItem
    {
        public int ResidentId { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string? ContactNo { get; set; }
        public string? Email { get; set; }
        public DateTime? Birthdate { get; set; }
        public string? EmergencyContactNo { get; set; }

        // true when the resident has an Active lease
        public bool HasLease { get; set; }
    }
}
