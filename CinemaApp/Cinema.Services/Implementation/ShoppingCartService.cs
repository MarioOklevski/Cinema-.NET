using Cinema.Domain.DomainModels.Domain;
using Cinema.Domain.DTO;
using Cinema.Repository.Interface;
using Cinema.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Services.Implementation
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IRepository<ShoppingCart> _shoppingCartRepository;
        private readonly IRepository<Order> _orderRepository;
        private readonly IRepository<MovieInOrder> _movieInOrderRepository;
        private readonly IUserRepository _userRepository;

        public ShoppingCartService(IRepository<MovieInOrder> _movieInOrderRepository, IRepository<Order> _orderRepository, IRepository<ShoppingCart> _shoppingCartRepository, IUserRepository _userRepository)
        {
            this._shoppingCartRepository = _shoppingCartRepository;
            this._userRepository = _userRepository;
            this._orderRepository = _orderRepository;
            this._movieInOrderRepository = _movieInOrderRepository;
        }

        ShoppingCartDto IShoppingCartService.GetShoppingCartInfo(string userId)
        {
            var loggedInUser = this._userRepository.Get(userId);

            var userShoppingCart = loggedInUser.UserCart;

            var AllMovies = userShoppingCart.MovieInShoppingCarts.ToList();

            var allMoviePrice = AllMovies.Select(z => new
            {
                ProductPrice = z.Movie.MoviePrice,
                Quanitity = z.Quantity
            }).ToList();

            var totalPrice = 0;


            foreach (var item in allMoviePrice)
            {
                totalPrice += item.Quanitity * item.ProductPrice;
            }


            ShoppingCartDto scDto = new ShoppingCartDto
            {
                MovieInShoppingCarts = AllMovies,
                TotalPrice = totalPrice
            };


            return scDto;
        }

        public bool DeleteMovieFromShoppingCart(string userId, Guid id)
        {
            if (!string.IsNullOrEmpty(userId) && id != null)
            {
                var loggedInUser = this._userRepository.Get(userId);

                var userShoppingCart = loggedInUser.UserCart;

                var itemToDelete = userShoppingCart.MovieInShoppingCarts.Where(z => z.MovieId.Equals(id)).FirstOrDefault();

                userShoppingCart.MovieInShoppingCarts.Remove(itemToDelete);

                this._shoppingCartRepository.Update(userShoppingCart);

                return true;
            }

            return false;
        }

        public bool OrderNow(string userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                //Select * from Users Where Id LIKE userId

                var loggedInUser = this._userRepository.Get(userId);
                var userShoppingCart = loggedInUser.UserCart;

                Order order = new Order
                {
                    Id = Guid.NewGuid(),
                    User = loggedInUser,
                    UserId = userId
                };

                this._orderRepository.Insert(order);

                List<MovieInOrder> movieInOrders = new List<MovieInOrder>();

                var result = userShoppingCart.MovieInShoppingCarts.Select(z => new MovieInOrder
                {
                    Id = Guid.NewGuid(),
                    MovieId = z.Movie.Id,
                    OrderedMovie = z.Movie,
                    OrderId = order.Id,
                    UserOrder = order
                }).ToList();

                movieInOrders.AddRange(result);

                foreach (var item in movieInOrders)
                {
                    this._movieInOrderRepository.Insert(item);
                }

                loggedInUser.UserCart.MovieInShoppingCarts.Clear();

                this._userRepository.Update(loggedInUser);

                return true;
            }
            return false;
        }
    }
}
