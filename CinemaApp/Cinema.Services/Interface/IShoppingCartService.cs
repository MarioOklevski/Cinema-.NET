using Cinema.Domain.DTO;
using System;

namespace Cinema.Services.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDto GetShoppingCartInfo(string userId);

        bool DeleteMovieFromShoppingCart(string userId, Guid id);
        bool OrderNow(string userId);
    }
}
