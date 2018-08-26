using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PaymentGatewaySample.Domain.Enums;

namespace PaymentGatewaySample.Integrations.Cielo.Contracts.Models
{
    public class CreditCard
    {
        public string Number { get; set; }
        public string Holder { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public CardBrand Brand { get; set; }
    }
}