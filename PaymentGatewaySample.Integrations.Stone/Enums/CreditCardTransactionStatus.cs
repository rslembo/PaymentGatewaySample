namespace PaymentGatewaySample.Integrations.Stone.Enums
{
    public enum CreditCardTransactionStatus
    {
        Undefined,
        AuthorizedPendingCapture,
        Captured,
        PartialCapture,
        NotAuthorized,
        Voided,
        PendingVoid,
        PartialVoid,
        Refunded,
        PendingRefund,
        PartialRefunded,
        WithError,
        NotFoundInAcquirer
    }
}