using AviaStoreApp.Data.Interfaces;
using AviaStoreApp.Data.Models;
using AviaStoreApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AviaStoreApp.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IAllTickets _ticketRepository;
        private readonly ShopCart _shopCart;

        public ShopCartController(IAllTickets ticketRepository,ShopCart shopCart)
        {
            _ticketRepository = ticketRepository;
            _shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = _shopCart.getShopItems();
            _shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {
                shopCart = _shopCart,
            };

            return View(obj);
        }

        public RedirectToActionResult addToCart(int id)
        {
            var item = _ticketRepository.Tickets.FirstOrDefault(i => i.Id == id);
            if(item != null)
            {
                _shopCart.AddToCart(item);
            }
            return RedirectToAction("Index");
        }
    }
}
