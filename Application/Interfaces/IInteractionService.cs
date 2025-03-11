using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IInteractionService
    {
        Task<List<Interactions>> GetInteractionsList(Guid projectId);
        Task<InteractionResponse> CreateInteraction(InteractionsRequest interaction, Guid projectId);
    }
}
