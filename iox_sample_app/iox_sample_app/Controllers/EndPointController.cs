using iox_sample_app.Helper;
using iox_sample_app.Responses;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
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
                    var accountOTPResponse = JsonConvert.DeserializeObject<AccountOTPResponse>(response.result.ToString());
                }
                else if (response.ResponseType == (int)ResponseTypes.InstructionStatusUpdate)
                {
                    var instructionResponse =
                        JsonConvert.DeserializeObject<InstructionResponse>(response.result.ToString());
                }
                else if (response.ResponseType == (int)ResponseTypes.QuoteCreated)
                {
                    var quote =
                        JsonConvert.DeserializeObject<Quote>(response.result.ToString());
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