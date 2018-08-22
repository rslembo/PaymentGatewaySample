using System;
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

        public SaleController(ISaleService saleService)
        {
            SaleService = saleService;
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok("Teste");
        }

        [HttpPost]
        public IActionResult Post([FromBody] SaleRequest request)
        {
            SaleService.Process();
            return Ok();
        }
    }
}