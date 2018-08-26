using PaymentGatewaySample.Domain.Enums;

namespace PaymentGatewaySample.Domain.Entities
{
    public class FraudAnalysis
    {
        public int Id { get; set; }
        public string ProviderId { get; set; }
        public FraudAnalysisStatus? Status { get; set; }
        public decimal? Score { get; set; }
        public string Message { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}