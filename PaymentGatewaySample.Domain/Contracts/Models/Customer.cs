using System;

namespace PaymentGatewaySample.Domain.Contracts.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Identity { get; set; }
        public string IdentityType { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
    }
}