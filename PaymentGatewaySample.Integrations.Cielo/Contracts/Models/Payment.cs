using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PaymentGatewaySample.Domain.Enums;

namespace PaymentGatewaySample.Integrations.Cielo.Contracts.Models
{
    public class Payment
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentType Type { get; set; }
        public long Amount { get; set; }
        public bool? Capture { get; set; }
        public string Currency { get; set; }
        public byte? Installments { get; set; }
        public string SoftDescriptor { get; set; }
        public CreditCard CreditCard { get; set; }
    }
}