using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebAppDocker.Database.Entities;
using WebAppDocker.Services;

namespace WebAppDocker.Controllers
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
        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = _productService.GetAll();
            if (result.Count > 0)
                return Ok(result);
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            var result = _productService.Add(product);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(Product product)
        {
            await _productService.Update(product);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.Delete(id);
            return Ok();
        }

    }
}
