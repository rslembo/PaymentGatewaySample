using System;

namespace PaymentGatewaySample.Domain.Dtos
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Identity { get; set; }
        public string IdentityType { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public ShippingAddressDto ShippingAddress { get; set; }
        public BillingAddressDto BillingAddress { get; set; }
        public TransactionDto Transaction { get; set; }
    }
}