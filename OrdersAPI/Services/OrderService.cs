using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OrdersAPI.Repository;
using OrdersAPI.Services.Dto;

namespace OrdersAPI.Services
{
    public interface IOrderService
    {
        Task<OrderDto> CreateOrderAsync(OrderDto orderDto);
    }

    public class OrderService:IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private IHttpClientFactory _httpClientFactory { get; set; }
        private readonly IConfiguration _configuration;
        private readonly string getProductsUrl = string.Empty;
        public OrderService
        (
            IOrderRepository orderRepository, 
            IHttpClientFactory httpClientFactory, 
            IConfiguration configuration
        )
        {
            _orderRepository = orderRepository;
            _httpClientFactory = httpClientFactory;
            _configuration = configuration;
            getProductsUrl = _configuration.GetValue<string>("MicroserviceUrls:ProductListUrl", "");
        }
        
        public async Task<OrderDto> CreateOrderAsync(OrderDto orderDto)
        {
            var client = _httpClientFactory.CreateClient();
            
            var productDetail = await client.GetAsync(getProductsUrl);
            if (productDetail.IsSuccessStatusCode)
            {
                dynamic result = productDetail.Content.ReadAsStringAsync().Result;
            }
            return orderDto;
        }
    }
}
