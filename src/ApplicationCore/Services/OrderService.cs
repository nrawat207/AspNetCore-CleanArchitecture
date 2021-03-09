using ApplicationCore.Entities;
using ApplicationCore.Entities.CartAggregate;
using ApplicationCore.Entities.OrderAggregate;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using Ardalis.GuardClauses;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<Cart> _cartRepository;
        private readonly IRepository<Product> _productRepository;

        public OrderService(IRepository<Order> orderRepository,
            IRepository<Cart> cartRepository,
            IRepository<Product> productRepository)
        {
            _orderRepository = orderRepository;
            _cartRepository = cartRepository;
            _productRepository = productRepository;
        }

        public async Task CreateOrderAsync(int cartId, Address shippingAddress)
        {
            var cartSpec = new CartWithItemsSpecification(cartId);
            var cart = await _cartRepository.FirstOrDefaultAsync(cartSpec);

            Guard.Against.NullCart(cartId, cart);
            Guard.Against.EmptyCartOnCheckout(cart.Items);

            var productSpec = new ProductsSpecification(cart.Items.Select(x => x.ProductId).ToArray());
            var products = await _productRepository.ListAsync(productSpec);

            var items = cart.Items.Select(cartItem =>
            {
                var product = products.First(p => p.Id == cartItem.ProductId);
                var productOrdered = new ProductOrdered(product.Id, product.Name, product.PictureUri);
                var orderItem = new OrderItem(productOrdered, cartItem.UnitPrice, cartItem.Quantity);
                return orderItem;
            }).ToList();

            var order = new Order(cart.CustomerId, shippingAddress, items);
            await _orderRepository.AddAsync(order);
        }
    }
}
