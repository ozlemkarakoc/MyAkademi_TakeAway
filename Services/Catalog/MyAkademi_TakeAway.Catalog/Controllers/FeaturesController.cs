using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAkademi_TakeAway.Catalog.Dtos.CategoryDtos;
using MyAkademi_TakeAway.Catalog.Dtos.FeatureDtos;
using MyAkademi_TakeAway.Catalog.Services.CategoryServices;
using MyAkademi_TakeAway.Catalog.Services.FeatureServices;

namespace MyAkademi_TakeAway.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureServices _featureServices;

        public FeaturesController(IFeatureServices featureServices)
        {
            _featureServices = featureServices;
        }

        [HttpGet]
        public async Task<IActionResult> FeatureList()
        {
            var values = await _featureServices.GetAllFeatureAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFeature(CreateFeatureDto createFeatureDto)
        {
            await _featureServices.CreateFeatureAsync(createFeatureDto);
            return Ok("Özellik başarıyla eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFeature(string id)
        {
            await _featureServices.DeleteFeatureAsync(id);
            return Ok("Özellik başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            await _featureServices.UpdateFeatureAsync(updateFeatureDto);
            return Ok("Özellik başarıyla güncellendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFeature(string id)
        {
            var value = await _featureServices.GetByIdFeatureAsync(id);
            return Ok(value);
        }
    }
}
