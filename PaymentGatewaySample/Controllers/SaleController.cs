using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentGatewaySample.Domain.Contracts;
using PaymentGatewaySample.Domain.Contracts.Models;
using PaymentGatewaySample.Domain.Services;

namespace PaymentGatewaySample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public IActionResult Get(Guid id)
        {
            var transaction = TransactionFinder.FindById(id);
            return Ok("Transaction");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaleRequest request)
        {
            await SaleService.Process(request);
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
    }
}