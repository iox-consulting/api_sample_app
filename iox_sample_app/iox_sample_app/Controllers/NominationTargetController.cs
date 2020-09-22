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
    public class NominationTargetController : ControllerBase
    {
        private readonly IAPIService _apiService;
        public NominationTargetController(IAPIService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        [HttpGet("CreateNominationDriver")]
        public async Task<IActionResult> CreateNominationDriver()
        {
            try
            {
                var response = await _apiService.Post(new NominationTargetRequest() 
                {
                    accountReference = "myAccountReferenceUniqueToMyBusinessAccount",
                    referenceId = "uniqueReferenceForRequest",
                    AddressDetails = new NominationTargetAddressDetails()
                    {
                        City = "Johannesburg",
                        Country = "South Africa",
                        PostalCode = "1234",
                        StreetName = "Old Johannesburg road",
                        StreetNo = "123"
                    },
                    PersonalDetails = new NominationTargetPersonalDetails()
                    {
                        IdType = (int)NominationIdTypes.SouthAfricanId,
                        IdNumber = "9407024011089",
                        ContactNumber = "0826547855",
                        CountryOfIssue = "South Africa",
                        Email = "test@gmail.com",
                        FullName = "My Nomination Target",
                        Gender = "Male",
                        Initials = "TT",
                        Surname = "Nomination Target"
                    },
                    Documents = new List<NominationTargetDocument>()
                    {
                        new NominationTargetDocument()
                        {
                            DocumentBase64String = "iVBORw0KGgoAAAANSUhEUgAAAIAAAAA5CAYAAAD++yN2AAAACXBIWXMAAA7EAAAOxAGVKw4bAAAFP0lEQVR4Xu1cv2/UMBS+y12pKoq6gNSJgbYDCxsSsMCGEBsDYu2fgGBhQ+paRtg6sLKwsCDRFYQYEAIxo0otQoKh5dfRNjH+cvfKI73YL3EOLpcXybrEfn7v+XvP9rOTc6ullyKgCCgCioAioAg0EYG2tNGm12sbY7qtJEGdTssYqmsYD+RRPn6TQRnl45nKu/Y+HtBQfsc+gx8llFPdqUE+58H5QxTq8Tw88zaSrpRHvKKBnvSMcuQRL+KNfOiNfCTOD7rSlYcN6cPlow5kIW9YOceU60c6Uf2pVrs9a1Ni03Y0M/Od6ZN7i8Z4r/jj1lJvdfXm/tOnV+P37+cGjd+3v3sDxdEArjzdg4YawAElgH8OhEMPGB8XdxzSbdfewAGywJID4fcIKwcv4kOyOGDEF/pBL05POqAe6U+GhhzogV8k5FN9GAf3ZEwuL9sBhjkg8siJiAd/Bj9ySCrnzyl+7bm5751z517tra8/7Fy48MQ6AmyUe3lHgHhz88yPGzeeWcOfcDHSsrFDIJlZXV2ZXl6+69KMhr5cmt21tTvW+MfHrnmqkA+BqLeycjve2Fgq7QDJ5y/H9l+8OI+RxSdNy8cPAbO9fTR++/ZKaQcwe7+MDfp4IDR+rVSNnAjE/Q6ce7mngD0bAxnjnSbUBmOMQJLMlneAJDFsuTfGrVTV8hAwSfKtvAPE6Qig6NYZAbt5U94BzMFGTZ0haLbuxjhjOPf83nceDQLr7ULOjSBfgIcYgHbo6g1Dc7V3LuElI0BzoZuMljs7sG8EoJceI4OCvzkamZBmM+YvqQ4h4XMAVHAyCMWWQlRda4QimVs/2AFGEwS2D09Nut88EicIWAb29amuc3Kj2xVG1uDVCRoJkHVlGhAE/nnHX77xHTbLZPYksgbnXz6UF6g1MwgE7AP03wJK4oS/ZfKeHstmEPocRkeByh04eAqQOwAZvuD2MRkfTdc4oHIHcDKUG9fFpqThiSV30YP7IUHiv4VmYqQF7QN4UUh7rLDHF+rdQ4JErzJKMAyB4CmgkmmZD/NF7FTIaYowVtoUAd9XwfR5di5cUu+Q0nFBZeqoXYshUE0MUEzmX9TawwPAk1V12tjnAOKleRlDSqYFzreMDBlGzaXyOYAYmUPDtSOKz/67I09I1kF0ShCbgxMGrQKyf60SaZC3MpAaftjyUCRYiQojIBkBRCMvJ8rrqaE9WKRIYQgmvkJQDCBGJ8+4VRot1IHEjZkswqCXQWIoUilD5n01mhjCUREGjwAiG6ZEbEewyp6f+tao4Jl8vkEfhJTGXeQ1QvAly0UhqyaSBW8Fl3aCKtBW4wej+H8cwOc1rnLJiiIYluYw+DcxQBZP36rA5ZZVTh/NsXNuSwM2gtppWC/ZKxDjrMYVQ1UVYYADwPg4dEivOiMQMAX01/XqADU2fzQ//9Glvm94T9qzs1s1bn/TVTfR0tLL0g7QWVzc7V6+/Mgy+NV0JOvY/mhx8ZNN70o7ACp2L168P33r1gN727NJY7iaeEJ0amFj5t69693Tp9+4VPYt1w/q7j5+fGn/+fNrZmfnpN3yPWETthhxGiWOIPlqEw5V5K+PaQWBKJQOU6RPzFAX9HQQo2sqwmdrKMcBjXSgJOeHGAX/gcdhkvilwyOhO+mT/a4E+fykT364I8eL6pN+9IEMdQTaZuVvuqmMZGR5c9ph8RXokXh9whC6kS7IAyZ4nk7bE0Vdm0xnYeG17bhr3bNnP9TEX1VNRUARUAQUAUVAEVAEFAFFQBFQBBQBRUARUAQUAUVAERgpAr8BPgJCBEi5nggAAAAASUVORK5CYII=",
                            DocumentType = (int)NominationDocumentTypes.DriversLicense,
                            ExpiryDate = new DateTime(2025,01,01),
                            Reference = "myDocumentUniqueReference"
                        }
                    }
                }, RequestTypes.CreateNominationDriver);

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
