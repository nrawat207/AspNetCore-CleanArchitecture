using ApplicationCore.Entities.CartAggregate;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICartService
    {
        Task<Cart> GetOrCreateCart(string userName, CancellationToken cancellationToken = default);
        Task AddItemToCart(long cartId, long productId, decimal price, int quantity = 1);
        Task SetQuantities(long cartId, Dictionary<string, int> quantities);
        Task DeleteCartAsync(long cartId);
    }
}
