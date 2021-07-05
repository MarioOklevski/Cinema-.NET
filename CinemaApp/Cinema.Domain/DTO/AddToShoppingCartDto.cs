using Cinema.Domain.DomainModels.Domain;
using System;

namespace Cinema.Domain.DTO
{
    public class AddToShoppingCartDto
    {
        public Movie SelectedMovie { get; set; }
        public Guid MovieId { get; set; }
        public int Quantity { get; set; }
    }
}
