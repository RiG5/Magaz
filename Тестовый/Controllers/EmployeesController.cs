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
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController
    {
        private readonly IEmployeeService _service;

        public EmployeesController(IEmployeeService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        async public Task<List<Employee>> GetAll()
        {
            var result = await _service.GetAll();
            return result;
        }
        
        [HttpPost("[action]")]
        async public Task<long> Create([FromBody]Employee employee)
        {
            var result = await _service.Create(employee);
            return result;
        }

        [HttpGet("{id}")]
        async public Task<Employee> GetById(int id)
        {
            var result = await _service.GetById(id);
            return result;
        }
    }
}
