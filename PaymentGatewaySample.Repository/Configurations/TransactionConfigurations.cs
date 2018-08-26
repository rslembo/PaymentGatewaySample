using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGatewaySample.Domain.Entities;

namespace PaymentGatewaySample.Repositories.Configurations
{
    public class TransactionConfigurations : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("Transaction");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).ValueGeneratedOnAdd();

            builder
                .HasOne(x => x.Payment)
                .WithOne(x => x.Transaction)
                .HasForeignKey<Payment>("TransactionId");

            builder
                .HasOne(x => x.FraudAnalysis)
                .WithOne(x => x.Transaction)
                .HasForeignKey<FraudAnalysis>("TransactionId");
        }
    }
}