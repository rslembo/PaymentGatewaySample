using PaymentGatewaySample.Domain.Contracts;
using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Entities;
using PaymentGatewaySample.Domain.Enums;

namespace PaymentGatewaySample.Services.ExtensionMethods
{
    public static class TransactionDtoExtensions
    {
        //TODO: AutoMapper
        public static SaleResponse ConvertToSaleResponse(this TransactionDto transactionDto)
        {
            return new SaleResponse
            {
                Id = transactionDto.Id,
                RequestId = transactionDto.RequestId,
                MerchantOrderId = transactionDto.MerchantOrderId,
                Status = transactionDto.Status,
                Customer = new Domain.Contracts.Models.Customer
                {
                    BirthDate = transactionDto.Customer.BirthDate,
                    Email = transactionDto.Customer.Email,
                    IpAddress = transactionDto.Customer.IpAddress,
                    PhoneAreaCode = transactionDto.Customer.PhoneAreaCode,
                    PhoneNumber = transactionDto.Customer.PhoneNumber,
                    Identity = transactionDto.Customer.Identity,
                    IdentityType = transactionDto.Customer.IdentityType,
                    Name = transactionDto.Customer.Name,
                    BillingAddress = new Domain.Contracts.Models.Address
                    {
                        City = transactionDto.Customer.BillingAddress.City,
                        Complement = transactionDto.Customer.BillingAddress.Complement,
                        Country = transactionDto.Customer.BillingAddress.Country,
                        District = transactionDto.Customer.BillingAddress.District,
                        Number = transactionDto.Customer.BillingAddress.Number,
                        State = transactionDto.Customer.BillingAddress.State,
                        Street = transactionDto.Customer.BillingAddress.Street,
                        ZipCode = transactionDto.Customer.BillingAddress.ZipCode
                    },
                    ShippingAddress = new Domain.Contracts.Models.Address
                    {
                        City = transactionDto.Customer.ShippingAddress.City,
                        Complement = transactionDto.Customer.ShippingAddress.Complement,
                        Country = transactionDto.Customer.ShippingAddress.Country,
                        District = transactionDto.Customer.ShippingAddress.District,
                        Number = transactionDto.Customer.ShippingAddress.Number,
                        State = transactionDto.Customer.ShippingAddress.State,
                        Street = transactionDto.Customer.ShippingAddress.Street,
                        ZipCode = transactionDto.Customer.ShippingAddress.ZipCode
                    }
                },
                Payment = new Domain.Contracts.Models.Payment
                {
                    Amount = transactionDto.Payment.Amount,
                    Type = transactionDto.Payment.Type,
                    CreditCard = new Domain.Contracts.Models.CreditCard
                    {
                        Number = transactionDto.Payment.CreditCard.Number,
                        ExpirationMonth = transactionDto.Payment.CreditCard.ExpirationMonth,
                        ExpirationYear = transactionDto.Payment.CreditCard.ExpirationYear,
                        Brand = transactionDto.Payment.CreditCard.Brand
                    }
                },
                FraudAnalysis = new Domain.Contracts.Models.FraudAnalysis
                {
                    ProviderId = transactionDto.FraudAnalysis?.ProviderId,
                    Score = transactionDto.FraudAnalysis?.Score,
                    Status = transactionDto.FraudAnalysis?.Status,
                    Message = transactionDto.FraudAnalysis?.Message
                },
                ProofOfSale = transactionDto.ProofOfSale,
                AcquirerTransactionKey = transactionDto.AcquirerTransactionKey,
                AuthorizationCode = transactionDto.AuthorizationCode,
                AcquirerTransactionId = transactionDto.AcquirerTransactionId,
                ReturnCode = transactionDto.ReturnCode,
                ReturnMessage = transactionDto.ReturnMessage,
                CreatedDate = transactionDto.CreatedDate
            };
        }

        //TODO: AutoMapper
        public static Transaction ConvertToTransaction(this TransactionDto transactionDto)
        {
            return new Transaction
            {
                RequestId = transactionDto.RequestId,
                MerchantOrderId = transactionDto.MerchantOrderId,
                Status = transactionDto.Status,
                Customer = new Domain.Entities.Customer
                {
                    BirthDate = transactionDto.Customer.BirthDate,
                    Email = transactionDto.Customer.Email,
                    IpAddress = transactionDto.Customer.IpAddress,
                    PhoneAreaCode = transactionDto.Customer.PhoneAreaCode,
                    PhoneNumber = transactionDto.Customer.PhoneNumber,
                    Identity = transactionDto.Customer.Identity,
                    IdentityType = transactionDto.Customer.IdentityType,
                    Name = transactionDto.Customer.Name,
                    BillingAddress = new Domain.Entities.BillingAddress
                    {
                        City = transactionDto.Customer.BillingAddress.City,
                        Complement = transactionDto.Customer.BillingAddress.Complement,
                        Country = transactionDto.Customer.BillingAddress.Country,
                        District = transactionDto.Customer.BillingAddress.District,
                        Number = transactionDto.Customer.BillingAddress.Number,
                        State = transactionDto.Customer.BillingAddress.State,
                        Street = transactionDto.Customer.BillingAddress.Street,
                        ZipCode = transactionDto.Customer.BillingAddress.ZipCode
                    },
                    ShippingAddress = new Domain.Entities.ShippingAddress
                    {
                        City = transactionDto.Customer.ShippingAddress.City,
                        Complement = transactionDto.Customer.ShippingAddress.Complement,
                        Country = transactionDto.Customer.ShippingAddress.Country,
                        District = transactionDto.Customer.ShippingAddress.District,
                        Number = transactionDto.Customer.ShippingAddress.Number,
                        State = transactionDto.Customer.ShippingAddress.State,
                        Street = transactionDto.Customer.ShippingAddress.Street,
                        ZipCode = transactionDto.Customer.ShippingAddress.ZipCode
                    }
                },
                Payment = new Domain.Entities.Payment
                {
                    Amount = transactionDto.Payment.Amount.Value,
                    CreditCard = new Domain.Entities.CreditCard
                    {
                        Number = transactionDto.Payment.CreditCard.Number,
                        ExpirationMonth = transactionDto.Payment.CreditCard.ExpirationMonth,
                        ExpirationYear = transactionDto.Payment.CreditCard.ExpirationYear,
                        Brand = transactionDto.Payment.CreditCard.Brand
                    },
                    Type = PaymentType.CreditCard
                },
                Merchant = new Merchant
                {
                    Id = transactionDto.MerchantId.Value
                },
                FraudAnalysis = transactionDto.FraudAnalysis == null ? null : 
                new Domain.Entities.FraudAnalysis
                {
                    ProviderId = transactionDto.FraudAnalysis.ProviderId,
                    Score = transactionDto.FraudAnalysis.Score,
                    Status = transactionDto.FraudAnalysis.Status,
                    Message = transactionDto.FraudAnalysis.Message
                },
                ProofOfSale = transactionDto.ProofOfSale,
                AcquirerTransactionKey = transactionDto.AcquirerTransactionKey,
                AuthorizationCode = transactionDto.AuthorizationCode,
                AcquirerTransactionId = transactionDto.AcquirerTransactionId,
                ReturnCode = transactionDto.ReturnCode,
                ReturnMessage = transactionDto.ReturnMessage
            };
        }
    }
}