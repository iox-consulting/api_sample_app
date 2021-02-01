using System;
using System.Threading.Tasks;
using iox_sample_app.Requests;
using iox_sample_app.Requests.Enums;
using iox_sample_app.Services;
using Microsoft.AspNetCore.Mvc;

namespace iox_sample_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealerStockController : ControllerBase
    {
        private readonly IAPIService _apiService;

        public DealerStockController(IAPIService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }
        
        [HttpGet("Test")]
        public IActionResult Test()
        {
            return new OkObjectResult("Working...");
        }
        
        [HttpGet("CreateDealerStock")]
        public async Task<IActionResult> CreateDealerStock()
        {
            try
            {

                //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
                var response = await _apiService.Post(new CreateDealerStockInstructionRequest()
                {
                    accountReference = "myAccountReferenceUniqueToMyBusinessAccount",
                    brnNumber = "mySelectedBrnNumberLinkTOMyBusinessAccount",
                    vehicleRegisterNumber = "DCP011H",
                    referenceId = "uniqueReferenceForThisRequest",
                    preFilledNCODocument = await System.IO.File.ReadAllTextAsync(@"C:\My\Path\To\This\File\File1.txt"),
                    vehiclePaidInFullLetterDocument = await System.IO.File.ReadAllTextAsync(@"C:\My\Path\To\This\File\File1.txt")
                },RequestTypes.CreateDealerStock);

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