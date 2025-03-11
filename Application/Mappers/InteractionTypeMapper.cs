using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;
using Microsoft.VisualBasic;

namespace Application.Mappers
{
    public class InteractionTypeMapper : IInteractionTypeMapper
    {
        public async Task<List<InteractionTypeResponse>> GetAllInteractionTypesResponse(List<InteractionTypes> interactionTypes)
        {
            List<InteractionTypeResponse> newList = new List<InteractionTypeResponse>();
            foreach (var interaction in interactionTypes)
            {
                var response = new InteractionTypeResponse
                {
                    Id = interaction.Id,
                    Name = interaction.Name,
                };
                newList.Add(response);
            }
            return await Task.FromResult(newList);
        }

        public async Task<InteractionTypeResponse> GetInteractionTypeResponse(InteractionTypes interactionType)
        {
            var response = new InteractionTypeResponse
            {
                Id = interactionType.Id,
                Name = interactionType.Name
            };
            return await Task.FromResult(response);
        }
    }
}
