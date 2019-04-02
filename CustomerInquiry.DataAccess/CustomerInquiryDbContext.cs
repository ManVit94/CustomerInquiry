using Microsoft.EntityFrameworkCore;
using CustomerInquiry.DataAccess.DomainModel;
using CustomerInquiry.DataAccess.EFConfiguration;
using System.Collections.Generic;
using CustomerInquiry.DataAccess.Enum;
using System;

namespace CustomerInquiry.DataAccess
{
    public class CustomerInquiryDbContext : DbContext
    {
        public CustomerInquiryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            //InitTestData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        //This method only for testing purposes
        private void InitTestData(ModelBuilder modelBuilder)
        {
            var transactions = new List<Transaction>
            {
                new Transaction
                {
                    Amount = 200,
                    CurrencyCode = "USD",
                    Status = TransactionStatus.Success,
                    TransactionTime = new DateTime(2019, 01, 12, 14, 34, 00),
                    TransactionID = 1,
                    CustomerID = 1
                },
                new Transaction
                {
                    Amount = 300,
                    CurrencyCode = "USD",
                    Status = TransactionStatus.Success,
                    TransactionTime = new DateTime(2019, 01, 07, 14, 00, 00),
                    TransactionID = 2,
                    CustomerID = 1
                },
                new Transaction
                {
                    Amount = 1200,
                    CurrencyCode = "EUR",
                    Status = TransactionStatus.Success,
                    TransactionTime = new DateTime(2019, 04, 01, 21, 00, 00),
                    TransactionID = 3,
                    CustomerID = 1
                },
                new Transaction
                {
                    Amount = 100,
                    CurrencyCode = "USD",
                    Status = TransactionStatus.Failed,
                    TransactionTime = new DateTime(2019, 03, 12, 10, 00, 00),
                    TransactionID = 4,
                    CustomerID = 2
                },
                new Transaction
                {
                    Amount = 500,
                    CurrencyCode = "USD",
                    Status = TransactionStatus.Canceled,
                    TransactionTime = new DateTime(2019, 03, 07, 14, 00, 00),
                    TransactionID = 5,
                    CustomerID = 2
                },
                new Transaction
                {
                    Amount = 700,
                    CurrencyCode = "EUR",
                    Status = TransactionStatus.Success,
                    TransactionTime = new DateTime(2019, 04, 01, 21, 00, 00),
                    TransactionID = 6,
                    CustomerID = 2
                }
            };

            var customers = new List<Customer>
            {
                new Customer
                {
                    CustomerName = "Customer 1",
                    ContactEmail = "cust1@gmail.com",
                    MobileNo = 385551,
                    CustomerID = 1
                },
                new Customer
                {
                    CustomerName = "Customer 2",
                    ContactEmail = "cust2@gmail.com",
                    MobileNo = 385552,
                    CustomerID = 2
                }
            };

            modelBuilder.Entity<Customer>()
                .HasData(customers);

            modelBuilder.Entity<Transaction>()
                .HasData(transactions);
        }
    }
}
