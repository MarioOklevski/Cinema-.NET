using Cinema.Web.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cinema.Web.Models.DTO
{
    public class AddToShoppingCartDto
    {
        public Movie SelectedMovie { get; set; }
        public Guid MovieId { get; set; }
        public int Quantity { get; set; }
    }
}
