using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PaymentGatewaySample.Domain.Contracts.Models;
using PaymentGatewaySample.Domain.Enums;
using System;
using System.Collections.Generic;

namespace PaymentGatewaySample.Domain.Contracts
{
    public class SaleResponse
    {
        public Guid Id { get; set; }
        public Guid? RequestId { get; set; }
        public string MerchantOrderId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionStatus Status { get; set; }
        public Customer Customer { get; set; }
        public Payment Payment { get; set; }
        public FraudAnalysis FraudAnalysis { get; set; }
        public DateTime CreatedDate { get; set; }

        public string ProofOfSale { get; set; }
        public string AcquirerTransactionKey { get; set; }
        public string AuthorizationCode { get; set; }
        public Guid? AcquirerTransactionId { get; set; }
        public string ReturnCode { get; set; }
        public string ReturnMessage { get; set; }

        public IEnumerable<Link> Links { get; set; }
    }
}