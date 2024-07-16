using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyAkademi_TakeAway.Discount.Dtos;
using MyAkademi_TakeAway.Discount.Services;

namespace MyAkademi_TakeAway.Discount.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountCouponsController : ControllerBase
    {
        private readonly IDiscountCouponService _discountCouponService;

        public DiscountCouponsController(IDiscountCouponService discountCouponService)
        {
            _discountCouponService = discountCouponService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllDiscountCoupon()
        {
            var values = await _discountCouponService.GetResultDiscountCouponsAsync();
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createDiscountCouponDto)
        {
            await _discountCouponService.CreateDiscountCouponAsync(createDiscountCouponDto);
            return Ok("Kupon oluşturuldu.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountCouponService.DeleteDiscountCouponAsync(id);
            return Ok("Kupon silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UpdateDiscountCouponDto updateDiscountCouponDto)
        {
            await _discountCouponService.UpdateDiscountCouponAsync(updateDiscountCouponDto);
            return Ok("Kupon güncellendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCoupon(int id)
        {
            var value = await _discountCouponService.GetByIdDiscountCouponAsync(id);
            return Ok(value);
        }
    }
}
