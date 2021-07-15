using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iox_sample_app.Requests
{
    public class CreateQuoteRequestRealtime
    {
        [Required]
        public string accountReference { get; set; }
        [Required]
        public List<string> vehicleRegisterNumbers { get; set; }
        [Required]
        public CreateQuoteRequestAddress Address { get; set; }
    }
}
