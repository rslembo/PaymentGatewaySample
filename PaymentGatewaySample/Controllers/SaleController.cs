using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentGatewaySample.Domain.Contracts;
using PaymentGatewaySample.Domain.Contracts.Models;
using PaymentGatewaySample.Domain.Dtos;
using PaymentGatewaySample.Domain.Services;
using PaymentGatewaySample.Filters;

namespace PaymentGatewaySample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [MerchantAuthorize]
    public class SaleController : ControllerBase
    {
        public ISaleService SaleService { get; }
        public ITransactionFinder TransactionFinder { get; }

        public SaleController(ISaleService saleService, ITransactionFinder transactionFinder)
        {
            SaleService = saleService ?? throw new ArgumentNullException(nameof(saleService));
            TransactionFinder = transactionFinder;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var mid = Guid.Parse(Request.Headers["MerchantId"]);

            var transaction = await TransactionFinder.FindByIdAndMerchantIdAsync(id, mid);

            if (transaction == null)
                return NotFound();

            transaction.Links = GetLinks(transaction.Id);
            return Ok(transaction);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaleRequest request)
        {
            var transactionDto = ConvertTransactionDtoFromSaleRequest(request);
            transactionDto.MerchantId = Guid.Parse(Request.Headers["MerchantId"]);

            var processResult = await SaleService.Process(transactionDto);

            var response = ConvertSaleResponseFromTransactionDto(transactionDto);
            response.Links = GetLinks(response.Id);

            return Created($"Sale/{response.Id}", response);
        }

        private IEnumerable<Link> GetLinks(Guid id)
        {
            return new List<Link>
            {
                new Link
                {
                    Method = "GET",
                    Href = $"http://localhost:51425/api/sale/{id}",
                    Rel = "self"
                }
            };
        }

        private TransactionDto ConvertTransactionDtoFromSaleRequest(SaleRequest request)
        {
            return new TransactionDto
            {
                RequestId = request.RequestId,
                MerchantOrderId = request.MerchantOrderId,
                Payment = new PaymentDto
                {
                    Amount = request.Payment.Amount.Value,
                    CreditCard = new CreditCardDto
                    {
                        Number = request.Payment.CreditCard.Number,
                        ExpirationMonth = request.Payment.CreditCard.ExpirationMonth,
                        ExpirationYear = request.Payment.CreditCard.ExpirationYear,
                        Brand = request.Payment.CreditCard.Brand,
                        Holder = request.Payment.CreditCard.Holder,
                        SecurityCode = request.Payment.CreditCard.SecurityCode
                    },
                    Type = Domain.Enums.PaymentType.CreditCard,
                    Currency = request.Payment.Currency,
                    Installments = request.Payment.Installments,
                    SoftDescriptor = request.Payment.SoftDescriptor
                },
                Status = Domain.Enums.TransactionStatus.Captured,
            };
        }

        private SaleResponse ConvertSaleResponseFromTransactionDto(TransactionDto transactionDto)
        {
            return new SaleResponse
            {
                Id = transactionDto.Id,
                RequestId = transactionDto.RequestId,
                MerchantOrderId = transactionDto.MerchantOrderId,
                Status = transactionDto.Status,
                Payment = new Payment
                {
                    Amount = transactionDto.Payment.Amount,
                    Type = transactionDto.Payment.Type,
                    CreditCard = new CreditCard
                    {
                        Number = transactionDto.Payment.CreditCard.Number,
                        ExpirationMonth = transactionDto.Payment.CreditCard.ExpirationMonth,
                        ExpirationYear = transactionDto.Payment.CreditCard.ExpirationYear,
                        Brand = transactionDto.Payment.CreditCard.Brand
                    }
                },
                ProofOfSale = transactionDto.ProofOfSale,
                AcquirerTransactionKey = transactionDto.AcquirerTransactionKey,
                AuthorizationCode = transactionDto.AuthorizationCode,
                AcquirerTransactionId = transactionDto.AcquirerTransactionId,
                ReturnCode = transactionDto.ReturnCode,
                ReturnMessage = transactionDto.ReturnMessage,
                CreatedDate  = transactionDto.CreatedDate
            };
        }
    }
}