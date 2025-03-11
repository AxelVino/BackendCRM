using Application.Interfaces;
using Domain.Entities;
using Infrastructrure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructrure.Querys
{
    public class InteractionsQuery : IInteractionsQuery
    {
        private readonly CrmDbContext _context;
        public InteractionsQuery(CrmDbContext context) 
        { 
            _context = context;
        }
        public async Task<List<Interactions>> GetInteractionsList(Guid projectid)
        {
            return await _context.Interactions
                .Include(p => p.InteractionTypes)
                .Where(p => p.ProjectID == projectid).ToListAsync();
        }
    }
}
