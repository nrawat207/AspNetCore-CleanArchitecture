using ApplicationCore.Entities.OrderAggregate;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class OrderRepository : EfRepository<Order>, IOrderRepository
    {
        public OrderRepository(EStoreDBContext dBContext):base(dBContext)
        {

        }

        public Task<Order> GetByIdWithItemAsync(int id)
        {
            return _dbContext.Orders
            .Include(o => o.OrderItems)
            .Include($"{nameof(Order.OrderItems)}.{nameof(OrderItem.ItemOrdered)}")
            .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
