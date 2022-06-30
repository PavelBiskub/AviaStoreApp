
namespace AviaStoreApp.Data.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Type { get; set; }
        public bool IsAvailable { get; set; }
        public int FlightId { get; set; }
        public virtual Flight Flight { get; set; }

    }
}
