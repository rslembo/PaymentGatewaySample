using PaymentGatewaySample.Domain.Enums;

namespace PaymentGatewaySample.Domain.Dtos
{
    public class FraudAnalysisDto
    {
        public string ProviderId { get; set; }
        public FraudAnalysisStatus? Status { get; set; }
        public decimal? Score { get; set; }
        public string Message { get; set; }
        public TransactionDto Transaction { get; set; }
    }
}