namespace PaymentGatewaySample.Domain.Entities
{
    public class FraudAnalysis
    {
        public int Id { get; set; }
        public int ProviderId { get; set; }
        public string Status { get; set; }
        public int Score { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}