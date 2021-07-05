using System;

namespace CinemaAdminApp.Models
{
    public class Movie
    {
        public Guid Id { get; set; }
        public string MovieName { get; set; }
        public string MovieImage { get; set; }
        public string MovieDescriprtion { get; set; }
        public int MoviePrice { get; set; }
        public int Rating { get; set; }
    }
}
