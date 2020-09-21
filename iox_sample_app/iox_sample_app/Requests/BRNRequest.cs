using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iox_sample_app.Requests
{
    public class BRNRequest
    {
        public string brn { get; set; }
        public string individualIdNumber { get; set; }
        public string referenceId { get; set; }
        public string accountReference { get; set; }
    }
}
