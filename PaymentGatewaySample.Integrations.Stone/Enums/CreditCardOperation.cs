namespace PaymentGatewaySample.Integrations.Stone.Enums
{
    public enum CreditCardOperation
    {
        Undefined,
        AuthOnly,
        AuthAndCapture,
        AuthAndCaptureWithDelay
    }
}