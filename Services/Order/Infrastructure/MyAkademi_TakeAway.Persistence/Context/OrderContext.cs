using Microsoft.EntityFrameworkCore;
using MyAkademi_TakeAway.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAkademi_TakeAway.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;initial catalog=MyAkademiTakeAwayOrderDb;integrated Security=true");
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails  { get; set; }
        public DbSet<Ordering> Orderings  { get; set; }
    }
}
