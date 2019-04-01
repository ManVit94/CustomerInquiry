using Microsoft.EntityFrameworkCore;
using CustomerInquiry.DataAccess.DomainModel;
using CustomerInquiry.DataAccess.EFConfiguration;

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
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
