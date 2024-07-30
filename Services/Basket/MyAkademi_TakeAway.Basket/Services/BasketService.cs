﻿using MyAkademi_TakeAway.Basket.Dtos;
using MyAkademi_TakeAway.Basket.Settings;
using System.Text.Json;

namespace MyAkademi_TakeAway.Basket.Services
{
    public class BasketService : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketService(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task DeleteBasket(string UserId)
        {
            await _redisService.GetDb().KeyDeleteAsync(UserId);
        }

        public async Task<BasketTotalDto> GetBasket(string UserId)
        {
            var basket = await _redisService.GetDb().StringGetAsync(UserId);
            return JsonSerializer.Deserialize<BasketTotalDto>(basket);
        }

        public async Task SaveBasket(BasketTotalDto basket)
        {
            await _redisService.GetDb().StringSetAsync(basket.UserId, JsonSerializer.Serialize(basket));
        }
    }
}
