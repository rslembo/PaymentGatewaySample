using AutoFixture.Idioms;
using NSubstitute;
using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Services.Implementation;
using PaymentGatewaySample.UnitTests.AutoNSubstituteData;
using System.Threading.Tasks;
using Xunit;

namespace PaymentGatewaySample.UnitTests.Services
{
    public class TransactionCreatorTests
    {
        [Theory, AutoNSubstituteData]
        public void GuardClauseTest(GuardClauseAssertion guard)
        {
            guard.Verify(typeof(TransactionCreator).GetConstructors());
        }

        [Theory, AutoNSubstituteData]
        public async Task InsertTransaction_WhenTransactionNotNull_ShouldInsertSuccessfully(Transaction transaction, TransactionCreator sut)
        {
            await sut.InsertAsync(transaction);

            await sut.TransactionRepository.Received(1).InsertAsync(Arg.Is(transaction));
        }

        [Theory, AutoNSubstituteData]
        public async Task InsertTransaction_WhenTransactionIsNull_ShouldNotInsert(TransactionCreator sut)
        {
            await sut.InsertAsync(null);

            await sut.TransactionRepository.DidNotReceive().InsertAsync(Arg.Any<Transaction>());
        }
    }
}