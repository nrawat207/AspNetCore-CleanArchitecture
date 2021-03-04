using ApplicationCore.Entities.CartAggregate;
using Ardalis.Specification;

namespace ApplicationCore.Specifications
{
    public sealed class CartWithItemsSpecification : Specification<Cart>
    {
        public CartWithItemsSpecification(int cartId)
        {
            Query
                .Where(c => c.Id == cartId)
                .Include(c => c.Items);
        }

        public CartWithItemsSpecification(string customerId)
        {
            Query
                .Where(c => c.CustomerId == customerId)
                .Include(c => c.Items);
        }
    }
}
