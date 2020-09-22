using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iox_sample_app.Requests;
using iox_sample_app.Responses;
using iox_sample_app.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace iox_sample_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAPIService _apiService;
        public AccountController(IAPIService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        [HttpGet("CreateAccount")]
        public async Task<IActionResult> CreateAccount()
        {
            try
            {
                var request = privateAccount();
                //var request = businessAccount();
                var response = await _apiService.CreateAccount(request);

                if (response.status == "Success")
                {
                    var requestId = JsonConvert.DeserializeObject<InstructionResponse>(response.result.ToString());
                }
                else
                {
                    var errors = response.errors;
                }
                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


        private CreateAccountRequest privateAccount()
        {
            return new CreateAccountRequest()
            {
                IdentificationNumber = "9506035011089",
                accountContactNumber = "0728304577",
                accountEmail = "jacobs@gmail.com",
                accountName = "my_jacobs_account",
                contactPersonFirstName = "Jackson",
                contactPersonLastName = "Jacobs",
                referenceId = "myAccountReferenceUniqueToJacobsAccount",
                isBusinessAccount = false,
                Individuals = new List<Individual>()
                {
                    new Individual()
                    {
                        IdType = "rsaid",
                        IdNumber = "9506035011089",
                        firstname = "Jackson",
                        lastname = "Jacobs",
                        initials = "J",
                        driversLicenseNumber = "55595584555",
                        driversLicenseExpiryDate = new DateTime(2020,09,23)
                    }
                },
                vehicles = new List<Vehicles>()
                {
                    new Vehicles()
                    {
                        IndividualIdNumber = "9506035011089",
                        categoryId = (int) VehicleTypes.LightPassenger,
                        colour = "white",
                        licenseDiscNumber = "5596685221",
                        licenseExpiryDate = new DateTime(2020,09,23),
                        vehicleRegisterNo = "CZ31KAGP",
                        vinNumber = "445665841",
                        tare = 1000,
                        model = "corsa",
                        make = "opel",
                        licenseNumber = "23456177413"
                    }
                }
            };
        }

        private CreateAccountRequest businessAccount()
        {
            return new CreateAccountRequest()
            {

            };
        }

    }
}
