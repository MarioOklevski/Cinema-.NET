using Cinema.Web.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public CinemaAppUser User { get; set; }

        public virtual ICollection<MovieInOrder> Movies { get; set; }
    }
}
