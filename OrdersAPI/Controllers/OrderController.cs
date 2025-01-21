using Microsoft.AspNetCore.Mvc;
using OrdersAPI.Services;
using OrdersAPI.Services.Dto;

namespace OrdersAPI.Controllers
{
    [Route("api/order")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService) 
        {
            _orderService = orderService;
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody]OrderDto orderDto)
        {
            var result = _orderService.CreateOrderAsync(orderDto);
            return Ok(orderDto);
        }
    }
}
