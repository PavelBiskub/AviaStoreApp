namespace AviaStoreApp.Data.Models
{
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Ticket Ticket { get; set; }
        public int Price { get; set; }
        public string ShopCartId { get; set; }
    }
}
