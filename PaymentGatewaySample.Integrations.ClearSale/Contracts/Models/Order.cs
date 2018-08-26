using System;
using System.Collections.Generic;

namespace PaymentGatewaySample.Integrations.ClearSale.Contracts.Models
{
    public class Order
    {
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public string Email { get; set; }
        public decimal TotalShipping { get; set; }
        public decimal TotalItems { get; set; }
        public decimal TotalOrder { get; set; }
        public string Ip { get; set; }
        public string Obs { get; set; }
        public string Currency { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        public Person ShippingData { get; set; }
        public Person BillingData { get; set; }
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<CustomField> CustomFields { get; set; }
        public bool Reanalysis { get; set; }
        public string Origin { get; set; }
    }
}