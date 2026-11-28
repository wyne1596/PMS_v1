using System;

namespace PMS_v1.Models.Responses
{
    // One row of the Leasing page table.
    public class LeaseListItem
    {
        public int LeaseId { get; set; }

        // blank when the resident is missing
        public string Tenant { get; set; } = "";

        public string UnitNo { get; set; } = "";
        public int? FloorNo { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = "";
    }
}
