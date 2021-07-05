using Cinema.Domain.DomainModels.Domain;
using Cinema.Repository.Interface;
using Cinema.Services.Interface;
using System.Collections.Generic;

namespace Cinema.Services.Implementation
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository _orderRepository)
        {
            this._orderRepository = _orderRepository;
        }
        public List<Order> GetAllOrders()
        {
            return this._orderRepository.GetAllOrders();
        }
    }
}
