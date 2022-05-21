using Catalog.Application.Dtos.Products;
using Catalog.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [ApiController]
    public class CatalogsController : BaseController
    {
        private readonly IProductService _productService;

        public CatalogsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] AddProductDto productDto)
        {
            var productId = await _productService.AddProduct(productDto);
            return Ok(productId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] UpdateProductDto productDto)
        {
            var result = await _productService.UpdateProduct(productDto);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.DeleteProduct(id);
            return Ok(result);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _productService.GetAllProducts();
            return Ok(result);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _productService.FindProductById(id);
            return Ok(result);
        }
    }
}