namespace PaymentGatewaySample.Domain.Dtos
{
    public class FraudAnalysisDto
    {
        public int ProviderId { get; set; }
        public string Status { get; set; }
        public int Score { get; set; }
        public TransactionDto Transaction { get; set; }
    }
}