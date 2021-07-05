using Cinema.Domain.Identity;
using Cinema.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cinema.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<CinemaAppUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<CinemaAppUser>();
        }
        public IEnumerable<CinemaAppUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public CinemaAppUser Get(string id)
        {
            return entities
               .Include(z => z.UserCart)
               .Include("UserCart.MovieInShoppingCarts")
               .Include("UserCart.MovieInShoppingCarts.Movie")
               .SingleOrDefault(s => s.Id == id);
        }
        public void Insert(CinemaAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(CinemaAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Update(entity);
            context.SaveChanges();
        }

        public void Delete(CinemaAppUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
