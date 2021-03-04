using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface ICartService
    {
        Task AddItemToCart(int cartId, int productId, decimal price, int quantity = 1);
        Task SetQuantities(int cartId, Dictionary<string, int> quantities);
        Task DeleteBasketAsync(int cartId);
    }
}
