using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iox_sample_app.Requests
{
    public class CreateQuoteRequest
    {
        public string referenceId { get; set; }
        public string accountReference { get; set; }
        public List<string> vehicleRegisterNumbers { get; set; }
        public CreateQuoteRequestAddress Address { get; set; }
    }

    public class CreateQuoteRequestAddress
    {
        public string StreetNumber { get; set; }
        public string StreetName { get; set; }
        public string Suburb { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string ContactPerson { get; set; }
        public string ContactEmail { get; set; }
        public string ContactNumber { get; set; }
        public string SecondaryContactNumber { get; set; }
    }
}
