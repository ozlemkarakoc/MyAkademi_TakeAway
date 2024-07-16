using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyAkademi_TakeAway.Discount.Entities;
using System.Data;

namespace MyAkademi_TakeAway.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            __connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        public DbSet<DiscountCoupon> DiscountCoupons { get; set; }

        private readonly string __connectionString;
        public IDbConnection CreateConnection() => new SqlConnection(__connectionString);
    }
}