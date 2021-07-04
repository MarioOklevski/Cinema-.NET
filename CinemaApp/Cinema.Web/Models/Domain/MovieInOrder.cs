using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.Domain
{
    public class MovieInOrder
    {
        public Guid MovieId { get; set; }
        public Movie SelectedMovie { get; set; }
        public Guid OrderId { get; set; }
        public Order UserOrder { get; set; }
    }
}
