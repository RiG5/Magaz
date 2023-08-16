using Microsoft.EntityFrameworkCore;
using MyApp.Web.Api.Bussiness.Entities;
using MyApp.Web.Api.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Web.Api.Business.Core
{
    public interface IOrderService
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(int id);
        Task<long> Create(Order order);
    }

    public class OrderService : IOrderService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public OrderService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Task<List<Order>> GetAll()
        {
            throw new NotImplementedException();
        }

        async Task<long> IOrderService.Create(Order order)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Orders.Add(order);
                await context.SaveChangesAsync();
                return order.Id;
            }
        }

        async Task<List<Order>> IOrderService.GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var list = await context.Orders.ToListAsync();
                return list;
            }
        }

        async Task<Order> IOrderService.GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var item = await context.Orders.Where(x => x.Id == id).SingleOrDefaultAsync();
                return item;
            }
        }
    }
}
