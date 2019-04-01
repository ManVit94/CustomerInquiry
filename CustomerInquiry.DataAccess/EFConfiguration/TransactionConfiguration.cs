using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CustomerInquiry.DataAccess.DomainModel;

namespace CustomerInquiry.DataAccess.EFConfiguration
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(t => t.TransactionID);

            builder.Property(t => t.TransactionTime)
                   .HasColumnType("datetime2(0)");

            builder.Property(t => t.Amount)
                   .HasColumnType("decimal(12, 2)");

            builder.Property(t => t.CurrencyCode)
                   .IsRequired()
                   .HasMaxLength(3)
                   .IsFixedLength();

            builder.HasOne(t => t.Customer)
                   .WithMany(c => c.Transactions)
                   .HasForeignKey(t => t.CustomerID);
        }
    }
}
