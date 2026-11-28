using System;

namespace PMS_v1.Models.Requests
{
    // The values the New Lease form sends down to be saved.
    // (The monthly rent is not here: it is copied from the unit's base rent when the lease is saved.)
    public class CreateLeaseRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UnitId { get; set; }
        public int ResidentId { get; set; }
        public decimal Deposit { get; set; }
        public string Status { get; set; } = "";

        // the signed-in employee who records the lease
        public int PersonnelId { get; set; }
    }
}
