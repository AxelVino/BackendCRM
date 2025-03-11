using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.UseCase.InteractionType
{
    public class InteractionTypeServices : IInteractionTypeServices
    {
        private readonly IInteractionTypeQuery _query;
        private readonly IInteractionTypeMapper _mapper;
        public InteractionTypeServices(IInteractionTypeQuery query, IInteractionTypeMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<InteractionTypes> GetInteractionType(int id)
        {
            var interactionType = await _query.GetInteractionType(id);
            if (interactionType == null)
            {
                throw new ExceptionBadRequest("Incorrect data entered, try again.");
            }
            return interactionType;
        }

        public async Task<List<InteractionTypeResponse>> GetInteractionTypesList()
        {
            return await _mapper.GetAllInteractionTypesResponse(await _query.GetInteractionTypesList());
        }

    }
}
