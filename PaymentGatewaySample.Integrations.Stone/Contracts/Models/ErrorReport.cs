using System.Collections.Generic;

namespace PaymentGatewaySample.Integrations.Stone.Contracts.Models
{
    public class ErrorReport
    {
        public string Category { get; set; }
        public IEnumerable<ErrorItem> ErrorItemCollection { get; set; }
    }
}
