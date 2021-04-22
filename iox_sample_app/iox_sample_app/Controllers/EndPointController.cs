using iox_sample_app.Helper.Interfaces;
using iox_sample_app.Requests;
using iox_sample_app.Requests.Enums;
using iox_sample_app.Responses;
using iox_sample_app.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace iox_sample_app.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EndPointController : ControllerBase
    {
        private readonly ISignatureVerifier _signatureVerifier;
        private readonly IAPIService _apiService;

        public EndPointController(ISignatureVerifier signatureVerifier, IAPIService apiService)
        {
            _signatureVerifier = signatureVerifier ?? throw new ArgumentNullException(nameof(signatureVerifier));
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        //This request configures your endpoint (webhook url)
        [HttpGet("Configure")]
        public async Task<IActionResult> Configure()
        {
            //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
            var response = await _apiService.Post(new EndPointRequest()
            {
                sharedkey = "YourSharedKeyProvidedWhenSettingUpEndpoint",
                url = "{Your_ngrok_url}/endpoint/response"
            }, RequestTypes.ConfigureEndpoint);

            if (response.status == "Success")
                return Ok(JsonConvert.DeserializeObject<EndPointResponse>(response.result.ToString()));
            else
                return BadRequest(response.errors);
        }

        [HttpPost("Response")]
        public async Task<IActionResult> Response()
        {
            var payload = await ReadPayload();
            //Check if payload is valid.
            if (_signatureVerifier.VerifySignature(payload + Request.Headers["Nonce"].FirstOrDefault(),
                Request.Headers["HMAC"].FirstOrDefault()))
            {
                var response = JsonConvert.DeserializeObject<ResponseObject>(payload);
                if (response.ResponseType == (int)ResponseTypes.AccountOtp)
                {
                    if (response.status == "Success")
                    {
                        var accountOTPResponse = JsonConvert.DeserializeObject<AccountOTPResponse>(response.result.ToString());
                        //TODO your logic
                    }
                    else
                    {
                        var errors = response.errors;
                    }
                }
                else if (response.ResponseType == (int)ResponseTypes.InstructionStatusUpdate)
                {
                    if (response.status == "Success")
                    {
                        //TODO your logic
                    }
                    else
                    {
                        var errors = response.errors;
                    }
                }
                else if (response.ResponseType == (int)ResponseTypes.NewFineCount)
                {
                    if (response.status == "Success")
                    {
                        var newFineCounts = JsonConvert.DeserializeObject<List<NewFineCountResponse>>(response.result.ToString());
                        //TODO your logic
                    }
                    else
                    {
                        var errors = response.errors;
                    }
                }
                else if (response.ResponseType == (int)ResponseTypes.LicensingInstructionStatusUpdate)
                {
                    if (response.status == "Success")
                    {
                        var obj = JsonConvert.DeserializeObject<LicensingInstructionStatusUpdateResponse>(response.result.ToString());
                        //TODO your logic
                    }
                    else
                    {
                        var errors = response.errors;
                    }
                }
                else if (response.ResponseType == (int)ResponseTypes.DocumentsUploadResponse)
                {
                    if (response.status == "Success")
                    {
                        var obj = JsonConvert.DeserializeObject<List<DocumentUploadItemResponse>>(response.result.ToString());
                        //TODO your logic
                    }
                    else
                    {
                        var errors = response.errors;
                    }
                }
                else if (response.ResponseType == (int)ResponseTypes.QuoteCreated)
                {
                    if (response.status == "Success")
                    {
                        var obj = JsonConvert.DeserializeObject<QuoteCreatedResponse>(response.result.ToString());
                        //TODO your logic
                    }
                    else
                    {
                        var errors = response.errors;
                    }
                }
                else
                {
                    return BadRequest("Invalid response type");
                }

                return Ok();
            }

            return Unauthorized();
        }

        private async Task<string> ReadPayload()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}