﻿using Microsoft.EntityFrameworkCore;
using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Enums;
using PaymentGatewaySample.Domain.Services;
using PaymentGatewaySample.Integrations.Cielo.Contracts;
using PaymentGatewaySample.Integrations.Cielo.Contracts.Models;
using PaymentGatewaySample.Integrations.Cielo.Enums;
using PaymentGatewaySample.Integrations.Cielo.Services.Builders;
using PaymentGatewaySample.Integrations.Cielo.Services.Interfaces;
using PaymentGatewaySample.Repositories.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Integrations.Cielo.Services
{
    public class CieloService : ICieloService
    {
        public ICieloApiClient CieloApiClient { get; }
        public ApplicationDbContext DbContext { get; }

        public CieloService(ICieloApiClient cieloApiClient, ApplicationDbContext dbContext)
        {
            CieloApiClient = cieloApiClient ?? throw new ArgumentNullException(nameof(cieloApiClient));
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<TransactionDto> ProcessSaleAsync(TransactionDto transactionDto)
        {
            var paymentConfiguration = (await DbContext.MerchantPaymentConfigurations
                .Where(x => x.Acquirer == Acquirer.Cielo && x.Merchant.Id == transactionDto.MerchantId).ToListAsync())
                .Single();

            var request = CieloRequestBuilder.BuildRequestFromTransactionDto(transactionDto);
            var credential = new CieloMerchantCredential(paymentConfiguration.AcquirerMerchantId,
                paymentConfiguration.AcquirerMerchantKey);

            var cieloResponse = await CieloApiClient.PostSaleTransactionAsync(request, credential);

            FillTransactionDtoWithResponseData(transactionDto, cieloResponse);

            return transactionDto;
        }

        private void FillTransactionDtoWithResponseData(TransactionDto transactionDto, CieloResponse cieloResponse)
        {
            transactionDto.ProofOfSale = cieloResponse.ProofOfSale;
            transactionDto.AcquirerTransactionKey = cieloResponse.Tid;
            transactionDto.AuthorizationCode = cieloResponse.AuthorizationCode;
            transactionDto.AcquirerTransactionId = cieloResponse.PaymentId;
            transactionDto.ReturnCode = cieloResponse.ReturnCode;
            transactionDto.ReturnMessage = cieloResponse.ReturnMessage;
            transactionDto.Status = MapCieloStatusToTransactionStatus(cieloResponse.Status);
        }

        private TransactionStatus MapCieloStatusToTransactionStatus(CieloStatus status)
        {
            switch (status)
            {
                case CieloStatus.NotFinished:
                case CieloStatus.Aborted:
                    return TransactionStatus.Aborted;
                case CieloStatus.Authorized:
                case CieloStatus.Pending:
                case CieloStatus.Scheduled:
                    return TransactionStatus.Accepted;
                case CieloStatus.PaymentConfirmed:
                    return TransactionStatus.Captured;
                case CieloStatus.Denied:
                    return TransactionStatus.Rejected;
                case CieloStatus.Voided:
                    return TransactionStatus.Canceled;
                case CieloStatus.Refunded:
                    return TransactionStatus.Reversed;
                default:
                    return TransactionStatus.Undefined;
            }
        }
    }
}