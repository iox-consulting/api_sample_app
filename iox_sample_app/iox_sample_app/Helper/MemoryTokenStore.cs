using iox_sample_app.Responses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iox_sample_app.Helper.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace iox_sample_app.Helper
{
    public class MemoryTokenStore: IMemoryTokenStore
    {
        private readonly Dictionary<string, TokenResponse> _tokens = new Dictionary<string, TokenResponse>();
        private readonly IoxSettings _ioxSettings;

        public MemoryTokenStore(IOptions<IoxSettings> settings)
        {
            _ioxSettings = settings.Value;
        }

        public TokenResponse GetAccessToken()
        {
            if (!_tokens.ContainsKey(_ioxSettings.tenantId))
                return null;

            return _tokens[_ioxSettings.tenantId];
        }

        public void SetToken(TokenResponse ioxToken)
        {
            _tokens[_ioxSettings.tenantId] = ioxToken;
        }
    }
}