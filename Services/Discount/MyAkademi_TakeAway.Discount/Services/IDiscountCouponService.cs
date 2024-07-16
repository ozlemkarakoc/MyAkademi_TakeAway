using MyAkademi_TakeAway.Discount.Dtos;

namespace MyAkademi_TakeAway.Discount.Services
{
    public interface IDiscountCouponService
    {
        Task<List<ResultDiscountCouponDto>> GetResultDiscountCouponsAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createDiscountCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateDiscountCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
    }
}
