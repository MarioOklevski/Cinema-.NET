using Cinema.Domain.DomainModels.Domain;
using Cinema.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Cinema.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public AdminController(IOrderService _orderService)
        {
            this._orderService = _orderService;
        }

        [HttpGet("[action]")]
        public List<Order> GetAllActiveOrders()
        {
            return this._orderService.GetAllOrders();
        }
    }
}
