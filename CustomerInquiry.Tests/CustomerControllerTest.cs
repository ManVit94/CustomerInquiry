using CustomerInquiry.Services;
using CustomerInquiry.Services.DTOModel;
using CustomerInquiry.WebApi.Controllers;
using CustomerInquiry.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerInquiry.Tests
{
    public class CustomerControllerTest
    {
        [Test]
        public async Task ShouldReturn200()
        {
            var mock = new Mock<ICustomerService>();

            mock.Setup(m => m.GetCustomerInfoAsync(1, 5))
                .Returns(() =>
                {
                    return Task.FromResult(new ServiceResult<CustomerInfoDTO>
                    {
                        Status = ServiceResultStatus.Success
                    });
                });

            var controller = new CustomerController(mock.Object);

            var result = await controller.GetCustomer(new CustomerRequestModel
            {
                CustomerId = 1 
            });

            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public async Task ShouldReturn404()
        {
            var mock = new Mock<ICustomerService>();

            mock.Setup(m => m.GetCustomerInfoAsync(1, 5))
                .Returns(() =>
                {
                    return Task.FromResult(new ServiceResult<CustomerInfoDTO>
                    {
                        Status = ServiceResultStatus.NotFound
                    });
                });

            mock.Setup(m => m.GetCustomerInfoAsync("cust1@gmail.com", 5))
                .Returns(() =>
                {
                    return Task.FromResult(new ServiceResult<CustomerInfoDTO>
                    {
                        Status = ServiceResultStatus.NotFound
                    });
                });

            var controller = new CustomerController(mock.Object);

            var result = await controller.GetCustomer(new CustomerRequestModel
            {
                CustomerId = 1,
                Email = "cust1@gmail.com"
            });

            Assert.IsInstanceOf<NotFoundResult>(result);
        }

        [Test]
        public async Task ShouldReturnInvalidEmailErrorMessage()
        {
            var controller = new CustomerController(null);

            var result = await controller.GetCustomer(new CustomerRequestModel
            {
                Email = "invlalidEmail"
            });

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;

            Assert.AreEqual("Invalid Email", badRequestResult.Value);
        }

        [Test]
        public async Task ShouldReturnNoInquiryCriteriaErrorMessage()
        {
            var controller = new CustomerController(null);

            var result = await controller.GetCustomer(new CustomerRequestModel());

            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            var badRequestResult = result as BadRequestObjectResult;

            Assert.AreEqual("No inquiry criteria", badRequestResult.Value);
        }
    }
}
