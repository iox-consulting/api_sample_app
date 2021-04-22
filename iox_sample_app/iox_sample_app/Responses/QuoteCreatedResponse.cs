using System.Collections.Generic;

namespace iox_sample_app.Responses
{
    public class QuoteCreatedResponse
    {
        public string reference { get; set; }
        public int serviceFee { get; set; }
        public int serviceFeeVat { get; set; }
        public int vatExemptAmount { get; set; }
        public string expiresAt { get; set; }
        public List<QuoteItem> items { get; set; }
        public List<FineItem> fines { get; set; }
        public List<LicensingItem> licensingItems { get; set; }

    }

    public class QuoteItem
    {
        public string reference { get; set; }
        public string description { get; set; }
        public int serviceFee { get; set; }
        public int serviceFeeVat { get; set; }
        public int vatExemptAmount { get; set; }
    }

    public class LicensingItem
    {
        public string vehicleRegisterNumber { get; set; }
        public string vehicleLicenseNumber { get; set; }
        public string description { get; set; }
        public bool debtPayable { get; set; }
        public int localAuthorityFee { get; set; }
        public int transactionFee { get; set; }
        public int arrearsFee { get; set; }
        public int penaltyFee { get; set; }

    }


    public class FineItem
    {
        public string reference { get; set; }
        public string noticeNumber { get; set; }
        public int fineAmount { get; set; }
        public string status { get; set; }
        public string location { get; set; }
        public string offenceDate { get; set; }
        public string chargeCode { get; set; }
        public string vehicleLicensePlate { get; set; }
    }
}
