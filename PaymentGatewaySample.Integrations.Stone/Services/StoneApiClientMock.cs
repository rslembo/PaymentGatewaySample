using PaymentGatewaySample.Integrations.Stone.Contracts;
using PaymentGatewaySample.Integrations.Stone.Contracts.Models;
using PaymentGatewaySample.Integrations.Stone.Enums;
using PaymentGatewaySample.Integrations.Stone.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Integrations.Stone.Services
{
    public class StoneApiClientMock : IStoneApiClient
    {
        public async Task<StoneResponse> PostSaleTransactionAsync(StoneRequest request, Guid merchantKey)
        {
            return await Task.Run(() =>
            {
                var response = new StoneResponse
                {
                    InternalTime = 10,
                    MerchantKey = Guid.NewGuid(),
                    RequestKey = Guid.NewGuid(),
                    BuyerKey = Guid.NewGuid(),
                };

                if (request.CreditCardTransactionCollection.First().HolderName.Equals("Stone Error"))
                {
                    response.ErrorReport = new ErrorReport
                    {
                        Category = "RequestError",
                        ErrorItemCollection = new List<ErrorItem>
                        {
                            new ErrorItem
                            {
                                Description = "Suspected counterfeit card",
                                ErrorCode = 1029,
                                ErrorField = "HolderName",
                                SeverityCode = "Error"
                            }
                        }
                    };
                    return response;
                }

                response.CreditCardTransactionResultCollection = new List<CreditCardTransactionResult>
                {
                    new CreditCardTransactionResult
                    {
                        AcquirerMessage = "Transação capturada com sucesso",
                        AcquirerName = "Stone",
                        AcquirerReturnCode = "10",
                        AffiliationCode = "123",
                        AmountInCents = request.CreditCardTransactionCollection.First().AmountInCents,
                        AuthorizationCode = "1234",
                        AuthorizedAmountInCents = request.CreditCardTransactionCollection.First().AmountInCents,
                        CapturedAmountInCents = request.CreditCardTransactionCollection.First().AmountInCents,
                        CaptureDate = DateTime.Now,
                        CreditCard = new CreditCard
                        {
                            CreditCardBrand = request.CreditCardTransactionCollection.First().CreditCardBrand,
                            InstantBuyKey = Guid.NewGuid(),
                            IsExpiredCreditCard = false,
                            MaskedCreditCardNumber = $"{request.CreditCardTransactionCollection.First().CreditCardNumber.Substring(0,6)}" +
                            $"******{request.CreditCardTransactionCollection.First().CreditCardNumber.Substring(request.CreditCardTransactionCollection.First().CreditCardNumber.Length - 4)}"
                        },
                        CreditCardOperation = CreditCardOperation.AuthAndCapture,
                        CreditCardTransactionStatus = CreditCardTransactionStatus.Captured,
                        DueDate = null,
                        ExternalTime = 10,
                        PaymentMethodName = "CreditCard",
                        RefundedAmountInCents = null,
                        Success = true,
                        TransactionIdentifier = "4546",
                        TransactionKey = Guid.NewGuid(),
                        TransactionKeyToAcquirer = "4dfq3245r",
                        TransactionReference = Guid.NewGuid(),
                        UniqueSequentialNumber = "543524",
                        VoidedAmountInCents = null
                    }
                };

                response.OrderResult = new OrderResult
                {
                    CreateDate = DateTime.Now,
                    OrderKey = Guid.NewGuid(),
                    OrderReference = request.Order.OrderReference
                };

                return response;
            });
        }
    }
}