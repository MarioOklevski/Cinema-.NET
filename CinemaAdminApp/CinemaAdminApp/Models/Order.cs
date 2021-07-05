using System;
using System.Collections.Generic;

namespace CinemaAdminApp.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public CinemaAppUser User { get; set; }

        public virtual ICollection<MovieInOrder> Movies { get; set; }
    }
}
