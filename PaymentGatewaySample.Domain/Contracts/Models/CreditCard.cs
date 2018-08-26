using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PaymentGatewaySample.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace PaymentGatewaySample.Domain.Contracts.Models
{
    public class CreditCard
    {
        [Required]
        public string Number { get; set; }
        [Required]
        public string Holder { get; set; }
        [Required]
        public string ExpirationMonth { get; set; }
        [Required]
        public string ExpirationYear { get; set; }
        public string SecurityCode { get; set; }
        [Required]
        [JsonConverter(typeof(StringEnumConverter))]
        public CardBrand Brand { get; set; }
    }
}