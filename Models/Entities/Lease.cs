using System;

namespace PMS_v1.Models.Entities
{
    // One row of the `lease` table.
    public class Lease
    {
        public int LeaseId { get; set; }
        public int ResidentId { get; set; }
        public int UnitId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MonthlyRent { get; set; }
        public decimal Deposit { get; set; }
        public string Status { get; set; } = "";

        // used to notice when someone else changed the lease while a form was open
        public DateTime UpdatedAt { get; set; }
    }
}
