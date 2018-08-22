namespace PaymentGatewaySample.Domain.Enums
{
    public enum TransactionStatus : byte
    {
        Undefined,
        Accepted,
        Rejected,
        Aborted
    }
}