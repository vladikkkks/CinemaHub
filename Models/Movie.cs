using System;

namespace CinemaHub.Models
{
    public class Movie
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public int GenreID { get; set; }
        public int DurationMinutes { get; set; }
        public string AgeRating { get; set; }
        public decimal BasePrice { get; set; }
    }
}