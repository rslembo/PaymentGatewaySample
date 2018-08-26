using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentGatewaySample.Domain.Contracts;
using PaymentGatewaySample.Domain.Contracts.Models;
using PaymentGatewaySample.Domain.Services;
using PaymentGatewaySample.Filters;
using PaymentGatewaySample.Services.ExtensionMethods;

namespace PaymentGatewaySample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [MerchantAuthorize]
    public class SaleController : ControllerBase
    {
        public ISaleProcessor SaleService { get; }
        public ITransactionFinder TransactionFinder { get; }

        public SaleController(ISaleProcessor saleService, ITransactionFinder transactionFinder)
        {
            SaleService = saleService ?? throw new ArgumentNullException(nameof(saleService));
            TransactionFinder = transactionFinder;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var mid = Guid.Parse(Request.Headers["MerchantId"]);

            var transactions = await TransactionFinder.FindAllByMerchantIdAsync(mid);

            if (transactions == null)
                return NotFound();

            transactions.Select(x => { x.Links = GetLinks(x.Id); return x; }).ToList();
            return Ok(transactions);
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
            var transactionDto = request.ConvertToTransactionDto();
            transactionDto.MerchantId = Guid.Parse(Request.Headers["MerchantId"]);

            var processResult = await SaleService.Process(transactionDto);

            var response = transactionDto.ConvertToSaleResponse();
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
    }
}