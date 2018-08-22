using System;
using System.Transactions;

namespace PaymentGatewaySample.Domain.Entities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public TransactionStatus Status { get; set; }
    }
}