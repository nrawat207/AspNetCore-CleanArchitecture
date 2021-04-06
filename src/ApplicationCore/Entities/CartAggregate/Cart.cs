using System.Collections.Generic;
using System.Linq;

namespace ApplicationCore.Entities.CartAggregate
{
    public class Cart:BaseEntity
    {
        public string CustomerId { get; private set; }

        private readonly List<CartItem> _items = new List<CartItem>();
        public IReadOnlyCollection<CartItem> Items => _items.AsReadOnly();

        public Cart(string customerId)
        {
            CustomerId = customerId;
        }

        public void AddItem(long productId, decimal unitPrice, int quantity = 1)
        {
            if (!Items.Any(i => i.ProductId == productId))
            {
                _items.Add(new CartItem(productId, quantity, unitPrice));
                return;
            }
            var existingItem = Items.FirstOrDefault(i => i.ProductId == productId);
            existingItem.AddQuantity(quantity);
        }

        public void RemoveEmptyItems()
        {
            _items.RemoveAll(i => i.Quantity == 0);
        }

        public void SetNewCustomerId(string customerId)
        {
            CustomerId = customerId;
        }
    }
}
