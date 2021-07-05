using System;

namespace Cinema.Domain.DomainModels.Domain
{
    public class MovieInShoppingCart : BaseEntity
    {
        public Guid MovieId { get; set; }
        public Guid ShoppingCartId { get; set; }
        public Movie Movie { get; set; }
        public ShoppingCart ShoppingCart { get; set; }

        public int Quantity { get; set; }
    }
}
