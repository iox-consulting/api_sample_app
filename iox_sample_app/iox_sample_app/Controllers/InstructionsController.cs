﻿using iox_sample_app.Requests;
using iox_sample_app.Requests.Enums;
using iox_sample_app.Responses;
using iox_sample_app.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace iox_sample_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructionsController : ControllerBase
    {
        private readonly IAPIService _apiService;
        public InstructionsController(IAPIService apiService)
        {
            _apiService = apiService ?? throw new ArgumentNullException(nameof(apiService));
        }

        //This request creates a new quote
        [HttpGet("CreateQuote")]
        public async Task<IActionResult> CreateQuote()
        {
            try
            {
                //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
                var request = new CreateQuoteRequest()
                {
                    referenceId = "text1",
                    accountReference = "sampleaccountref",
                    paymentCallbackUrl = "http://localhost:5100",
                    Address = new CreateQuoteRequestAddress
                    {
                        City = "Pretoria",
                        District = "Gauteng",
                        PostalCode = "3333",
                        StreetName = "Wisteria Avenue",
                        DeliveryInstructions = "Leave at door",
                        StreetNumber = "33",
                        Suburb = "Hennopsspark",
                        AddressContacts = new System.Collections.Generic.List<CreateQuoteRequestAddressContact> { new CreateQuoteRequestAddressContact
                        {
                            ContactEmail = "test@test.com",
                            ContactNumber = "0224448788",
                            ContactPerson = "John Doe"
                        } }
                    },
                    vehicleRegisterNumbers = new System.Collections.Generic.List<string>
                    {
                        "BDW701X",
                        "RRW136W"
                    }
                };
                var response = await _apiService.Post(request, RequestTypes.CreateQuote);

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

        //This request creates a new quote with a synchronous response
        [HttpGet("CreateQuoteRealtime")]
        public async Task<IActionResult> CreateQuoteRealtime()
        {
            try
            {
                //PLEASE NOTE THE REQUEST'S DATA IS TEST DATA AND SHOULD NOT BE POSTED TO THE API
                var request = new CreateQuoteRequestRealtime()
                {
                    referenceId = "test1",
                    accountReference = "sampleaccountref",
                    paymentCallbackUrl = "http://localhost:5100",
                    Address = new CreateQuoteRequestAddress
                    {
                        City = "Pretoria",
                        District = "Gauteng",
                        PostalCode = "3333",
                        StreetName = "Wisteria Avenue",
                        DeliveryInstructions = "Leave at door",
                        StreetNumber = "33",
                        Suburb = "Hennopsspark",
                        AddressContacts = new System.Collections.Generic.List<CreateQuoteRequestAddressContact> { new CreateQuoteRequestAddressContact
                        {
                            ContactEmail = "test@test.com",
                            ContactNumber = "0224448788",
                            ContactPerson = "John Doe"
                        } }
                    },
                    vehicleRegisterNumbers = new System.Collections.Generic.List<string>
                    {
                        "BDW701X",
                        "RRW136W"
                    }
                };
                QuoteCreatedRealtimeResponse response = await _apiService.Post<CreateQuoteRequestRealtime, QuoteCreatedRealtimeResponse>(request, RequestTypes.CreateQuote);

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
