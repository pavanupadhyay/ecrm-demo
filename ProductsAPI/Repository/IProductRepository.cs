using ProductsAPI.Data;
using ProductsAPI.Data.Entities;

namespace ProductsAPI.Repository
{
    public interface IProductRepository
    {
        Task<Product?> GetByIdAsync(int id);
        Task<List<Product>> GetAllAsyc(Pagination pagination);
        Task<Product> SaveAsync(Product product);
        Task<bool> RemoveAsync(int id);
    }
}
