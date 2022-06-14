using System.ComponentModel.DataAnnotations;

namespace BookMyShowAPI.Model
{
    public class Ticket
    {
        [Key]
        public int ticketId { get; set; }

        public string transactionMode { get; set; }=string.Empty;

        public string transactionStatus { get; set; }=string.Empty ;

    public int seats { get; set; }

        public int totalCost { get; set; }
        public DateTime bookingDate { get; set; }

        
    }
}
