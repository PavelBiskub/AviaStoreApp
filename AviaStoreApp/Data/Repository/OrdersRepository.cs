using AviaStoreApp.Data.Interfaces;
using AviaStoreApp.Data.Models;

namespace AviaStoreApp.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDBContent DBContent;
        private readonly ShopCart shopCart;

        public OrdersRepository (AppDBContent DBContent, ShopCart shopCart)
        {
            this.DBContent = DBContent;
            this.shopCart = shopCart;
        }   
        public void createOrder(Order order)
        {
            DBContent.Order.Add(order);
            DBContent.SaveChanges();

            var items = shopCart.ListShopItems;     

            foreach(var el in items)
            {
                var orderDetail = new OrderDetail()
                {
                    TicketId = el.Ticket.Id,
                    OrderId = order.Id,
                    price = el.Ticket.Price
                };
                DBContent.OrderDetail.Add(orderDetail);
            }
            DBContent.SaveChanges();
        }
    }
}
