using System;

namespace PMS_v1.Models.Requests
{
    // The values the Edit Lease form sends down to be saved. (Tenant and unit cannot be changed.)
    public class UpdateLeaseRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MonthlyRent { get; set; }
        public decimal Deposit { get; set; }
        public string Status { get; set; } = "";
    }
}
