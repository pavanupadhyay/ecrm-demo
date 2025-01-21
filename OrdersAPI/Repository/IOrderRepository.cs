using OrdersAPI.Data.Entities;

namespace OrdersAPI.Repository
{
    public interface IOrderRepository
    {
        Task<Order> CreatOrderAsync(Order order);
    }
}
