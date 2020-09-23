using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iox_sample_app.Requests;
using iox_sample_app.Requests.Enums;
using iox_sample_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace iox_sample_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndividualController : ControllerBase
    {
        private readonly IAPIService _apiService;
        public IndividualController(IAPIService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        // This request creates a new individual
        [HttpGet("CreateIndividual")]
        public async Task<IActionResult> CreateIndividual()
        {
            try
            {
                //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
                var response = await _apiService.Post(new IndividualRequest()
                {
                   accountReference = "myAccountReferenceUniqueToJacobsAccount",
                   lastname = "Jacobs",
                   IdType = "RSAID",
                   IdNumber = "9405601455904",
                   driversLicenseNumber = "15616516",
                   firstname = "Nick",
                   initials = "N",
                   referenceId = "UniqueReferenceForRequest"
                },RequestTypes.CreateIndividual);

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
        //This request updates an existing individual
        [HttpGet("UpdateIndividual")]
        public async Task<IActionResult> UpdateIndividual()
        {
            try
            {
                //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
                var response = await _apiService.Post(new IndividualRequest()
                {
                    accountReference = "myAccountReferenceUniqueToJacobsAccount",
                    lastname = "Jacobs",
                    IdType = "RSAID",
                    IdNumber = "8300000000000",
                    driversLicenseNumber = "15616516",
                    firstname = "Nick",
                    initials = "N",
                    referenceId = "UniqueReferenceForRequest"
                }, RequestTypes.UpdateIndividual);

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
