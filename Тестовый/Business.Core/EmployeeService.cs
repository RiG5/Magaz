using Microsoft.EntityFrameworkCore;
using MyApp.Web.Api.Bussiness.Entities;
using MyApp.Web.Api.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Web.Api.Business.Core
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task <long> Create(Employee employee);
    }

    public class EmployeeService : IEmployeeService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public EmployeeService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        async Task<long> IEmployeeService.Create(Employee employee)
        {
             using (var context = _contextFactory.CreateDbContext())
            {
               context.Employees.Add(employee);
               await context.SaveChangesAsync();
                return employee.Id;
            }
        }

        async Task<List<Employee>> IEmployeeService.GetAll()
        {
            using(var context = _contextFactory.CreateDbContext())
            {
                var list = await context.Employees.ToListAsync();
                return list;
            }
        }

        async Task<Employee> IEmployeeService.GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var item = await context.Employees.Where(x => x.Id == id).SingleOrDefaultAsync();
                return item;
            }
        }
    }
}
