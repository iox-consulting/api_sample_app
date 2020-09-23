using iox_sample_app.Requests;
using iox_sample_app.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using iox_sample_app.Requests.Enums;

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

        //This request creates a new BRN for your business account
        [HttpGet("CreateBRN")]
        public async Task<IActionResult> CreateBRN()
        {
            try
            {
                //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
                var response = await _apiService.Post(new BRNRequest()
                {
                    accountReference = "00402176*001",
                    brn = "123412341123",
                    individualIdNumber = "9407025011089",
                    referenceId = "00031234"
                },RequestTypes.CreateBrn);

                if (response.status == "Success")
                    return Ok(response);
                else
                    return BadRequest(response.errors);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
        //This request updates an existing BRN for your business account
        [HttpGet("UpdateBRN")]
        public async Task<IActionResult> UpdateBRN()
        {
            try
            {
                //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
                var response = await _apiService.Post(new BRNRequest()
                {
                    accountReference = "00402176*001",
                    brn = "31241241",
                    individualIdNumber = "9407025011089",
                    referenceId = "000123441"
                },RequestTypes.UpdateBrn);

                if (response.status == "Success")
                    return Ok(response);
                else
                    return BadRequest(response.errors);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}