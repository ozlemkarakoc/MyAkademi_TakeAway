using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAkademi_TakeAway.Catalog.Dtos.CategoryDtos;
using MyAkademi_TakeAway.Catalog.Dtos.SliderDtos;
using MyAkademi_TakeAway.Catalog.Services.CategoryServices;
using MyAkademi_TakeAway.Catalog.Services.SliderServices;

namespace MyAkademi_TakeAway.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SliderController : ControllerBase
    {
        private readonly ISliderServices _sliderServices;

        public SliderController(ISliderServices sliderServices)
        {
            _sliderServices = sliderServices;
        }

        [HttpGet]
        public async Task<IActionResult> SliderList()
        {
            var values = await _sliderServices.GetAllSliderAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreatSlider(CreateSliderDto createSliderDto)
        {
            await _sliderServices.CreateSliderAsync(createSliderDto);
            return Ok("Slider başarıyla eklendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSlider(string id)
        {
            await _sliderServices.DeleteSliderAsync(id);
            return Ok("Slider başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateSlider(UpdateSliderDto updateSliderDto)
        {
            await _sliderServices.UpdateSliderAsync(updateSliderDto);
            return Ok("Slider başarıyla güncellendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSlider(string id)
        {
            var value = await _sliderServices.GetByIdSliderAsync(id);
            return Ok(value);
        }
    }
}
