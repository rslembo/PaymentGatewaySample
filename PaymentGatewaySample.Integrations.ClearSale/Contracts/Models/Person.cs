using PaymentGatewaySample.Integrations.ClearSale.Enums;
using System;
using System.Collections.Generic;

namespace PaymentGatewaySample.Integrations.ClearSale.Contracts.Models
{
    public class Person
    {
        public string Id { get; set; }
        public PersonType Type { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public Address Address { get; set; }
        public IEnumerable<Phone> Phones { get; set; }
    }
}