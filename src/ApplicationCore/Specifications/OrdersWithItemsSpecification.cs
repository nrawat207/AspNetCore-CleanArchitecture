using ApplicationCore.Entities.OrderAggregate;
using Ardalis.Specification;
using System.Linq;

namespace ApplicationCore.Specifications
{
    public class OrdersWithItemsSpecification:Specification<Order>
    {
        public OrdersWithItemsSpecification(string customerId)
        {
            Query.Where(o => o.CustomerId == customerId)
                 .Include(o => o.OrderItems)
                    .ThenInclude(i => i.ItemOrdered);
        }
    }
}
