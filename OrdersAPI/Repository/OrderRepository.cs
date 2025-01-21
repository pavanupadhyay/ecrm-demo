using OrdersAPI.Data.Entities;

namespace OrdersAPI.Repository
{
    public class OrderRepository:IOrderRepository
    {
        private ApplicationDbContext _dbContext { get; set; }
        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Order> CreatOrderAsync(Order order)
        {
            _dbContext.Orders.Add(order);
            await _dbContext.SaveChangesAsync();
            return order;
        }
    }
}
