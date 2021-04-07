using ApplicationCore.Entities.OrderAggregate;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(long cartId, Address shippingAddress);
    }
}
