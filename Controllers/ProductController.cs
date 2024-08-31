using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RememberTask.Models;
using RememberTask.Service;

namespace RememberTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<Product>> AllProducts()
        {
            return Ok(await _productService.GetAllProduct());
        }

        [HttpGet("GetByID")]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Ok(await _productService.GetProductByID(id));
        }

        [HttpPost("Add product")]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            return Ok(await _productService.CreateProduct(product));
        }

        [HttpPut("Edit product")]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product, int id)
        {
            return Ok(await _productService.UpdateProduct(id, product));
        }

        [HttpDelete("Delete product")]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            return Ok(await _productService.DeleteProduct(id));
        }
    }
}
