using AutoFixture.Idioms;
using FluentAssertions;
using NSubstitute;
using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Domain.Enums;
using PaymentGatewaySample.Services.Implementation;
using PaymentGatewaySample.UnitTests.AutoNSubstituteData;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace PaymentGatewaySample.UnitTests.Services
{
    public class MerchantConfigurationAcquirerFinderTests
    {
        [Theory, AutoNSubstituteData]
        public void GuardClauseTest(GuardClauseAssertion guard)
        {
            guard.Verify(typeof(MerchantConfigurationAcquirerFinder).GetConstructors());
        }

        [Theory, AutoNSubstituteData]
        public async Task GetAcquirerByTransaction_WhenMerchantHasConfigurationForSelectedCardBrand_ShouldReturnAcquirer(
            TransactionDto transactionDto, Merchant merchant, MerchantConfigurationAcquirerFinder sut)
        {
            transactionDto.Payment.CreditCard.Brand = CardBrand.Master;
            merchant.PaymentConfigurations = new List<MerchantPaymentConfiguration>
            {
                new MerchantPaymentConfiguration { Acquirer = Acquirer.Cielo, Brand = CardBrand.Master }
            };

            sut.MerchantFinder.FindByIdAsync(Arg.Is(transactionDto.MerchantId.Value)).Returns(merchant);

            var result = await sut.GetAcquirerByTransaction(transactionDto);

            result.Should().NotBeNull();
            result.Should().BeEquivalentTo(merchant.PaymentConfigurations.First().Acquirer);
        }

        [Theory, AutoNSubstituteData]
        public async Task GetAcquirerByTransaction_WhenMerchantHasntConfigurationForSelectedCardBrand_ShouldReturnUndefined(
            TransactionDto transactionDto, Merchant merchant, MerchantConfigurationAcquirerFinder sut)
        {
            transactionDto.Payment.CreditCard.Brand = CardBrand.Master;
            merchant.PaymentConfigurations = new List<MerchantPaymentConfiguration>
            {
                new MerchantPaymentConfiguration { Acquirer = Acquirer.Cielo, Brand = CardBrand.Visa }
            };

            sut.MerchantFinder.FindByIdAsync(Arg.Is(transactionDto.MerchantId.Value)).Returns(merchant);

            var result = await sut.GetAcquirerByTransaction(transactionDto);

            result.Should().BeEquivalentTo(CardBrand.Undefined);
        }

        [Theory, AutoNSubstituteData]
        public async Task GetAcquirerByTransaction_WhenMerchantHasntConfiguration_ShouldReturnUndefined(
            TransactionDto transactionDto, Merchant merchant, MerchantConfigurationAcquirerFinder sut)
        {
            merchant.PaymentConfigurations = new List<MerchantPaymentConfiguration>();
            sut.MerchantFinder.FindByIdAsync(Arg.Is(transactionDto.MerchantId.Value)).Returns(merchant);

            var result = await sut.GetAcquirerByTransaction(transactionDto);

            result.Should().BeEquivalentTo(CardBrand.Undefined);
        }

        [Theory, AutoNSubstituteData]
        public async Task GetAcquirerByTransaction_WhenMerchantNotFound_ShouldReturnUndefined(
            TransactionDto transactionDto, Merchant merchant, MerchantConfigurationAcquirerFinder sut)
        {
            merchant = null;
            sut.MerchantFinder.FindByIdAsync(Arg.Is(transactionDto.MerchantId.Value)).Returns(merchant);

            var result = await sut.GetAcquirerByTransaction(transactionDto);

            result.Should().BeEquivalentTo(CardBrand.Undefined);
        }
    }
}