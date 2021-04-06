using ApplicationCore.Entities.CartAggregate;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Ardalis.GuardClauses;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class CartService : ICartService
    {
        private readonly IRepository<Cart> _cartRepository;
        private readonly IAppLogger<CartService> _logger;

        public CartService(IRepository<Cart> cartRepository, IAppLogger<CartService> logger)
        {
            _cartRepository = cartRepository;
            _logger = logger;
        }

        public async Task<Cart> GetOrCreateCart(string userName,CancellationToken cancellationToken = default)
        {
            var cartSpec = new CartWithItemsSpecification(userName);
            var cart = (await _cartRepository.FirstOrDefaultAsync(cartSpec,cancellationToken));

            if (cart == null)
            {
                return await _cartRepository.AddAsync(new Cart(userName), cancellationToken);
            }
            return cart;
        }

        public async Task AddItemToCart(long cartId, long productId, decimal price, int quantity = 1)
        {
            var cartSepc = new CartWithItemsSpecification(cartId);
            var cart = await _cartRepository.FirstOrDefaultAsync(cartSepc);
            Guard.Against.NullCart(cartId, cart);

            cart.AddItem(productId, price, quantity);

            await _cartRepository.UpdateAsync(cart);
        }

        public async Task DeleteCartAsync(long cartId)
        {
            var cart = await _cartRepository.GetByIdAsync(cartId);
            await _cartRepository.DeleteAsync(cart);
        }

        public async Task SetQuantities(long cartId, Dictionary<string, int> quantities)
        {
            Guard.Against.Null(quantities, nameof(quantities));
            var cartSpec = new CartWithItemsSpecification(cartId);
            var cart = await _cartRepository.FirstOrDefaultAsync(cartSpec);
            Guard.Against.NullCart(cartId, cart);

            foreach (var item in cart.Items)
            {
                if (quantities.TryGetValue(item.Id.ToString(), out var quantity))
                {
                    if (_logger != null)
                        _logger.LogInformation($"Updating quantity for item Id:{item.Id} to quantity:{quantity}");
                    item.SetQuantity(quantity);

                }
            }
            cart.RemoveEmptyItems();
            await _cartRepository.UpdateAsync(cart);
        }

    }
}
