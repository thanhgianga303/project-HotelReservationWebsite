using OrderAPI.Infrastructure.Repositories;
using OrderAPI.Models;

namespace OrderAPI.Data.Repositories
{
    public class OrderRepository : EFRepository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext context) : base(context)
        {
        }
    }
}