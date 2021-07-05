﻿using Cinema.Domain.DomainModels.Domain;
using Cinema.Domain.DTO;
using Cinema.Repository.Interface;
using Cinema.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Services.Implementation
{
    public class MovieService : IMovieService
    {
        private readonly IRepository<Movie> _movieRepository;
        private readonly IRepository<MovieInShoppingCart> _movieInShoppingCartRepository;
        private readonly IUserRepository _userRepository;

        public MovieService(IRepository<Movie> _movieRepository, IUserRepository _userRepository, IRepository<MovieInShoppingCart> _movieInShoppingCartRepository)
        {
            this._movieRepository = _movieRepository;
            this._userRepository = _userRepository;
            this._movieInShoppingCartRepository = _movieInShoppingCartRepository;
        }

        public bool AddToShoppingCart(AddToShoppingCartDto item, string userID)
        {
            var user = this._userRepository.Get(userID);
            var userShoppingCart = user.UserCart;

            if (item.MovieId != null && userShoppingCart != null)
            {
                var movie = this.GetDetailsForMovie(item.MovieId);

                if (movie != null)
                {
                    MovieInShoppingCart itemToAdd = new MovieInShoppingCart
                    {
                        Id = Guid.NewGuid(),
                        Movie = movie,
                        MovieId = movie.Id,
                        ShoppingCart = userShoppingCart,
                        ShoppingCartId = userShoppingCart.Id,
                        Quantity = item.Quantity
                    };

                    this._movieInShoppingCartRepository.Insert(itemToAdd);
                    return true;
                }
                return false;
            }
            return false;
        }

        public void CreateNewMovie(Movie m)
        {
            this._movieRepository.Insert(m);
        }

        public void DeleteMovie(Guid id)
        {
            var movie = this.GetDetailsForMovie(id);
            this._movieRepository.Delete(movie);
        }

        public List<Movie> GetAllMovies()
        {
            return this._movieRepository.GetAll().ToList();
        }

        public Movie GetDetailsForMovie(Guid? id)
        {
            return this._movieRepository.Get(id);
        }

        public AddToShoppingCartDto GetShoppingCartInfo(Guid? id)
        {
            var movie = this.GetDetailsForMovie(id);
            AddToShoppingCartDto model = new AddToShoppingCartDto
            {
                SelectedMovie = movie,
                MovieId = movie.Id,
                Quantity = 1
            };

            return model;
        }

        public void UpdateExistingMovie(Movie m)
        {
            this._movieRepository.Update(m);
        }
    }
}
