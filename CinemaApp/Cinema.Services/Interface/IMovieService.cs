using Cinema.Domain.DomainModels.Domain;
using Cinema.Domain.DTO;
using System;
using System.Collections.Generic;

namespace Cinema.Services.Interface
{
    public interface IMovieService
    {
        List<Movie> GetAllMovies();
        Movie GetDetailsForMovie(Guid? id);
        void CreateNewMovie(Movie m);
        void UpdateExistingMovie(Movie m);
        AddToShoppingCartDto GetShoppingCartInfo(Guid? id);
        void DeleteMovie(Guid id);
        bool AddToShoppingCart(AddToShoppingCartDto item, string userID);
    }
}
