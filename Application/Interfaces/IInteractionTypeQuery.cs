using Domain.Entities;

namespace Application.Interfaces
{
    public interface IInteractionTypeQuery
    {
        Task<List<InteractionTypes>> GetInteractionTypesList();
        Task<InteractionTypes> GetInteractionType(int id);
    }
}
