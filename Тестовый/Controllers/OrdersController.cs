using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyApp.Web.Api.Business.Core;
using MyApp.Web.Api.Bussiness.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyApp.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController
    {
        private readonly IOrderService _service;

        public OrdersController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        async public Task<List<Order>> GetAll()
        {
            var result = await _service.GetAll();
            return result;
        }

        [HttpPost("[action]")]
        async public Task<long> Create([FromBody] Order order)
        {
            var result = await _service.Create(order);
            return result;
        }

        [HttpGet("{id}")]
        async public Task<Order> GetById(int id)
        {
            var result = await _service.GetById(id);
            return result;
        }
    }
}
