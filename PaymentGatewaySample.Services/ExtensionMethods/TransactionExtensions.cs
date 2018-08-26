using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Entities;

namespace PaymentGatewaySample.Services.ExtensionMethods
{
    public static class TransactionExtensions
    {
        //TODO: AutoMapper
        public static TransactionDto ConvertToTransactionDto(this Transaction transaction)
        {
            return new TransactionDto
            {
                Id = transaction.Id,
                RequestId = transaction.RequestId,
                MerchantOrderId = transaction.MerchantOrderId,
                Customer = new CustomerDto
                {
                    BirthDate = transaction.Customer.BirthDate,
                    Email = transaction.Customer.Email,
                    Identity = transaction.Customer.Identity,
                    IdentityType = transaction.Customer.IdentityType,
                    Name = transaction.Customer.Name,
                    BillingAddress = new BillingAddressDto
                    {
                        City = transaction.Customer.BillingAddress.City,
                        Complement = transaction.Customer.BillingAddress.Complement,
                        Country = transaction.Customer.BillingAddress.Country,
                        District = transaction.Customer.BillingAddress.District,
                        Number = transaction.Customer.BillingAddress.Number,
                        State = transaction.Customer.BillingAddress.State,
                        Street = transaction.Customer.BillingAddress.Street,
                        ZipCode = transaction.Customer.BillingAddress.ZipCode
                    },
                    ShippingAddress = new ShippingAddressDto
                    {
                        City = transaction.Customer.ShippingAddress.City,
                        Complement = transaction.Customer.ShippingAddress.Complement,
                        Country = transaction.Customer.ShippingAddress.Country,
                        District = transaction.Customer.ShippingAddress.District,
                        Number = transaction.Customer.ShippingAddress.Number,
                        State = transaction.Customer.ShippingAddress.State,
                        Street = transaction.Customer.ShippingAddress.Street,
                        ZipCode = transaction.Customer.ShippingAddress.ZipCode
                    }
                },
                Payment = new PaymentDto
                {
                    Amount = transaction.Payment.Amount,
                    CreditCard = new CreditCardDto
                    {
                        Number = transaction.Payment.CreditCard.Number,
                        ExpirationMonth = transaction.Payment.CreditCard.ExpirationMonth,
                        ExpirationYear = transaction.Payment.CreditCard.ExpirationYear,
                        Brand = transaction.Payment.CreditCard.Brand
                    },
                    Type = Domain.Enums.PaymentType.CreditCard
                },
                Status = Domain.Enums.TransactionStatus.Captured,
                ProofOfSale = transaction.ProofOfSale,
                AcquirerTransactionKey = transaction.AcquirerTransactionKey,
                AuthorizationCode = transaction.AuthorizationCode,
                AcquirerTransactionId = transaction.AcquirerTransactionId,
                ReturnCode = transaction.ReturnCode,
                ReturnMessage = transaction.ReturnMessage,
                CreatedDate = transaction.CreatedDate
            };
        }
    }
}