using Microsoft.EntityFrameworkCore;
using MyApp.Web.Api.Bussiness.Entities;
using MyApp.Web.Api.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Web.Api.Business.Core
{
    public interface IClientService
    {
        Task<List<Client>> GetAll();
        Task<Client> GetById(int id);
        Task<long> Create(Client client);
    }

    public class ClientService : IClientService
    {
        private readonly IDbContextFactory<AppDbContext> _contextFactory;

        public ClientService(IDbContextFactory<AppDbContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public Task<List<Client>> GetAll()
        {
            throw new NotImplementedException();
        }

        async Task<long> IClientService.Create(Client client)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Clients.Add(client);
                await context.SaveChangesAsync();
                return client.Id;
            }
        }

        async Task<List<Client>> IClientService.GetAll()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var list = await context.Clients.ToListAsync();
                return list;
            }
        }

        async Task<Client> IClientService.GetById(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var item = await context.Clients.Where(x => x.Id == id).SingleOrDefaultAsync();
                return item;
            }
        }
    }
}
