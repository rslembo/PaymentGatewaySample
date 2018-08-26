using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Integrations.ClearSale.Contracts;
using PaymentGatewaySample.Integrations.ClearSale.Contracts.Models;
using PaymentGatewaySample.Integrations.ClearSale.Enums;
using PaymentGatewaySample.Integrations.Stone.ExtensionMethods;
using System;
using System.Collections.Generic;

namespace PaymentGatewaySample.Integrations.ClearSale.Services.Builders
{
    public static class AnalysisRequestBuilder
    {
        public static ClearSaleRequest BuildRequestFromTransactionDto(
            TransactionDto transactionDto, string tokenValue)
        {
            return new ClearSaleRequest
            {
                LoginToken = tokenValue,
                Orders = new List<Order>
                {
                    new Order
                    {
                        Id = transactionDto.MerchantOrderId,
                        Date = DateTime.Now,
                        Email = transactionDto.Customer.Email,
                        TotalItems = Convert.ToDecimal(transactionDto.Payment.Amount),
                        TotalOrder = Convert.ToDecimal(transactionDto.Payment.Amount),
                        Ip = transactionDto.Customer.IpAddress ?? "127.0.0.1",
                        Currency = CurrencyCode.BRL.ToString(),
                        Payments = new List<Payment>
                        {
                            new Payment
                            {
                                Date = DateTime.Now,
                                Amount = Convert.ToDecimal(transactionDto.Payment.Amount),
                                Type = PaymentType.CreditCard,
                                CardNumber = transactionDto.Payment.CreditCard.Number,
                                CardHolderName = transactionDto.Payment.CreditCard.Holder,
                                CardType = transactionDto.Payment.CreditCard.Brand.ToClearSaleCardBrand(),
                                Currency = CurrencyCode.BRL
                            }
                        },
                        ShippingData = new Person
                        {
                            Id = transactionDto.Customer?.Identity ?? "NoId",
                            Type = transactionDto.Customer?.IdentityType != null && transactionDto.Customer.IdentityType.Equals("CPF")
                                    ? PersonType.Person
                                    : PersonType.Company,
                            Name = transactionDto.Customer?.Name ?? "NoName",
                            Address = new Address
                            {
                                City = transactionDto.Customer?.ShippingAddress?.City ?? "NoCity",
                                State = transactionDto.Customer?.ShippingAddress?.State ?? "NoState",
                                ZipCode = transactionDto.Customer?.ShippingAddress?.ZipCode ?? "NoZipCode"
                            },
                            Phones = new List<Phone>
                            {
                                new Phone
                                {
                                    Type = PhoneType.HomePhone,
                                    AreaCode = int.TryParse(transactionDto.Customer?.PhoneAreaCode, out var shipArea) ? shipArea : 55,
                                    Number = transactionDto.Customer?.PhoneNumber ?? "00000000"
                                }
                            }
                        },
                        BillingData = new Person
                        {
                            Id = transactionDto.Customer?.Identity ?? "NoId",
                            Type = transactionDto.Customer?.IdentityType != null && transactionDto.Customer.IdentityType.Equals("CPF")
                                    ? PersonType.Person
                                    : PersonType.Company,
                            Name = transactionDto.Customer?.Name ?? "NoName",
                            Address = new Address
                            {
                                City = transactionDto.Customer?.BillingAddress?.City ?? "NoCity",
                                State = transactionDto.Customer?.BillingAddress?.State ?? "NoState",
                                ZipCode = transactionDto.Customer?.BillingAddress?.ZipCode ?? "NoZipCode"
                            },
                            Phones = new List<Phone>
                            {
                                new Phone
                                {
                                    Type = PhoneType.HomePhone,
                                    AreaCode = int.TryParse(transactionDto.Customer?.PhoneAreaCode, out var billArea) ? billArea : 55,
                                    Number = transactionDto.Customer?.PhoneNumber ?? "00000000"
                                }
                            }
                        },
                        Items = new List<Item>
                        {
                            new Item
                            {
                                Id = transactionDto.MerchantOrderId,
                                Name = transactionDto.Payment.SoftDescriptor ?? "item",
                                ItemValue = Convert.ToDecimal(transactionDto.Payment.Amount),
                                Qty = 1
                            }
                        },
                        Origin = "Website"
                    }
                },
                AnalysisLocation = "BRA"
            };
        }
    }
}