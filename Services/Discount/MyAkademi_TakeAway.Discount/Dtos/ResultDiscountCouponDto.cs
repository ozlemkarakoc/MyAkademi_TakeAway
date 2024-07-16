namespace MyAkademi_TakeAway.Discount.Dtos
{
    public class ResultDiscountCouponDto
    {
        public int DiscountCouponID { get; set; }
        public string Code { get; set; }
        public int Rate { get; set; }
        public bool IsActive { get; set; }
    }
}
