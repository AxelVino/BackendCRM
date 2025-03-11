using Application.Interfaces;
using Domain.Entities;
using Infrastructrure.Persistence;

namespace Infrastructrure.Command
{
    public class ClientsCommand: IClientsCommand
    {
        private readonly CrmDbContext _context;

        public ClientsCommand(CrmDbContext context)
        {
            _context = context;
        }

        public async Task InsertClients(Clients clients) 
        {
            _context.Add(clients);
            await _context.SaveChangesAsync();
        }
    }
}
