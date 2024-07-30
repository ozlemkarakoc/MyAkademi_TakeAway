using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAkademi_TakeAway.Basket.Dtos;
using MyAkademi_TakeAway.Basket.LoginServices;
using MyAkademi_TakeAway.Basket.Services;

namespace MyAkademi_TakeAway.Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly ILoginService _loginService;

        public BasketsController(IBasketService basketService, ILoginService loginService)
        {
            _basketService = basketService;
            _loginService = loginService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyBasketDetail()
        {
            var values = await _basketService.GetBasket(_loginService.GetUserId);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> SaveMyBasket(BasketTotalDto basket)
        {
            basket.UserId = _loginService.GetUserId;
            await _basketService.SaveBasket(basket);
            return Ok("Sepette değişiklik kaydedildi.");
        }
        public async Task<IActionResult> DeleteBasket()
        {
            await _basketService.DeleteBasket(_loginService.GetUserId);
            return Ok("Silme işlemi başarıyla gerçekleşmiştir.");
        }
    }
}
