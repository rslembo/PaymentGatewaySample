namespace PaymentGatewaySample.Domain.Enums
{
    public enum TransactionStatus
    {
        Undefined,
        Accepted,
        Rejected,
        Captured,
        Canceled,
        Reversed,
        Aborted
    }
}