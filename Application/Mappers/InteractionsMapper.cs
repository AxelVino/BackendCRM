using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class InteractionsMapper : IInteractionsMapper
    {
        private readonly IInteractionTypeMapper _interactionTypeMapper;
        public InteractionsMapper(IInteractionTypeMapper interactionTypeMapper)
        {
            _interactionTypeMapper = interactionTypeMapper;
        }
        public async Task<List<InteractionResponse>> GetAllInteractionsResponse(List<Interactions> interactions)
        {
            List<InteractionResponse> lista = new List<InteractionResponse>();
            foreach (var t in interactions)
            {
                var response = new InteractionResponse
                {
                    Id = t.InteractionID,
                    Notes = t.Notes,
                    Date = t.Date,
                    ProjectId = t.ProjectID,
                    InteractionType = await _interactionTypeMapper.GetInteractionTypeResponse(t.InteractionTypes)
                };
                lista.Add(response);
            }
            return await Task.FromResult(lista);
        }

        public async Task<InteractionResponse> GetInteractionResponse(Interactions interaction)
        {
            var response = new InteractionResponse
            {
                Id  = interaction.InteractionID,
                Notes = interaction.Notes,
                Date = interaction.Date,
                ProjectId = interaction.ProjectID,
                InteractionType = await _interactionTypeMapper.GetInteractionTypeResponse(interaction.InteractionTypes)
            };
            return await Task.FromResult(response);
        }
    }
}
