using Microsoft.EntityFrameworkCore;
using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Enums;
using PaymentGatewaySample.Domain.Services;
using PaymentGatewaySample.Repositories.Context;
using PaymentGatewaySample.Services.ExtensionMethods;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Services.Implementation
{
    public class AntifraudProcessor : ISaleProcessor
    {
        public ISaleProcessor SaleProcessor { get; }
        public IClearSaleService ClearSaleService { get; }
        public ITransactionCreator TransactionCreator { get; }
        public ApplicationDbContext DbContext { get; }

        public AntifraudProcessor(ISaleProcessor saleProcessor, IClearSaleService clearSaleService, 
            ITransactionCreator transactionCreator, ApplicationDbContext dbContext)
        {
            SaleProcessor = saleProcessor ?? throw new ArgumentNullException(nameof(saleProcessor));
            ClearSaleService = clearSaleService ?? throw new ArgumentNullException(nameof(clearSaleService));
            TransactionCreator = transactionCreator ?? throw new ArgumentNullException(nameof(transactionCreator));
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<TransactionDto> Process(TransactionDto transactionDto)
        {
            var antifraudConfiguration = (await DbContext.MerchantAntifraudConfigurations
            .Where(x => x.Merchant.Id == transactionDto.MerchantId).ToListAsync())
            ?.FirstOrDefault();

            if (antifraudConfiguration != null && antifraudConfiguration.IsEnabled)
            {
                transactionDto.FraudAnalysis = await ClearSaleService.Process(transactionDto);

                var isStatusAPA = transactionDto.FraudAnalysis.Status.Equals(FraudAnalysisStatus.APA);

                if (!isStatusAPA)
                {
                    transactionDto.Status = TransactionStatus.Aborted;
                    transactionDto.FraudAnalysis.Message = "Payment halted due to fraud threat";

                    var transaction = transactionDto.ConvertToTransaction();
                    await TransactionCreator.InsertAsync(transaction);

                    transactionDto.Id = transaction.Id;
                    transactionDto.CreatedDate = transaction.CreatedDate;

                    return transactionDto;
                }
            }

            return await SaleProcessor.Process(transactionDto);
        }
    }
}