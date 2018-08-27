using FluentAssertions;
using NSubstitute;
using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Services.ExtensionMethods;
using PaymentGatewaySample.Services.Implementation;
using PaymentGatewaySample.UnitTests.AutoNSubstituteData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using AutoFixture.Idioms;

namespace PaymentGatewaySample.UnitTests.Services
{
    public class TransactionFinderTests
    {
        [Theory, AutoNSubstituteData]
        public void GuardClauseTest(GuardClauseAssertion guard)
        {
            guard.Verify(typeof(TransactionFinder).GetConstructors());
        }

        [Theory, AutoNSubstituteData]
        public async Task FindAllByMerchantId_WhenMerchantHasTransactions_ShouldReturnTransactionDtoList(
            Guid merchantId, List<Transaction> transactions, TransactionFinder sut)
        {
            sut.TransactionRepository.FindAllByMerchantIdAsync(
                Arg.Is(merchantId)).Returns(transactions);

            var result = await sut.FindAllByMerchantIdAsync(merchantId);

            result.Should().NotBeNullOrEmpty();
            result.Should().BeOfType(typeof(List<TransactionDto>));
        }

        [Theory, AutoNSubstituteData]
        public async Task FindAllByMerchantId_WhenMerchantHasntTransactions_ShouldReturnNull(
            Guid merchantId, List<Transaction> transactions, TransactionFinder sut)
        {
            transactions = new List<Transaction>();
            sut.TransactionRepository.FindAllByMerchantIdAsync(Arg.Is(merchantId)).Returns(transactions);

            var result = await sut.FindAllByMerchantIdAsync(merchantId);

            result.Should().BeNull();
        }

        [Theory, AutoNSubstituteData]
        public async Task FindByIdAndMerchantId_WhenTransactionExistsForMerchant_ShouldReturnTransactionDto(
            Guid transactionId, Guid merchantId, Transaction transaction, TransactionFinder sut)
        {
            sut.TransactionRepository.FindByIdAndMerchantIdAsync(
                Arg.Is(transactionId), Arg.Is(merchantId)).Returns(transaction);

            var result = await sut.FindByIdAndMerchantIdAsync(transactionId, merchantId);

            result.Should().NotBeNull();
            result.Should().BeOfType(typeof(TransactionDto));
            result.Should().BeEquivalentTo(transaction.ConvertToTransactionDto());
        }

        [Theory, AutoNSubstituteData]
        public async Task FindByIdAndMerchantId_WhenTransactionDoesntExistsForMerchant_ShouldReturnNull(
            Guid transactionId, Guid merchantId, Transaction transaction, TransactionFinder sut)
        {
            transaction = null;
            sut.TransactionRepository.FindByIdAndMerchantIdAsync(
                Arg.Is(transactionId), Arg.Is(merchantId)).Returns(transaction);

            var result = await sut.FindByIdAndMerchantIdAsync(transactionId, merchantId);

            result.Should().BeNull();
        }
    }
}