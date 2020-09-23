using iox_sample_app.Requests;
using iox_sample_app.Responses;
using iox_sample_app.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using iox_sample_app.Requests.Enums;

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

        //This request creates a new account
        [HttpGet("CreateAccount")]
        public async Task<IActionResult> CreateAccount()
        {
            try
            {
                //var request = privateAccount();
                var request = businessAccount();
                var response = await _apiService.Post(request,RequestTypes.CreateAccount);

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
        //This request Sends an invite email to all users provided
        [HttpGet("SendAccountEmailInvites")]
        public async Task<IActionResult> SendAccountEmailInvites()
        {
            try
            {

                //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
                var request = new AccountInviteTokenRequest()
                {
                    referenceId = "uniqueReferenceForThisRequest",
                    accountReference = "myAccountReferenceUniqueToMyBusinessAccount",
                    accountInvites = new List<AccountInvite>()
                    {
                        new AccountInvite()
                        {
                            email = "test@gmail.com",
                            firstName = "tester",
                            lastName = "test"
                        }
                    }
                };
                var response = await _apiService.Post(request,RequestTypes.AccountEmailInvites);

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

        //This request requests an account OTP 
        [HttpGet("RequestAccountOTP")]
        public async Task<IActionResult> RequestAccountOTP()
        {
            try
            {
                //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
                var request = new AccountOTPRequest()
                {
                    referenceId = "uniqueReferenceForThisRequest",
                    accountReference = "myAccountReferenceUniqueToMyBusinessAccount",
                };
                var response = await _apiService.Post(request,RequestTypes.RequestAccountOTP);

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

        private CreateAccountRequest privateAccount()
        {
            //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
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
                        categoryId = (int) VehicleCategories.LightPassenger,
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
                },
                brn = new List<BRN>()
            };
        }

        private CreateAccountRequest businessAccount()
        {
            //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
            var request = new CreateAccountRequest()
            {
                accountContactNumber = "0126541859",
                accountEmail = "myorg@domain.com",
                accountName = "my_business_account",
                contactPersonFirstName = "Jack",
                contactPersonLastName = "Smith",
                referenceId = "myAccountReferenceUniqueToMyBusinessAccount",
                isBusinessAccount = true,
                companyRegistrationNumber = "199403296/12251",
                Individuals = new List<Individual>()
                {
                    new Individual()
                    {
                        IdType = "rsaid",
                        IdNumber = "8306035011089",
                        firstname = "James",
                        lastname = "May",
                        initials = "J",
                        driversLicenseNumber = "33395584555",
                        driversLicenseExpiryDate = new DateTime(2022,09,23)
                    }
                },
                vehicles = new List<Vehicles>()
                {
                    new Vehicles()
                    {
                        brn = "4784473447",
                        categoryId = (int) VehicleCategories.HeavyPassenger,
                        colour = "white",
                        licenseDiscNumber = "3396685221",
                        licenseExpiryDate = new DateTime(2020,09,23),
                        vehicleRegisterNo = "QF22KAGP",
                        vinNumber = "334114213",
                        tare = 2500,
                        model = "bus",
                        make = "toyota",
                        licenseNumber = "1346177413",
                        departmentName = "Test department"
                    }
                },
                brn = new List<BRN>()
                {
                    new BRN()
                    {
                        BRNNumber = "4784473447",
                        IndividualIdNumber = "8306035011089"
                    }
                },
                departments = new List<Department>()
                 {
                     new Department()
                     {
                         name = "Test department"
                     }
                 }
            };

            return request;
        }
    }
}