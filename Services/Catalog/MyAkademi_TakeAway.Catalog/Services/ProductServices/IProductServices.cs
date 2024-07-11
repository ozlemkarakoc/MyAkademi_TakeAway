using MyAkademi_TakeAway.Catalog.Dtos.FeatureDtos;
using MyAkademi_TakeAway.Catalog.Dtos.ProductDtos;

namespace MyAkademi_TakeAway.Catalog.Services.ProductServices
{
    public interface IProductServices
    {
        Task<List<ResultProductDto>> GetAllProductAsync();

        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);

        Task<GetByIdProductDto> GetByIdProductAsync(string id);
    }
}
