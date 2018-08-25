﻿using PaymentGatewaySample.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PaymentGatewaySample.Domain.Contracts.Models
{
    public class CreditCard
    {
        [Required]
        public string Number { get; set; }
        public string Holder { get; set; }
        [Required]
        public string ExpirationMonth { get; set; }
        [Required]
        public string ExpirationYear { get; set; }
        public string SecurityCode { get; set; }
        [Required]
        public CardBrand Brand { get; set; }
    }
}