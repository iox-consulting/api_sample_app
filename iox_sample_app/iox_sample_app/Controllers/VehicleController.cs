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
    public class VehicleController : ControllerBase
    {
        private readonly IAPIService _apiService;
        public VehicleController(IAPIService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }


        //This request creates a new vehicle
        [HttpGet("CreateVehicle")]
        public async Task<IActionResult> CreateVehicle()
        {
            try
            {
                //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
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
                    licenseExpiryDate = new DateTime(2021, 3, 2)
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

        // This request updates an existing vehicle
        [HttpGet("UpdateVehicle")]
        public async Task<IActionResult> UpdateVehicle()
        {
            try
            {
                //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
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

        [HttpGet("ActivateVehicle")]
        public async Task<IActionResult> ActivateVehicle()
        {
            try
            {
                //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
                var request = new ActivateVehicleRequest()
                {
                    referenceId = "uniqueReferenceForThisRequest",
                    accountReference = "myAccountReferenceUniqueToMyBusinessAccount",
                    vehicleReference = "myVehicleReferenceUniqueToMyBusinessAccount"
                };
                var response = await _apiService.Post(request, RequestTypes.ActivateVehicle);

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

        [HttpGet("DeactivateVehicle")]
        public async Task<IActionResult> DeactivateVehicle()
        {
            try
            {
                //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
                var request = new ActivateVehicleRequest()
                {
                    referenceId = "uniqueReferenceForThisRequest",
                    accountReference = "myAccountReferenceUniqueToMyBusinessAccount",
                    vehicleReference = "myVehicleReferenceUniqueToMyBusinessAccount"
                };
                var response = await _apiService.Post(request, RequestTypes.DeactivateVehicle);

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
