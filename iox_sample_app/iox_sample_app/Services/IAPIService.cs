using iox_sample_app.Requests;
using iox_sample_app.Responses;
using System.Threading.Tasks;

namespace iox_sample_app.Services
{
    public interface IAPIService
    {
        Task<ResponseObject> CreateBRN(BRNRequest request);
    }
}