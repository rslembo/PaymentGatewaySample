using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PaymentGatewaySample.Domain.Enums;

namespace PaymentGatewaySample.Domain.Dtos
{
    public class PaymentDto
    {
        public long? Amount { get; set; }
        public string Currency { get; set; }
        public byte? Installments { get; set; }
        public string SoftDescriptor { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public PaymentType Type { get; set; }
        public CreditCardDto CreditCard { get; set; }
        public TransactionDto Transaction { get; set; }
    }
}