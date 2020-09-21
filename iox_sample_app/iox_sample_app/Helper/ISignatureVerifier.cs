using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iox_sample_app.Helper
{
    public interface ISignatureVerifier
    {
        bool VerifySignature(string payload, string hmac);
    }
}
