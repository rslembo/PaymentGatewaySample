using Microsoft.EntityFrameworkCore;
using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Services;
using PaymentGatewaySample.Integrations.ClearSale.Services.Builders;
using PaymentGatewaySample.Integrations.ClearSale.Services.Interfaces;
using PaymentGatewaySample.Repositories.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Integrations.ClearSale.Services
{
    public class ClearSaleService : IClearSaleService
    {
        public IClearSaleApiClient ClearSaleApiClient { get; }
        public ApplicationDbContext DbContext { get; }

        public ClearSaleService(IClearSaleApiClient clearSaleApiClient, ApplicationDbContext dbContext)
        {
            ClearSaleApiClient = clearSaleApiClient ?? throw new ArgumentNullException(nameof(clearSaleApiClient));
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<FraudAnalysisDto> Process(TransactionDto transactionDto)
        {
            var antifraudConfiguration = (await DbContext.MerchantAntifraudConfigurations
                .Where(x => x.Merchant.Id == transactionDto.MerchantId).ToListAsync())
                .Single();

            var authRequest = AuthRequestBuilder.BuildRequestFromAntifraudConfiguration(antifraudConfiguration);
            var authResponse = await ClearSaleApiClient.AuthorizeAsync(authRequest);

            var analysisRequest = AnalysisRequestBuilder.BuildRequestFromTransactionDto(
                transactionDto, authResponse.Token.Value);

            var analysisResponse = await ClearSaleApiClient.AnalyzeAsync(analysisRequest);

            return FraudAnalysisBuilder.BuildFromClearSaleResponse(analysisResponse);
        }
    }
}