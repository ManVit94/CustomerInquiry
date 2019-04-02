using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CustomerInquiry.Services;
using CustomerInquiry.WebApi.Models;
using CustomerInquiry.WebApi.Validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustomerInquiry.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : BaseApiController
    {
        private const int TAKE_TRANSACTIONS_COUNT = 5;

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomer(CustomerRequestModel request)
        {
            var validationMessage = CustomerControllerValidator.ValidateGetCustomerRequest(request);
            if (validationMessage != null)
            {
                return BadRequest(validationMessage);
            }

            if (request.CustomerId > 0)
            {
                var serviceResult = await _customerService.GetCustomerInfoAsync(request.CustomerId, TAKE_TRANSACTIONS_COUNT);

                if (serviceResult.Status == ServiceResultStatus.NotFound)
                {
                    serviceResult = await _customerService.GetCustomerInfoAsync(request.Email, TAKE_TRANSACTIONS_COUNT);
                }
                return ReturnResult(serviceResult);
            }
            else
            {
                var serviceResult = await _customerService.GetCustomerInfoAsync(request.Email, TAKE_TRANSACTIONS_COUNT);
                return ReturnResult(serviceResult);
            }
        }

    }
}