using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iox_sample_app.Responses;

namespace iox_sample_app.Helper.Interfaces
{
    public interface IMemoryTokenStore
    {
        TokenResponse GetAccessToken();
        void SetToken(TokenResponse ioxToken);
    }
}
