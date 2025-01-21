namespace OrdersAPI.Services.Dto
{
    public class OrderDto
    {
        public OrderDto()
        {
            this.OrderDetail = new();
        }
        //OrderID, CustomerID, OrderDate, TotalAmount, Status
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public Decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public OrderDetailDto OrderDetail { get; set; }
    }

    public class OrderDetailDto {
        //OrderDetailID, OrderID, ProductID, Quantity, UnitPrice, TotalPrice
        public int OrderDetailId { get; set; }
        public int OrderID { get; set; }
        public int ProductId{ get; set; }
        public int Quantity{ get; set; }
        public decimal UnitPrice{ get; set; }
        public decimal TotalPrice { get; set; }
    }
}
