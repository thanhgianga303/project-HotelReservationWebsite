using OrderAPI.Infrastructure.Repositories;

namespace OrderAPI.Models
{
    public interface IOrderRepository : IRepository<Order>
    {
    }
}