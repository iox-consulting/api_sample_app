using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iox_sample_app.Responses
{
    public class AccountOTPResponse
    {
        public int otp { get; set; }
        public string accountReference { get; set; }
        public DateTime validUntil { get; set; }
    }
}
