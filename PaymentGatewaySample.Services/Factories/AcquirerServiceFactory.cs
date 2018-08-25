using PaymentGatewaySample.Domain.Enums;
using PaymentGatewaySample.Domain.Services;
using PaymentGatewaySample.Domain.Services.Factories;
using System;

namespace PaymentGatewaySample.Services.Factories
{
    public class AcquirerServiceFactory : IAcquirerServiceFactory
    {
        public ICieloService CieloService { get; }
        public IStoneService StoneService { get; }

        public AcquirerServiceFactory(ICieloService cieloService, IStoneService stoneService)
        {
            CieloService = cieloService ?? throw new ArgumentNullException(nameof(cieloService));
            StoneService = stoneService ?? throw new ArgumentNullException(nameof(stoneService));
        }

        public IAcquirerService CreateService(Acquirer acquirer)
        {
            switch (acquirer)
            {
                case Acquirer.Cielo:
                    return CieloService;
                case Acquirer.Stone:
                    return StoneService;
                default:
                    throw new ArgumentException("Requested provider not yet implemented.");
            }
        }
    }
}