using Cinema.Web.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.Domain
{
    public class ShoppingCart
    {
        public Guid Id { get; set; }
        public CinemaAppUser Owner { get; set; }
        public string OwnerId { get; set; }

        public virtual ICollection<MovieInShoppingCart> MovieInShoppingCarts { get; set; }
    }
}
