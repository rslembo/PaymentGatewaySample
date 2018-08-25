using PaymentGatewaySample.Domain.Contracts;
using System.Threading.Tasks;

namespace PaymentGatewaySample.Domain.Services
{
    public interface ISaleService
    {
        Task Process(SaleRequest request);
    }
}