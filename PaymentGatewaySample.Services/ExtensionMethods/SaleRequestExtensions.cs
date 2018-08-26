using PaymentGatewaySample.Domain.Contracts;
using PaymentGatewaySample.Domain.Dtos;

namespace PaymentGatewaySample.Services.ExtensionMethods
{
    public static class SaleRequestExtensions
    {
        //TODO: AutoMapper
        public static TransactionDto ConvertToTransactionDto(this SaleRequest saleRequest)
        {
            return new TransactionDto
            {
                RequestId = saleRequest.RequestId,
                MerchantOrderId = saleRequest.MerchantOrderId,
                Customer = new CustomerDto
                {
                    BirthDate = saleRequest.Customer.BirthDate,
                    Email = saleRequest.Customer.Email,
                    Identity = saleRequest.Customer.Identity,
                    IdentityType = saleRequest.Customer.IdentityType,
                    Name = saleRequest.Customer.Name,
                    BillingAddress = new BillingAddressDto
                    {
                        City = saleRequest.Customer.BillingAddress.City,
                        Complement = saleRequest.Customer.BillingAddress.Complement,
                        Country = saleRequest.Customer.BillingAddress.Country,
                        District = saleRequest.Customer.BillingAddress.District,
                        Number = saleRequest.Customer.BillingAddress.Number,
                        State = saleRequest.Customer.BillingAddress.State,
                        Street = saleRequest.Customer.BillingAddress.Street,
                        ZipCode = saleRequest.Customer.BillingAddress.ZipCode
                    },
                    ShippingAddress = new ShippingAddressDto
                    {
                        City = saleRequest.Customer.ShippingAddress.City,
                        Complement = saleRequest.Customer.ShippingAddress.Complement,
                        Country = saleRequest.Customer.ShippingAddress.Country,
                        District = saleRequest.Customer.ShippingAddress.District,
                        Number = saleRequest.Customer.ShippingAddress.Number,
                        State = saleRequest.Customer.ShippingAddress.State,
                        Street = saleRequest.Customer.ShippingAddress.Street,
                        ZipCode = saleRequest.Customer.ShippingAddress.ZipCode
                    }
                },
                Payment = new PaymentDto
                {
                    Amount = saleRequest.Payment.Amount.Value,
                    CreditCard = new CreditCardDto
                    {
                        Number = saleRequest.Payment.CreditCard.Number,
                        ExpirationMonth = saleRequest.Payment.CreditCard.ExpirationMonth,
                        ExpirationYear = saleRequest.Payment.CreditCard.ExpirationYear,
                        Brand = saleRequest.Payment.CreditCard.Brand,
                        Holder = saleRequest.Payment.CreditCard.Holder,
                        SecurityCode = saleRequest.Payment.CreditCard.SecurityCode
                    },
                    Type = Domain.Enums.PaymentType.CreditCard,
                    Currency = saleRequest.Payment.Currency,
                    Installments = saleRequest.Payment.Installments,
                    SoftDescriptor = saleRequest.Payment.SoftDescriptor
                },
                Status = Domain.Enums.TransactionStatus.Captured,
            };
        }
    }
}