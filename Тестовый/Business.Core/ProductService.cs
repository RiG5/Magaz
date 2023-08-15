using Microsoft.EntityFrameworkCore;
using MyApp.Web.Api.Bussiness.Entities;
using MyApp.Web.Api.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Web.Api.Business.Core
{
    public interface IProductService
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<long> Create(Product product);
    }

    public class ProductService : IProductService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ProductService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Task<List<Product>> GetAll()
        {
            throw new NotImplementedException();
        }

        async Task<long> IProductService.Create(Product product)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Products.Add(product);
                await context.SaveChangesAsync();
                return product.Id;
            }
        }

        async Task<List<Product>> IProductService.GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var list = await context.Products.ToListAsync();
                return list;
            }
        }

        async Task<Product> IProductService.GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var item = await context.Products.Where(x => x.Id == id).SingleOrDefaultAsync();
                return item;
            }
        }
    }
}
