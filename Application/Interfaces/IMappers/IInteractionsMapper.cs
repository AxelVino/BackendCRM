using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface IInteractionsMapper
    {
        Task<List<InteractionResponse>> GetAllInteractionsResponse(List<Interactions> interactions);
        Task<InteractionResponse> GetInteractionResponse(Interactions interaction);
    }
}
