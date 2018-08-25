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
    public class SaleController : ControllerBase
    {
        public ISaleService SaleService { get; }
        public ITransactionFinder TransactionFinder { get; }
        public IMerchantFinder MerchantFinder { get; }

        public SaleController(ISaleService saleService, ITransactionFinder transactionFinder, IMerchantFinder merchantFinder)
        {
            SaleService = saleService ?? throw new ArgumentNullException(nameof(saleService));
            TransactionFinder = transactionFinder;
            MerchantFinder = merchantFinder;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var transaction = TransactionFinder.FindById(id);
            return Ok("Transaction");
        }

        [HttpPost]
        [MerchantAuthorize]
        public async Task<IActionResult> Post([FromBody] SaleRequest request)
        {
            var merchantId = Request.Headers["MerchantId"];
            var transactionDto = ConvertTransactionDtoFromSaleRequest(request, merchantId);

            await SaleService.Process(transactionDto);

            return Ok();
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

        private TransactionDto ConvertTransactionDtoFromSaleRequest(SaleRequest request, string merchantId)
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
                        Brand = request.Payment.CreditCard.Brand
                    },
                    Type = Domain.Enums.PaymentType.CreditCard
                },
                Status = Domain.Enums.TransactionStatus.Captured,
                MerchantId = Guid.Parse(merchantId)
            };
        }
    }
}