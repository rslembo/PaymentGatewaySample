using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using PaymentGatewaySample.Domain.Contracts.Models;
using PaymentGatewaySample.Domain.Enums;
using System;
using System.Collections.Generic;

namespace PaymentGatewaySample.Domain.Dtos
{
    public class TransactionDto
    {
        public Guid Id { get; set; }
        public Guid? RequestId { get; set; }
        public string MerchantOrderId { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TransactionStatus Status { get; set; }
        public PaymentDto Payment { get; set; }
        public FraudAnalysisDto FraudAnalysis { get; set; }

        public Guid? MerchantId { get; set; }
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