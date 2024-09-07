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

        [Route("GetAll")]
        [HttpGet]
        public async Task<ActionResult<Product>> AllProducts()
        {
            return Ok(await _productService.GetAll());
        }

        [Route("GetByID")]
        [HttpGet]
        public async Task<IActionResult> GetProduct(int id)
        {
            return Ok(await _productService.GetByID(id));
        }

        [Route("Add product")]
        [HttpPost]
        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            return Ok(await _productService.Create(product));
        }

        [Route("Edit product")]
        [HttpPut]
        public async Task<ActionResult<List<Product>>> UpdateProduct(Product product, int id)
        {
            return Ok(await _productService.Update(id, product));
        }

        [Route("Delete product")]
        [HttpDelete]
        public async Task<ActionResult<List<Product>>> DeleteProduct(int id)
        {
            return Ok(await _productService.Delete(id));
        }
    }
}