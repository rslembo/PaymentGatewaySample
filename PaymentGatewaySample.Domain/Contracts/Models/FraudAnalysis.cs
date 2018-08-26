using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PaymentGatewaySample.Domain.Enums;

namespace PaymentGatewaySample.Domain.Contracts.Models
{
    public class FraudAnalysis
    {
        public string ProviderId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public FraudAnalysisStatus? Status { get; set; }
        public decimal? Score { get; set; }
        public string Message { get; set; }
    }
}