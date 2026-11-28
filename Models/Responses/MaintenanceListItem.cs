using System;

namespace PMS_v1.Models.Responses
{
    // One row of the Maintenance page table.
    public class MaintenanceListItem
    {
        public int ReportId { get; set; }

        // null = a common area
        public string? UnitNo { get; set; }

        public string Problem { get; set; } = "";
        public string MaintenanceType { get; set; } = "";
        public DateTime DateReported { get; set; }
        public string Status { get; set; } = "";
        public string Priority { get; set; } = "";
    }
}
