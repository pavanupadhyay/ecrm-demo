using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace ProductsAPI.Services.Dto
{
  
    public class ProductDto
    {
        public string ProductName { get; set; } = null!;

        public int CategoryId { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public DateTime? CreatedAt { get; set; }

    }
}
