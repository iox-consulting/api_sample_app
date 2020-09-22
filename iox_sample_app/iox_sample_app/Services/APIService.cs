using iox_sample_app.Helper;
using iox_sample_app.Helper.Interfaces;
using iox_sample_app.Requests;
using iox_sample_app.Responses;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace iox_sample_app.Services
{
    public class APIService : IAPIService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IMemoryTokenStore _memoryTokenStore;
        private IoxSettings _ioxSettings;

        public APIService(IHttpClientFactory clientFactory, IMemoryTokenStore memoryTokenStore, IOptions<IoxSettings> settings)
        {
            _clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
            _memoryTokenStore = memoryTokenStore ?? throw new ArgumentNullException(nameof(memoryTokenStore));
            _ioxSettings = settings.Value;
        }

        private async Task<TokenResponse> RequestToken()
        {
            try
            {
                var client = _clientFactory.CreateClient("iox_auth");
                var result = await client.PostAsync(client.BaseAddress, new StringContent(
                    JsonConvert.SerializeObject(new TokenRequest(_ioxSettings.username, _ioxSettings.apikey)),
                    Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject<TokenResponse>(await result.Content.ReadAsStringAsync());
                    _memoryTokenStore.SetToken(response);
                    return response;
                }

                return null;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<ResponseObject> CreateBRN(BRNRequest request)
        {
            try
            {
                await validateTokenAsync();
                var result = await createClientWithAuthorizationHeader().PostAsync("brn/createBRN", new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject<ResponseObject>(await result.Content.ReadAsStringAsync());
                    return response;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ResponseObject> UpdateBRN(BRNRequest request)
        {
            try
            {
                await validateTokenAsync();
                var result = await createClientWithAuthorizationHeader().PostAsync("brn/updateBRN", new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject<ResponseObject>(await result.Content.ReadAsStringAsync());
                    return response;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ResponseObject> CreateAccount(CreateAccountRequest request)
        {
            try
            {
                await validateTokenAsync();
                var result = await createClientWithAuthorizationHeader().PostAsync("accounts/createAccount", new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject<ResponseObject>(await result.Content.ReadAsStringAsync());
                    return response;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ResponseObject> AccountEmailInvites(AccountInviteTokenRequest request)
        {
            try
            {
                await validateTokenAsync();
                var result = await createClientWithAuthorizationHeader().PostAsync("accounts/SendAccountInvites", new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject<ResponseObject>(await result.Content.ReadAsStringAsync());
                    return response;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ResponseObject> RequestAccountOTP(AccountOTPRequest request)
        {
            try
            {
                await validateTokenAsync();
                var result = await createClientWithAuthorizationHeader().PostAsync("accounts/RequestAccountOTP", new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject<ResponseObject>(await result.Content.ReadAsStringAsync());
                    return response;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ResponseObject> CreateDepartment(DepartmentRequest request)
        {
            try
            {
                await validateTokenAsync();
                var result = await createClientWithAuthorizationHeader().PostAsync("departments/CreateDepartment", new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject<ResponseObject>(await result.Content.ReadAsStringAsync());
                    return response;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task<ResponseObject> ConfigureEndPoint(EndPointRequest request)
        {
            try
            {
                await validateTokenAsync();
                var result = await createClientWithAuthorizationHeader().PostAsync("endpoint/SetupEndpoint", new StringContent(
                    JsonConvert.SerializeObject(request),
                    Encoding.UTF8, "application/json"));

                if (result.IsSuccessStatusCode)
                {
                    var response = JsonConvert.DeserializeObject<ResponseObject>(await result.Content.ReadAsStringAsync());
                    return response;
                }

                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        private HttpClient createClientWithAuthorizationHeader()
        {
            var client = _clientFactory.CreateClient("iox");
            client.DefaultRequestHeaders.Add("Authorization",$"Bearer {_memoryTokenStore.GetAccessToken().token}");
            return client;
        }

        private async Task validateTokenAsync()
        {
            var token = _memoryTokenStore.GetAccessToken();
            if (token != null)
            {
                if (token.expiresAt < DateTime.Now)
                {
                    await RequestToken();
                }
            }
            else
                await RequestToken();
        }
    }
}