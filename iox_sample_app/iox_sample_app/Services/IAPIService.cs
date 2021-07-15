using iox_sample_app.Requests.Enums;
using iox_sample_app.Responses;
using System.Threading.Tasks;

namespace iox_sample_app.Services
{
    public interface IAPIService
    {
        Task<ResponseObject> Post<T>(T request, RequestTypes requestType);
        Task<R> Post<T, R>(T request, RequestTypes requestType);
    }
}