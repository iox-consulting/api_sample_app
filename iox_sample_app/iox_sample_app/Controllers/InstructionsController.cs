using iox_sample_app.Requests;
using iox_sample_app.Requests.Enums;
using iox_sample_app.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace iox_sample_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionsController : ControllerBase
    {
        private readonly IAPIService _apiService;
        public InstructionsController(IAPIService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        //This request creates a new quote
        [HttpGet("CreateQuote")]
        public async Task<IActionResult> CreateQuote()
        {
            try
            {
                //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
                var request = new CreateQuoteRequest()
                {
                    referenceId = "text1",
                    accountReference = "sampleaccountref",
                    Address = new CreateQuoteRequestAddress
                    {
                        City = "Pretoria",
                        District = "Gauteng",
                        PostalCode = "3333",
                        StreetName = "Wisteria Avenue",
                        StreetNumber = "33",
                        Suburb = "Hennopsspark",
                        AddressContacts = new System.Collections.Generic.List<CreateQuoteRequestAddressContact> { new CreateQuoteRequestAddressContact
                        {
                            ContactEmail = "test@test.com",
                            ContactNumber = "0224448788",
                            ContactPerson = "John Doe"
                        } }
                    },
                    vehicleRegisterNumbers = new System.Collections.Generic.List<string>
                    {
                        "BDW701X",
                        "RRW136W"
                    }
                };
                var response = await _apiService.Post(request, RequestTypes.CreateQuote);

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
