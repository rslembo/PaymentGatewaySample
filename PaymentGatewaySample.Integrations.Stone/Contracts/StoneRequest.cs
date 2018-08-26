using PaymentGatewaySample.Integrations.Stone.Contracts.Models;
using System.Collections.Generic;

namespace PaymentGatewaySample.Integrations.Stone.Contracts
{
    public class StoneRequest
    {
        public IEnumerable<CreditCardTransaction> CreditCardTransactionCollection { get; set; }
        public Order Order { get; set; }
    }
}