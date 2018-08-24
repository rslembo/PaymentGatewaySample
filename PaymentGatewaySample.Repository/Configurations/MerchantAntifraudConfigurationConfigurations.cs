using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGatewaySample.Domain.Entities;

namespace PaymentGatewaySample.Repositories.Configurations
{
    public class MerchantAntifraudConfigurationConfigurations : IEntityTypeConfiguration<MerchantAntifraudConfiguration>
    {
        public void Configure(EntityTypeBuilder<MerchantAntifraudConfiguration> builder)
        {
            builder.ToTable("MerchantAntifraudConfiguration");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.CreatedDate).ValueGeneratedOnAdd();
            builder.Property(x => x.Provider).HasColumnName("AntifraudProvider");
        }
    }
}