using ApplicationCore.Entities.OrderAggregate;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IOrderRepository:IRepository<Order>
    {
        Task<Order> GetByIdWithItemAsync(int id);
    }
}
