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
using iox_sample_app.Requests.Enums;

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
        public async Task<ResponseObject> Post<T>(T request, RequestTypes requestType)
        {
            try
            {
                await validateTokenAsync();
                var result = await createClientWithAuthorizationHeader().PostAsync(mapUri(requestType), new StringContent(
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

        private string mapUri(RequestTypes requestType)
        {
            return requestType switch
            {
                RequestTypes.CreateBrn => "brn/createBRN",
                RequestTypes.UpdateBrn => "brn/updateBRN",
                RequestTypes.CreateAccount => "accounts/createAccount",
                RequestTypes.AccountEmailInvites => "accounts/SendAccountInvites",
                RequestTypes.RequestAccountOTP => "accounts/RequestAccountOTP",
                RequestTypes.CreateDepartment => "departments/CreateDepartment",
                RequestTypes.CreateIndividual => "individuals/CreateIndividual",
                RequestTypes.UpdateIndividual => "individuals/UpdateIndividual",
                RequestTypes.ConfigureEndpoint => "endpoint/SetupEndpoint",
                RequestTypes.CreateNominationDriver => "nominations/CreateNominatedDriver",
                RequestTypes.UpdateNominationDriver => "nominations/UpdateNominatedDriver",
                RequestTypes.CreateVehicle => "vehicles/CreateVehicle",
                RequestTypes.UpdateVehicle => "vehicles/UpdateVehicle",
                RequestTypes.CreateDealerStock => "DealerStock/CreateDealerStockInstruction",
                RequestTypes.ActivateVehicle => "vehicles/ActivateVehicle",
                RequestTypes.DeactivateVehicle => "vehicles/DeactivateVehicle",
                _ => throw new Exception("Invalid endpoint url")
            };
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