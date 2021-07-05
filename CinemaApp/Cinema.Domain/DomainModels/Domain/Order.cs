using Cinema.Domain.Identity;
using System.Collections.Generic;

namespace Cinema.Domain.DomainModels.Domain
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public CinemaAppUser User { get; set; }

        public virtual ICollection<MovieInOrder> Movies { get; set; }
    }
}
