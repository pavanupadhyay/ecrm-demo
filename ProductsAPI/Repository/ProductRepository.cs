using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Data;
using ProductsAPI.Data.Entities;
using ProductsAPI.Services.Dto;

namespace ProductsAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationDbContext _dbContext { get; set; }
        public ProductRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _dbContext.Products.FindAsync(id);
        }

        public async Task<List<Product>> GetAllAsyc(Pagination pagination)
        {
              var products = await _dbContext.usp_GetProductsWithPagination
                .FromSqlRaw(@"EXEC [dbo].[usp_GetProductsWithPagination] @PageNumber = {0}, @PageSize = {1}, @Search = {2}",
                    new SqlParameter("@PageNumber", pagination.PageNumber),
                    new SqlParameter("@PageSize", pagination.PageSize),
                    new SqlParameter("@Search", pagination.SearchText ?? (object)DBNull.Value)
                ).ToListAsync();
            return products;
        }

        public async Task<Product> SaveAsync(Product product)
        {
            if (product.ProductId > 0)
            {
                _dbContext.Products.Update(product);
            }
            else
            {
                _dbContext.Products.Add(product);
            }
            await _dbContext.SaveChangesAsync();
            return product;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var foundEntity = await _dbContext.Products.FindAsync(id);
            if (foundEntity != null)
            {
                _dbContext.Products.Remove(foundEntity);
                await _dbContext.SaveChangesAsync();

                return true;
            }
            return false;
        }
    }
}
