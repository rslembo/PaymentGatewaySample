using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGatewaySample.Domain.Entities;

namespace PaymentGatewaySample.Repositories.Configurations
{
    public class MerchantPaymentConfigurationConfigurations : IEntityTypeConfiguration<MerchantPaymentConfiguration>
    {
        public void Configure(EntityTypeBuilder<MerchantPaymentConfiguration> builder)
        {
            builder.ToTable("MerchantPaymentConfiguration");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).ValueGeneratedOnAdd();
        }
    }
}