using System;

namespace CinemaAdminApp.Models
{
    public class MovieInOrder
    {
        public Guid MovieId { get; set; }
        public Movie OrderedMovie { get; set; }
        public Movie SelectedMovie { get; set; }
        public Guid OrderId { get; set; }
        public Order UserOrder { get; set; }
    }
}
