using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cinema.Domain.DomainModels.Domain
{
    public class Movie : BaseEntity
    {
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
