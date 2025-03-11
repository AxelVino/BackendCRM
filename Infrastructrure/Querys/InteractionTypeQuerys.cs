using Application.Interfaces;
using Domain.Entities;
using Infrastructrure.Persistence;
using Microsoft.EntityFrameworkCore;
using Application.Exceptions;

namespace Infrastructrure.Querys
{
    public class InteractionTypeQuerys : IInteractionTypeQuery
    {
        private readonly CrmDbContext _context;
        public InteractionTypeQuerys(CrmDbContext context)
        {
            _context = context;
        }

        public async Task<List<InteractionTypes>> GetInteractionTypesList()
        {
            return await _context.InteractionTypes.ToListAsync();
        }
        public async Task<InteractionTypes> GetInteractionType(int id)
        {
            return await _context.InteractionTypes
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    } 
}
