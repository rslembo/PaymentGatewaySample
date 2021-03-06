﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PaymentGatewaySample.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PaymentGatewaySample.Domain.Contracts.Models
{
    public class Payment
    {
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentType Type { get; set; }
        [Required]
        public long? Amount { get; set; }
        public string Currency { get; set; }
        public byte? Installments { get; set; }
        public string SoftDescriptor { get; set; }
        [Required]
        public CreditCard CreditCard { get; set; }
    }
}