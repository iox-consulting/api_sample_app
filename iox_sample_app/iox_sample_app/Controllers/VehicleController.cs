﻿using System;
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
    public class VehicleController : ControllerBase
    {
        private readonly IAPIService _apiService;
        public VehicleController(IAPIService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        [HttpGet("CreateVehicle")]
        public async Task<IActionResult> CreateVehicle()
        {
            try
            {
                var request = new VehicleRequest()
                {
                    accountReference = "myAccountReferenceUniqueToMyBusinessAccount",
                    brn = "4784473447",
                    departmentName = "Test department",
                    licenseNumber = "TEST123GP",
                    vinNumber = "test1234",
                    vehicleRegisterNo = "A123AVD",
                    engineNumber = "Q123VCAS123",
                    licenseDiscNumber = "A123ACSD",
                    categoryId = (int)VehicleCategories.LightPassenger,
                    colour = "black",
                    make = "BMW",
                    model = "M3",
                    referenceId = "uniqueReferenceForRequest",
                    tare = 1200,
                    licenseExpiryDate = new DateTime(2021,3,2)
                };
                var response = await _apiService.Post(request, RequestTypes.CreateVehicle);

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

        [HttpGet("UpdateVehicle")]
        public async Task<IActionResult> UpdateVehicle()
        {
            try
            {
                var request = new VehicleRequest()
                {
                    accountReference = "myAccountReferenceUniqueToMyBusinessAccount",
                    brn = "4784473447",
                    departmentName = "Test department",
                    licenseNumber = "TEST123GP Updated",
                    vinNumber = "test1234",
                    vehicleRegisterNo = "A123AVD Updated",
                    engineNumber = "Q123VCAS123 Updated",
                    licenseDiscNumber = "A123ACSD Updated",
                    categoryId = (int)VehicleCategories.LightPassenger,
                    colour = "black Updated",
                    make = "BMW Updated",
                    model = "M3 Updated",
                    referenceId = "uniqueReferenceForRequest",
                    tare = 1234,
                    licenseExpiryDate = new DateTime(2021, 3, 2)
                };
                var response = await _apiService.Post(request, RequestTypes.UpdateVehicle);

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