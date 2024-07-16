using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAkademi_TakeAway.Catalog.Dtos.CategoryDtos;
using MyAkademi_TakeAway.Catalog.Services.CategoryServices;

namespace MyAkademi_TakeAway.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var values = await _categoryServices.GetAllCategoryAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryServices.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori başarıyla eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryServices.DeleteCategoryAsync(id);
            return Ok("Kategori başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryServices.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori başarıyla güncellendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(string id)
        {
            var value = await _categoryServices.GetByIdCategoryAsync(id);
            return Ok(value);
        }
    }
}
