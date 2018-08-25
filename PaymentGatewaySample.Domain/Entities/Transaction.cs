﻿using System;
using System.Transactions;

namespace PaymentGatewaySample.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid? RequestId { get; set; }
        public string MerchantOrderId { get; set; }
        public TransactionStatus Status { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual FraudAnalysis FraudAnalysis { get; set; }

        public virtual Merchant Merchant { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}