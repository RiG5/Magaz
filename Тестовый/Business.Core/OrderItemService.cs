using Microsoft.EntityFrameworkCore;
using MyApp.Web.Api.Bussiness.Entities;
using MyApp.Web.Api.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Web.Api.Business.Core
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetAll();
        Task<OrderItem> GetById(int id);
        Task<long> Create(OrderItem orderitem);
    }

    public class OrderItemService : IOrderItemService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public OrderItemService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Task<List<OrderItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        async Task<long> IOrderItemService.Create(OrderItem orderitem)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.OrderItems.Add(orderitem);
                await context.SaveChangesAsync();
                return orderitem.Id;
            }
        }

        async Task<List<OrderItem>> IOrderItemService.GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var list = await context.OrderItems.ToListAsync();
                return list;
            }
        }

        async Task<OrderItem> IOrderItemService.GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var item = await context.OrderItems.Where(x => x.Id == id).SingleOrDefaultAsync();
                return item;
            }
        }
    }
}