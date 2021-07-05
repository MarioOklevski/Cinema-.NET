using Cinema.Domain.DomainModels.Domain;
using System.Collections.Generic;

namespace Cinema.Domain.DTO
{
    public class ShoppingCartDto
    {
        public List<MovieInShoppingCart> MovieInShoppingCarts { get; set; }
        public double TotalPrice { get; set; }
    }
}
