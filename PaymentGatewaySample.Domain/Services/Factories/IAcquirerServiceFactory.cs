using PaymentGatewaySample.Domain.Enums;

namespace PaymentGatewaySample.Domain.Services.Factories
{
    public interface IAcquirerServiceFactory
    {
        IAcquirerService CreateService(Acquirer acquirer);
    }
}