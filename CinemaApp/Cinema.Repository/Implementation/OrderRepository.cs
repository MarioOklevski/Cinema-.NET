using Cinema.Domain.DomainModels.Domain;
using Cinema.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Cinema.Repository.Implementation
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Order> entities;
        string errorMessage = string.Empty;

        public OrderRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<Order>();
        }
        public List<Order> GetAllOrders()
        {
            return entities
                .Include(z => z.Movies)
                .Include(z => z.User)
                .Include("Movies.SelectedMovie")
                .ToListAsync().Result;
        }
    }
}
