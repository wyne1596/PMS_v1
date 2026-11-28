using System;

namespace PMS_v1.Models.Requests
{
    // The values the Record Payment form sends down to be saved.
    public class RecordPaymentRequest
    {
        public int BillingId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string Mode { get; set; } = "";

        // a reference no. typed on the form (bank or e-wallet transaction no.); null = create one when saving
        public string? RefNo { get; set; }

        // the staff member recording the payment; null when unknown
        public int? PersonnelId { get; set; }
    }
}
