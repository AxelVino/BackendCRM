using Application.Interfaces;
using Domain.Entities;
using Infrastructrure.Persistence;

namespace Infrastructrure.Command
{
    public class InteractionCommand : IInteractionCommand
    {
        private readonly CrmDbContext _context;
        public InteractionCommand(CrmDbContext context)
        {
            _context = context;
        }
        public async Task CreateInteraction(Interactions interaction)
        {
            _context.Add(interaction);
            await _context.SaveChangesAsync();
        }
    }
}
