using Cinema.Domain.DomainModels.Domain;
using System.Collections.Generic;

namespace Cinema.Services.Interface
{
    public interface IOrderService
    {
        List<Order> GetAllOrders();
    }
}
