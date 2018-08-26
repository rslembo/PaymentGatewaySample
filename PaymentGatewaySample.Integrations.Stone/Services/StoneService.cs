using Microsoft.EntityFrameworkCore;
using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Enums;
using PaymentGatewaySample.Domain.Services;
using PaymentGatewaySample.Integrations.Stone.Contracts;
using PaymentGatewaySample.Integrations.Stone.Enums;
using PaymentGatewaySample.Integrations.Stone.Services.Builders;
using PaymentGatewaySample.Integrations.Stone.Services.Interfaces;
using PaymentGatewaySample.Repositories.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Integrations.Stone.Services
{
    public class StoneService : IStoneService
    {
        public IStoneApiClient StoneApiClient { get; }
        public ApplicationDbContext DbContext { get; }

        public StoneService(IStoneApiClient stoneApiClient, ApplicationDbContext dbContext)
        {
            StoneApiClient = stoneApiClient ?? throw new ArgumentNullException(nameof(stoneApiClient));
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<TransactionDto> ProcessSaleAsync(TransactionDto transactionDto)
        {
            var paymentConfiguration = (await DbContext.MerchantPaymentConfigurations
                .Where(x => x.Acquirer == Acquirer.Stone && x.Merchant.Id == transactionDto.MerchantId).ToListAsync())
                .Single();

            var request = StoneRequestBuilder.BuildRequestFromTransactionDto(transactionDto);

            var stoneResponse = await StoneApiClient.PostSaleTransactionAsync(request, paymentConfiguration.AcquirerMerchantId);

            FillTransactionDtoWithResponseData(transactionDto, stoneResponse);

            return transactionDto;
        }

        private void FillTransactionDtoWithResponseData(TransactionDto transactionDto, StoneResponse stoneResponse)
        {
            if (stoneResponse.ErrorReport != null)
            {
                transactionDto.Status = TransactionStatus.Aborted;
                transactionDto.ReturnCode = stoneResponse.ErrorReport.ErrorItemCollection.First().ErrorCode.ToString();
                transactionDto.ReturnMessage = stoneResponse.ErrorReport.ErrorItemCollection.First().Description;
                return;
            }

            var creditCardTransactionResult = stoneResponse.CreditCardTransactionResultCollection.First();

            transactionDto.ProofOfSale = creditCardTransactionResult.TransactionIdentifier;
            transactionDto.AcquirerTransactionKey = creditCardTransactionResult.TransactionKeyToAcquirer;
            transactionDto.AuthorizationCode = creditCardTransactionResult.AuthorizationCode;
            transactionDto.AcquirerTransactionId = creditCardTransactionResult.TransactionKey;
            transactionDto.ReturnCode = creditCardTransactionResult.AcquirerReturnCode;
            transactionDto.ReturnMessage = creditCardTransactionResult.AcquirerMessage;
            transactionDto.Status = MapStoneStatusToTransactionStatus(creditCardTransactionResult.CreditCardTransactionStatus);
        }

        private TransactionStatus MapStoneStatusToTransactionStatus(CreditCardTransactionStatus stoneStatus)
        {
            switch (stoneStatus)
            {
                case CreditCardTransactionStatus.AuthorizedPendingCapture:
                    return TransactionStatus.Accepted;
                case CreditCardTransactionStatus.Captured:
                case CreditCardTransactionStatus.PartialCapture:
                    return TransactionStatus.Captured;
                case CreditCardTransactionStatus.NotAuthorized:
                    return TransactionStatus.Rejected;
                case CreditCardTransactionStatus.Voided:
                case CreditCardTransactionStatus.PendingVoid:
                case CreditCardTransactionStatus.PartialVoid:
                    return TransactionStatus.Canceled;
                case CreditCardTransactionStatus.Refunded:
                case CreditCardTransactionStatus.PendingRefund:
                case CreditCardTransactionStatus.PartialRefunded:
                    return TransactionStatus.Reversed;
                case CreditCardTransactionStatus.WithError:
                case CreditCardTransactionStatus.NotFoundInAcquirer:
                    return TransactionStatus.Aborted;
                default:
                    return TransactionStatus.Undefined;
            }
        }
    }
}