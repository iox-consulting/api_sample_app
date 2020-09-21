using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iox_sample_app.Responses
{
    public class Quote
    {
        public Quote()
        {
            items = new List<QuoteItem>();
            fines = new List<FineItem>();
        }

        public string reference { get; set; }
        public int serviceFee { get; set; }
        public int serviceFeeVat { get; set; }
        public int vatExemptAmount { get; set; }
        public string expiresAt { get; set; }
        public List<QuoteItem> items { get; set; }
        public List<FineItem> fines { get; set; }
    }

    public class QuoteItem
    {
        public string reference { get; set; }
        public string description { get; set; }
        public int serviceFee { get; set; }
        public int serviceFeeVat { get; set; }
        public int vatExemptAmount { get; set; }
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
