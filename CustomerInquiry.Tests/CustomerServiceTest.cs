using CustomerInquiry.DataAccess;
using CustomerInquiry.DataAccess.DomainModel;
using CustomerInquiry.DataAccess.Enum;
using CustomerInquiry.Services;
using CustomerInquiry.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInquiry.Tests
{
    public class CustomerServiceTest : IDisposable
    {
        private CustomerInquiryDbContext _context;
        private ICustomerService _customerService;

        public CustomerServiceTest()
        {
            var options = new DbContextOptionsBuilder<CustomerInquiryDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            _context = new CustomerInquiryDbContext(options);
            _context.Database.EnsureCreated();
            Seed(_context);

            _customerService = new CustomerService(_context);
        }

        [Test]
        public async Task ShouldReturnCustomerWithTransactions()
        {
            var result = await _customerService.GetCustomerInfoAsync(1, 5);

            Assert.Positive(result.Data.Transactions.Count);
        }

        [Test]
        public async Task ShouldReturnNotFound()
        {
            var result = await _customerService.GetCustomerInfoAsync(2, 5);

            Assert.AreEqual(result.Status, ServiceResultStatus.NotFound);
        }


        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        private void Seed(CustomerInquiryDbContext context)
        {
            context.Customers.Add(new Customer
            {
                CustomerID = 1,
                ContactEmail = "cut1@gmail.com",
                CustomerName = "Customer 1",
                MobileNo = 123
            });

            context.Transactions.Add(new Transaction
            {
                Amount = 100,
                CurrencyCode = "USD",
                CustomerID = 1,
                Status = TransactionStatus.Canceled,
                TransactionID = 1,
                TransactionTime = DateTime.UtcNow
            });

            context.SaveChanges();
        }

    }
}
