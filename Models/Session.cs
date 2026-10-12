using System;

namespace CinemaHub.Models
{
    public class Session
    {
        public int SessionID { get; set; }
        public int MovieID { get; set; }
        public int HallID { get; set; }
        public DateTime StartTime { get; set; }
        public decimal TicketPrice { get; set; }
    }
}