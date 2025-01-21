using ProductsAPI.Data.Entities;

namespace ProductsAPI.Services.Dto
{
    public class ProductListDto
    {

        public string ProductName { get; set; } = null!;

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
