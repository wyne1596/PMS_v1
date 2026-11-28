using System;

namespace PMS_v1.Models.Requests
{
    // The values the Edit Request form sends down to be saved (everything in New Request, plus the repair details).
    public class UpdateMaintenanceRequest : CreateMaintenanceRequest
    {
        public string? Status { get; set; }
        public int? PersonnelId { get; set; }
        public DateTime? DateCompleted { get; set; }
        public decimal Cost { get; set; }
        public string? RepairDetails { get; set; }
    }
}
