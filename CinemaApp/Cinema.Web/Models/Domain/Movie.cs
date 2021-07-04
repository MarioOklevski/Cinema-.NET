using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.Domain
{
    public class Movie
    {
        public Guid Id { get; set; }
        [Required]
        public string MovieName { get; set; }
        [Required]
        public string MovieImage { get; set; }
        [Required]
        public string MovieDescriprtion { get; set; }
        [Required]
        public int MoviePrice { get; set; }
        [Required]
        public int Rating { get; set; }
        public virtual ICollection<MovieInShoppingCart> MovieInShoppingCarts { get; set; }
        public virtual ICollection<MovieInOrder> Orders { get; set; }
    }
}
