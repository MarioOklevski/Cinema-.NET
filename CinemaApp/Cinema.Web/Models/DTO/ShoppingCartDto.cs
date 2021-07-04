using Cinema.Web.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.DTO
{
    public class ShoppingCartDto
    {
        public List<MovieInShoppingCart> MovieInShoppingCarts { get; set; }
        public double TotalPrice { get; set; }
    }
}
