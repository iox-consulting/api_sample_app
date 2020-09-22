using iox_sample_app.Requests;
using iox_sample_app.Responses;
using System.Threading.Tasks;
using iox_sample_app.Requests.Enums;

namespace iox_sample_app.Services
{
    public interface IAPIService
    {
        Task<ResponseObject> Post<T>(T request, RequestTypes requestType);
    }
}