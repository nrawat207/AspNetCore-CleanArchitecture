using Ardalis.GuardClauses;

namespace ApplicationCore.Entities.CartAggregate
{
    public class CartItem:BaseEntity
    {
        public decimal UnitPrice { get; private set; }
        public int Quantity { get; private set; }
        public long ProductId { get; private set; }
        public int CartId { get; private set; }

        public CartItem(long productId, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            UnitPrice = unitPrice;
            SetQuantity(quantity);
        }

        public void AddQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            Quantity += quantity;
        }

        public void SetQuantity(int quantity)
        {
            Guard.Against.OutOfRange(quantity, nameof(quantity), 0, int.MaxValue);

            Quantity = quantity;
        }
    }
}
