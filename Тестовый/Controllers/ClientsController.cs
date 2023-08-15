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
    public class ClientsController
    {
        private readonly IClientService _service;

        public ClientsController(IClientService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        async public Task<List<Client>> GetAll()
        {
            var result = await _service.GetAll();
            return result;
        }

        [HttpPost("[action]")]
        async public Task<long> Create([FromBody] Client client)
        {
            var result = await _service.Create(client);
            return result;
        }

        [HttpGet("{id}")]
        async public Task<Client> GetById(int id)
        {
            var result = await _service.GetById(id);
            return result;
        }
    }
}
