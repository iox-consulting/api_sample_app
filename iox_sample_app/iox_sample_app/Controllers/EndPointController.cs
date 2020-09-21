using iox_sample_app.Helper;
using iox_sample_app.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using iox_sample_app.Helper.Interfaces;

namespace iox_sample_app.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EndPointController : ControllerBase
    {
        private readonly ISignatureVerifier _signatureVerifier;

        public EndPointController(ISignatureVerifier signatureVerifier)
        {
            _signatureVerifier = signatureVerifier ?? throw new ArgumentNullException(nameof(signatureVerifier));
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
                        var instructionResponse =
                            JsonConvert.DeserializeObject<InstructionResponse>(response.result.ToString());
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
                        var quote =
                            JsonConvert.DeserializeObject<Quote>(response.result.ToString());
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