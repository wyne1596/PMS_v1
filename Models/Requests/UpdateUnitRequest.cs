namespace PMS_v1.Models.Requests
{
    // The values the Edit Unit form sends down to be saved.
    public class UpdateUnitRequest
    {
        public string UnitNo { get; set; } = "";
        public int Floor { get; set; }
        public string UnitType { get; set; } = "";
        public decimal BaseRent { get; set; }
        public string Status { get; set; } = "";
    }
}
