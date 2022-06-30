namespace AviaStoreApp.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int TicketId { get; set; }
        public int price { get; set; }
        public virtual Ticket ticket { get; set; }
        public virtual Order order { get; set; }
    }
}
