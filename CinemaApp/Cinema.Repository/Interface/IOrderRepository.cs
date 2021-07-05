using Cinema.Domain.DomainModels.Domain;
using System.Collections.Generic;

namespace Cinema.Repository.Interface
{
    public interface IOrderRepository
    {
        List<Order> GetAllOrders();
    }
}
