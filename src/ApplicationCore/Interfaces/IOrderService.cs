using ApplicationCore.Entities.OrderAggregate;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(int cartId, Address shippingAddress);
    }
}
