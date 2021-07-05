using Cinema.Domain.DomainModels.Domain;
using Cinema.Domain.DTO;
using Cinema.Domain.Identity;
using Cinema.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Cinema.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<CinemaAppUser> _userManager;

        public ShoppingCartController(ApplicationDbContext _context, UserManager<CinemaAppUser> _userManager)
        {
            this._context = _context;
            this._userManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var loggedInUser = await _context.Users
                .Where(z => z.Id == userId)
                .Include(z => z.UserCart)
                .Include(z => z.UserCart.MovieInShoppingCarts)
                .Include("UserCart.MovieInShoppingCarts.Movie")
                .FirstOrDefaultAsync();

            var userShoppingCart = loggedInUser.UserCart;

            var moviePrice = userShoppingCart.MovieInShoppingCarts.Select(z => new
            {
                MoviePrice = z.Movie.MoviePrice,
                Quantity = z.Quantity
            }).ToList();

            double totalPrice = 0;

            foreach (var item in moviePrice)
            {
                totalPrice += item.MoviePrice * item.Quantity;
            }

            ShoppingCartDto shoppingCartDto = new ShoppingCartDto
            {
                MovieInShoppingCarts = userShoppingCart.MovieInShoppingCarts.ToList(),
                TotalPrice = totalPrice
            };

            //var AllMovies = userShoppingCart.MovieInShoppingCarts.Select(z => z.Movie).ToList();

            return View(shoppingCartDto);
        }

        public async Task<IActionResult> DeleteMovieFromShoppingCart(Guid movieId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var loggedInUser = await _context.Users
               .Where(z => z.Id == userId)
               .Include(z => z.UserCart)
               .Include(z => z.UserCart.MovieInShoppingCarts)
               .Include("UserCart.MovieInShoppingCarts.Movie")
               .FirstOrDefaultAsync();

            var userShoppingCart = loggedInUser.UserCart;

            var movieToDelete = userShoppingCart.MovieInShoppingCarts.Where(z => z.MovieId.Equals(movieId)).FirstOrDefault();

            userShoppingCart.MovieInShoppingCarts.Remove(movieToDelete);

            _context.Update(userShoppingCart);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "ShoppingCart");
        }

        public async Task<IActionResult> OrderNow()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var loggedInUser = await _context.Users
              .Where(z => z.Id == userId)
              .Include(z => z.UserCart)
              .Include(z => z.UserCart.MovieInShoppingCarts)
              .Include("UserCart.MovieInShoppingCarts.Movie")
              .FirstOrDefaultAsync();

            var userShoppingCart = loggedInUser.UserCart;

            Order order = new Order
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                User = loggedInUser
            };

            _context.Add(order);

            List<MovieInOrder> movieInOrders = new List<MovieInOrder>();

            movieInOrders = userShoppingCart.MovieInShoppingCarts
                .Select(z => new MovieInOrder
                {
                    OrderId = order.Id,
                    MovieId = z.Movie.Id,
                    SelectedMovie = z.Movie,
                    UserOrder = order
                }).ToList();

            foreach (var item in movieInOrders)
            {
                _context.Add(item);
            }

            loggedInUser.UserCart.MovieInShoppingCarts.Clear();

            _context.Users.Update(loggedInUser);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "ShoppingCart");
        }
    }
}
