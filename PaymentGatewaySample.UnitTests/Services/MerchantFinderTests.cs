using AutoFixture.Idioms;
using FluentAssertions;
using NSubstitute;
using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Services.Implementation;
using PaymentGatewaySample.UnitTests.AutoNSubstituteData;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace PaymentGatewaySample.UnitTests.Services
{
    public class MerchantFinderTests
    {
        [Theory, AutoNSubstituteData]
        public void GuardClauseTest(GuardClauseAssertion guard)
        {
            guard.Verify(typeof(MerchantFinder).GetConstructors());
        }

        [Theory, AutoNSubstituteData]
        public async Task FindAllAsync_WhenExistsMerchants_ShouldReturnMerchants(List<Merchant> merchants, MerchantFinder sut)
        {
            sut.MerchantRepository.FindAllAsync().Returns(merchants);

            var result = await sut.FindAllAsync();

            result.Should().NotBeNullOrEmpty();
            result.Should().BeEquivalentTo(merchants);
        }

        [Theory, AutoNSubstituteData]
        public async Task FindAllAsync_WhenNoMerchant_ShouldReturnEmptyList(List<Merchant> merchants, MerchantFinder sut)
        {
            merchants = new List<Merchant>();
            sut.MerchantRepository.FindAllAsync().Returns(merchants);

            var result = await sut.FindAllAsync();

            result.Should().BeEmpty();
        }
    }
}