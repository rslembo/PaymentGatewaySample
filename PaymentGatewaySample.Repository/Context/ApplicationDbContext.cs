using Microsoft.EntityFrameworkCore;
using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Repositories.Configurations;

namespace PaymentGatewaySample.Repositories.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options) { }

        public virtual DbSet<Merchant> Merchants { get; set; }
        public virtual DbSet<MerchantAntifraudConfiguration> MerchantAntifraudConfigurations { get; set; }
        public virtual DbSet<MerchantPaymentConfiguration> MerchantPaymentConfigurations { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MerchantConfigurations());
            modelBuilder.ApplyConfiguration(new MerchantPaymentConfigurationConfigurations());
            modelBuilder.ApplyConfiguration(new MerchantAntifraudConfigurationConfigurations());
        }
    }
}