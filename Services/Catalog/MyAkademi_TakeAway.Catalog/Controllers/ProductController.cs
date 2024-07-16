using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAkademi_TakeAway.Catalog.Dtos.CategoryDtos;
using MyAkademi_TakeAway.Catalog.Dtos.ProductDtos;
using MyAkademi_TakeAway.Catalog.Services.CategoryServices;
using MyAkademi_TakeAway.Catalog.Services.ProductServices;

namespace MyAkademi_TakeAway.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var values = await _productServices.GetAllProductAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await _productServices.CreateProductAsync(createProductDto);
            return Ok("Ürün başarıyla eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await _productServices.DeleteProductAsync(id);
            return Ok("Ürün başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await _productServices.UpdateProductAsync(updateProductDto);
            return Ok("Ürün başarıyla güncellendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            var value = await _productServices.GetByIdProductAsync(id);
            return Ok(value);
        }
    }
}
