using PaymentGatewaySample.Integrations.Cielo.Enums;
using System;

namespace PaymentGatewaySample.Integrations.Cielo.Contracts
{
    public class CieloResponse
    {
        public string ProofOfSale { get; set; }
        public string Tid { get; set; }
        public string AuthorizationCode { get; set; }
        public Guid PaymentId { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }
        public CieloStatus Status { get; set; }
    }
}