using PaymentGatewaySample.Domain.Contracts.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace PaymentGatewaySample.Domain.Contracts
{
    public class SaleRequest
    {
        public Guid? RequestId { get; set; }
        public string MerchantOrderId { get; set; }
        [Required]
        public Payment Payment { get; set; }
    }
}