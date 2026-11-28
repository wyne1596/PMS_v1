using System;

namespace PMS_v1.Models.Requests
{
    // The values the New Request form sends down to be saved.
    public class CreateMaintenanceRequest
    {
        public int? UnitId { get; set; }
        public int? ResidentId { get; set; }
        public string? Problem { get; set; }
        public string? MaintenanceType { get; set; }
        public string? Priority { get; set; }
        public DateTime? DateReported { get; set; }
    }
}
