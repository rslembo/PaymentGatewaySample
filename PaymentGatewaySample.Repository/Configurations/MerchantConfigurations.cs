using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGatewaySample.Domain.Entities;

namespace PaymentGatewaySample.Repositories.Configurations
{
    public class MerchantConfigurations : IEntityTypeConfiguration<Merchant>
    {
        public void Configure(EntityTypeBuilder<Merchant> builder)
        {
            builder.ToTable("Merchant");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).ValueGeneratedOnAdd();

            builder
                .HasMany(x => x.PaymentConfigurations)
                .WithOne(x => x.Merchant);

            builder
                .HasOne(x => x.AntifraudConfiguration)
                .WithOne(x => x.Merchant)
                .HasForeignKey<MerchantAntifraudConfiguration>("MerchantId");

            builder
                .HasMany(x => x.Transactions)
                .WithOne(x => x.Merchant);
        }
    }
}