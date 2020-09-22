using iox_sample_app.Requests;
using iox_sample_app.Responses;
using System.Threading.Tasks;

namespace iox_sample_app.Services
{
    public interface IAPIService
    {
        Task<ResponseObject> CreateBRN(BRNRequest request);
        Task<ResponseObject> UpdateBRN(BRNRequest request);
        Task<ResponseObject> ConfigureEndPoint(EndPointRequest request);
        Task<ResponseObject> CreateAccount(CreateAccountRequest request);
        Task<ResponseObject> AccountEmailInvites(AccountInviteTokenRequest request);
        Task<ResponseObject> RequestAccountOTP(AccountOTPRequest request);

    }
}