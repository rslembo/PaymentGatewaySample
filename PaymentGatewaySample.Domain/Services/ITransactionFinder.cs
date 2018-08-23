using System;
using System.Transactions;

namespace PaymentGatewaySample.Domain.Services
{
    public interface ITransactionFinder
    {
        Transaction FindById(Guid id);
    }
}