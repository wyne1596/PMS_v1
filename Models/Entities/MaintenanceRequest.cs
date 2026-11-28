using System;

namespace PMS_v1.Models.Entities
{
    // One row of the `maintenance_request` table.
    public class MaintenanceRequest
    {
        public int ReportId { get; set; }

        // null = a common area (not a unit)
        public int? UnitId { get; set; }

        // null = reporter not specified
        public int? ResidentId { get; set; }

        public string Problem { get; set; } = "";
        public string MaintenanceType { get; set; } = "";
        public string Priority { get; set; } = "";
        public DateTime DateReported { get; set; }
        public string Status { get; set; } = "";

        // the technician the request is assigned to; null = not yet assigned
        public int? PersonnelId { get; set; }

        public DateTime? DateCompleted { get; set; }
        public decimal Cost { get; set; }
        public string? RepairDetails { get; set; }
    }
}
