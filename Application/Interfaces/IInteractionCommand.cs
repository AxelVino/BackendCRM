using Domain.Entities;

namespace Application.Interfaces
{
    public interface IInteractionCommand
    {
        Task CreateInteraction(Interactions interaction);
    }
}
