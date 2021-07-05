using Cinema.Domain.Identity;
using System.Collections.Generic;

namespace Cinema.Domain.DomainModels.Domain
{
    public class ShoppingCart : BaseEntity
    {
        public CinemaAppUser Owner { get; set; }
        public string OwnerId { get; set; }

        public virtual ICollection<MovieInShoppingCart> MovieInShoppingCarts { get; set; }
    }
}
