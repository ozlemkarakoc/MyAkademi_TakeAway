using MyAkademi_TakeAway.Basket.Dtos;

namespace MyAkademi_TakeAway.Basket.Services
{
    public interface IBasketService
    {
        Task<BasketTotalDto> GetBasket(string UserId);
        Task SaveBasket(BasketTotalDto basket);
        Task DeleteBasket(string UserId);
    }
}
