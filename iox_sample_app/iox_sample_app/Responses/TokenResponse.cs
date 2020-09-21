using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iox_sample_app.Responses
{
    public class TokenResponse
    {
        public string token { get; set; }
        public DateTime expiresAt { get; set; }
    }
}
