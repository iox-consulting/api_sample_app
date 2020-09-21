using iox_sample_app.Requests;
using iox_sample_app.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace iox_sample_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BRNController : ControllerBase
    {
        private readonly IAPIService _apiService;

        public BRNController(IAPIService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _apiService.CreateBRN(new BRNRequest()
                {
                    accountReference = "00402176*001",
                    brn = "123412341123",
                    individualIdNumber = "9407025011089",
                    referenceId = "00031234"
                });
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}