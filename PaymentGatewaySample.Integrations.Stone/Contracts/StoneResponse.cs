using PaymentGatewaySample.Integrations.Stone.Contracts.Models;
using System;
using System.Collections.Generic;

namespace PaymentGatewaySample.Integrations.Stone.Contracts
{
    public class StoneResponse
    {
        public ErrorReport ErrorReport { get; set; }
        public int InternalTime { get; set; }
        public Guid MerchantKey { get; set; }
        public Guid RequestKey { get; set; }
        public Guid BuyerKey { get; set; }
        public IEnumerable<CreditCardTransactionResult> CreditCardTransactionResultCollection { get; set; }
        public OrderResult OrderResult { get; set; }
    }
}