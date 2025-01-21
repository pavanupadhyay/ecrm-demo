using System;
using System.Collections.Generic;

namespace OrdersAPI.Data.Entities;

public partial class VwProduct
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public DateTime? CreatedAt { get; set; }
}
