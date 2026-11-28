using System;

namespace PMS_v1.Models.Responses
{
    // Everything the Lease window shows. Tenant, unit and recorder fields are null when that record is missing.
    public class LeaseDetail
    {
        public int LeaseId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MonthlyRent { get; set; }
        public decimal Deposit { get; set; }
        public string Status { get; set; } = "";
        public DateTime UpdatedAt { get; set; }

        public string? ResidentFirstName { get; set; }
        public string? ResidentLastName { get; set; }
        public string? ResidentContactNo { get; set; }

        public string? UnitNo { get; set; }
        public int? FloorNo { get; set; }
        public string? UnitType { get; set; }

        // the unit's photo; null when it has none
        public byte[]? Photo { get; set; }

        // the employee who recorded the lease
        public string? RecorderFirstName { get; set; }
        public string? RecorderLastName { get; set; }
        public string? RecorderPosition { get; set; }
    }
}
