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
        public virtual DbSet<BillingAddress> BillingAddresses { get; set; }
        public virtual DbSet<ShippingAddress> ShippingAddresses { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Payment> Payments { get; set; }
        public virtual DbSet<CreditCard> CreditCards { get; set; }
        public virtual DbSet<FraudAnalysis> FraudAnalyses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MerchantConfigurations());
            modelBuilder.ApplyConfiguration(new MerchantPaymentConfigurationConfigurations());
            modelBuilder.ApplyConfiguration(new MerchantAntifraudConfigurationConfigurations());
            modelBuilder.ApplyConfiguration(new TransactionConfigurations());
            modelBuilder.ApplyConfiguration(new ShippingAddressConfigurations());
            modelBuilder.ApplyConfiguration(new BillingAddressConfigurations());
            modelBuilder.ApplyConfiguration(new CustomerConfigurations());
            modelBuilder.ApplyConfiguration(new PaymentConfigurations());
            modelBuilder.ApplyConfiguration(new CreditCardConfigurations());
            modelBuilder.ApplyConfiguration(new FraudAnalysisConfigurations());
        }
    }
}