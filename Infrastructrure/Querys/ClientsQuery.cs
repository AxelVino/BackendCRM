using Application.Interfaces;
using Domain.Entities;
using Infrastructrure.Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Exceptions;
namespace Infrastructrure.Querys
{
    public class ClientsQuery : IClientsQuery
    {
        private readonly CrmDbContext _context;

        public ClientsQuery(CrmDbContext context)
        {
            _context = context;
        }

        public async Task<Clients> GetClient(int idClient)
        {
            return await _context.Clients
                .FirstOrDefaultAsync(s => s.ClientID == idClient);
        }

        public async Task<List<Clients>> GetListClients()
        {
            return await _context.Clients.ToListAsync();
        }
    }
}
