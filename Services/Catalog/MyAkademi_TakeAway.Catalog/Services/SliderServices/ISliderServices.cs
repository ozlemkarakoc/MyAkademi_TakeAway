using MyAkademi_TakeAway.Catalog.Dtos.ProductDtos;
using MyAkademi_TakeAway.Catalog.Dtos.SliderDtos;

namespace MyAkademi_TakeAway.Catalog.Services.SliderServices
{
    public interface ISliderServices
    {
        Task<List<ResultSliderDto>> GetAllSliderAsync();

        Task CreateSliderAsync(CreateSliderDto createSliderDto);
        Task UpdateSliderAsync(UpdateSliderDto updateSliderDto);
        Task DeleteSliderAsync(string id);

        Task<GetByIdSliderDto> GetByIdSliderAsync(string id);
    }
}
