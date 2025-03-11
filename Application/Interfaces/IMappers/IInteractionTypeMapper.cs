using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface IInteractionTypeMapper
    {
        Task<List<InteractionTypeResponse>> GetAllInteractionTypesResponse(List<InteractionTypes> interactionTypes);
        Task<InteractionTypeResponse> GetInteractionTypeResponse(InteractionTypes interactionType);
    }
}
