using System;

namespace CinemaHub.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int SessionID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public int SeatNumber { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsPaid { get; set; }
    }
}