using System;
using PMS_v1.Models.Entities;

namespace PMS_v1.Models.Responses
{
    // Everything the Unit window shows: the unit itself, how many requests are open, and the current tenant.
    public class UnitDetail
    {
        public Unit Unit { get; set; } = new Unit();
        public int OpenRequests { get; set; }

        // null = nobody has an active lease on this unit
        public UnitTenant? Tenant { get; set; }
    }

    // The tenant of a unit's active lease.
    public class UnitTenant
    {
        public string Name { get; set; } = "";
        public string ContactNo { get; set; } = "";
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal MonthlyRent { get; set; }
        public decimal Deposit { get; set; }
    }
}
