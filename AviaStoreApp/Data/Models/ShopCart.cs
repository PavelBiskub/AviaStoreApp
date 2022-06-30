using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AviaStoreApp.Data.Models
{
    public class ShopCart
    {
        private readonly AppDBContent DBContent;
        public ShopCart(AppDBContent DBContent)
        {
            this.DBContent = DBContent;
        }
        public string ShopCartIdSes { get; set; }
        public List<ShopCartItem> ListShopItems { get; set; }

        public static ShopCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDBContent>();
            string SCId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", SCId);

            return new ShopCart(context) { ShopCartIdSes = SCId };   
        }

        public void AddToCart(Ticket ticket)
        {
            DBContent.ShopCartItem.Add(new ShopCartItem
            {
                ShopCartId = ShopCartIdSes,
                Ticket = ticket,
                Price = ticket.Price
            });

            DBContent.SaveChanges();
        }

        public List<ShopCartItem> getShopItems()
        {
            return DBContent.ShopCartItem.Where(c => c.ShopCartId == ShopCartIdSes).Include(s => s.Ticket).ToList();
        }
    }
}
