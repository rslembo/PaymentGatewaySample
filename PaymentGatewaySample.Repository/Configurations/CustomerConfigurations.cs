using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PaymentGatewaySample.Domain.Entities;

namespace PaymentGatewaySample.Repositories.Configurations
{
    public class CustomerConfigurations : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder
                .HasOne(x => x.ShippingAddress)
                .WithOne(x => x.Customer)
                .HasForeignKey<ShippingAddress>("CustomerId");

            builder
                .HasOne(x => x.BillingAddress)
                .WithOne(x => x.Customer)
                .HasForeignKey<BillingAddress>("CustomerId");
        }
    }
}