using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Data;
using ProductsAPI.Services;
using ProductsAPI.Services.Dto;

namespace ProductsAPI.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        { 
            _productService = productService;
        }

        /// <summary>
        /// Gets the list of product based on passed pagination parameter values
        /// </summary>
        /// <param name="pagination">Allows to send Pagenumber, page size and search criteria along with requeset</param>
        /// <returns>List of product records based on passed criteria</returns>
        [HttpGet("List")]
        public async Task<IActionResult> List([FromHeader]Pagination pagination)
        {
            var result = await _productService.GetAllAsyc(pagination);
            return Ok(result);
        }

        [HttpGet("GetbyId")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete("Remove")]
        public async Task<IActionResult> Remove(int id)
        {
            var result = await _productService.RemoveAsync(id);
            return Ok(result);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody]ProductDto productDto)
        { 
            var result = await _productService.SaveAsync(productDto);
            return Ok(result);
        }
    }
}
