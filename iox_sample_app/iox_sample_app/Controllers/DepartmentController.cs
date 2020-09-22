using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iox_sample_app.Requests;
using iox_sample_app.Requests.Enums;
using iox_sample_app.Responses;
using iox_sample_app.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace iox_sample_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IAPIService _apiService;
        public DepartmentController(IAPIService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        [HttpGet("CreateDepartment")]
        public async Task<IActionResult> CreateDepartment()
        {
            try
            {
                var response = await _apiService.Post(new DepartmentRequest()
                {
                    accountReference = "myAccountReferenceUniqueToMyBusinessAccount",
                    name = "New department",
                    referenceId = "00012341"
                },RequestTypes.CreateDepartment);

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
