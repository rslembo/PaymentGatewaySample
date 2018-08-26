using System;

namespace PaymentGatewaySample.Domain.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Identity { get; set; }
        public string IdentityType { get; set; }
        public string Email { get; set; }
        public string IpAddress { get; set; }
        public string PhoneAreaCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public virtual ShippingAddress ShippingAddress { get; set; }
        public virtual BillingAddress BillingAddress { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}