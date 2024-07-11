using MyAkademi_TakeAway.Catalog.Dtos.CategoryDtos;
using MyAkademi_TakeAway.Catalog.Dtos.FeatureDtos;

namespace MyAkademi_TakeAway.Catalog.Services.FeatureServices
{
    public interface IFeatureServices
    {
        Task<List<ResultFeatureDto>> GetAllFeatureAsync();

        Task CreateFeatureAsync(CreateFeatureDto createFeatureDto);
        Task UpdateFeatureAsync(UpdateFeatureDto updateFeatureDto);
        Task DeleteFeatureAsync(string id);

        Task<GetByIdFeatureDto> GetByIdFeatureAsync(string id);
    }
}
