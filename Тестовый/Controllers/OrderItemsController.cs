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
    public class OrderItemsController
    {
        private readonly IOrderItemService _service;

        public OrderItemsController(IOrderItemService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        async public Task<List<OrderItem>> GetAll()
        {
            var result = await _service.GetAll();
            return result;
        }

        [HttpPost("[action]")]
        async public Task<long> Create([FromBody] OrderItem orderitem)
        {
            var result = await _service.Create(orderitem);
            return result;
        }

        [HttpGet("{id}")]
        async public Task<OrderItem> GetById(int id)
        {
            var result = await _service.GetById(id);
            return result;
        }
    }
}