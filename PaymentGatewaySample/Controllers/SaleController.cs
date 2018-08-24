using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PaymentGatewaySample.Domain.Contracts;
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
            SaleService = saleService;
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
            await SaleService.Process();
            return Ok();
        }
    }
}