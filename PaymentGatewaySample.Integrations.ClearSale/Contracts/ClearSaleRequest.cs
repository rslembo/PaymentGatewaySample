using PaymentGatewaySample.Integrations.ClearSale.Contracts.Models;
using System.Collections.Generic;

namespace PaymentGatewaySample.Integrations.ClearSale.Contracts
{
    public class ClearSaleRequest
    {
        public string ApiKey { get; set; }
        public string LoginToken { get; set; }
        public IEnumerable<Order> Orders { get; set; }
        public string AnalysisLocation { get; set; }
    }
}