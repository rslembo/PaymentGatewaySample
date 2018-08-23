using System;
using System.Transactions;
using PaymentGatewaySample.Domain.Services;

namespace PaymentGatewaySample.Services.Implementation
{
    public class TransactionFinder : ITransactionFinder
    {
        public TransactionFinder()
        {

        }

        public Transaction FindById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}