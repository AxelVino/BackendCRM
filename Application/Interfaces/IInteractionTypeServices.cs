using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IInteractionTypeServices
    {
        Task<List<InteractionTypeResponse>> GetInteractionTypesList();
        Task <InteractionTypes> GetInteractionType(int id);
    }
}
