using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGatewaySample.Domain.Entities;

namespace PaymentGatewaySample.Repositories.Configurations
{
    public class FraudAnalysisConfigurations : IEntityTypeConfiguration<FraudAnalysis>
    {
        public void Configure(EntityTypeBuilder<FraudAnalysis> builder)
        {
            builder.ToTable("FraudAnalysis");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
        }
    }
}