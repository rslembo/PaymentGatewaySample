using PaymentGatewaySample.Integrations.ClearSale.Contracts.Models;
using System.Collections.Generic;

namespace PaymentGatewaySample.Integrations.ClearSale.Contracts
{
    public class ClearSaleResponse
    {
        public string TransactionId { get; set; }
        public IEnumerable<OrderStatus> Orders { get; set; }
    }
}