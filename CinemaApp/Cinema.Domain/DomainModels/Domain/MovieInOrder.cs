using System;

namespace Cinema.Domain.DomainModels.Domain
{
    public class MovieInOrder : BaseEntity
    {
        public Guid MovieId { get; set; }
        public Movie SelectedMovie { get; set; }
        public Guid OrderId { get; set; }
        public Order UserOrder { get; set; }
    }
}
