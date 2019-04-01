using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CustomerInquiry.DataAccess.DomainModel;

namespace CustomerInquiry.DataAccess.EFConfiguration
{
    internal class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasKey(c => c.CustomerID);

            builder.Property(c => c.CustomerName)
                   .HasMaxLength(30)
                   .IsRequired();

            builder.Property(c => c.ContactEmail)
                   .HasMaxLength(25)
                   .IsRequired();

            builder.Property(c => c.MobileNo)
                   .HasMaxLength(10);

            builder.HasMany(c => c.Transactions)
                   .WithOne(t => t.Customer)
                   .HasForeignKey(c => c.CustomerID);

            builder.HasIndex(c => c.ContactEmail)
                   .IsUnique();
        }
    }
}
