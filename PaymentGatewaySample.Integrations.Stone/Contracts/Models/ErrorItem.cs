namespace PaymentGatewaySample.Integrations.Stone.Contracts.Models
{
    public class ErrorItem
    {
        public string Description { get; set; }
        public int ErrorCode { get; set; }
        public string ErrorField { get; set; }
        public string SeverityCode { get; set; }
    }
}