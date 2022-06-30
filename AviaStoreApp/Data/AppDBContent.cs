
using AviaStoreApp.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace AviaStoreApp.Data
{
    public class AppDBContent : DbContext
    {
       public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
        {

        }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Ticket> Ticket { get; set; }
        public DbSet<Flight> Flight { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

    }
}
