﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PaymentGatewaySample.Domain.Enums;

namespace PaymentGatewaySample.Domain.Dtos
{
    public class CreditCardDto
    {
        public string Number { get; set; }
        public string Holder { get; set; }
        public string ExpirationMonth { get; set; }
        public string ExpirationYear { get; set; }
        public string SecurityCode { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CardBrand Brand { get; set; }
        public PaymentDto Payment { get; set; }
    }
}