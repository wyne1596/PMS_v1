using System;

namespace PMS_v1.Models.Responses
{
    // Everything the Request window shows. Reporter and technician fields are null when nobody is set.
    public class MaintenanceDetail
    {
        public int ReportId { get; set; }

        // null = a common area
        public string? UnitNo { get; set; }

        public string? ReporterFirstName { get; set; }
        public string? ReporterLastName { get; set; }
        public string? ReporterContactNo { get; set; }

        public string? TechnicianFirstName { get; set; }
        public string? TechnicianLastName { get; set; }
        public string? TechnicianPosition { get; set; }

        public string Problem { get; set; } = "";
        public string MaintenanceType { get; set; } = "";
        public string Priority { get; set; } = "";
        public string Status { get; set; } = "";
        public DateTime DateReported { get; set; }
        public DateTime? DateCompleted { get; set; }
        public decimal Cost { get; set; }
        public string? RepairDetails { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
