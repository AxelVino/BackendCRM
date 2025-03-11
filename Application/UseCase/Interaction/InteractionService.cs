using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.UseCase.Interaction
{
    public class InteractionService : IInteractionService
    {
        private readonly IInteractionsQuery _query;
        private readonly IInteractionCommand _command;
        private readonly IInteractionTypeServices _interactionTypeService;
        private readonly IInteractionsMapper _interactionMapper;
        private readonly IProjectQuery _projectQuery;
        private readonly IProjectCommand _projectCommand;
        public InteractionService(IInteractionsQuery query, IInteractionCommand command, IInteractionTypeServices interactionTypeService, 
            IInteractionsMapper interactionsMapper, IProjectQuery projectQuery, IProjectCommand projectCommand)
        {
            _query = query;
            _command = command;
            _interactionTypeService = interactionTypeService;
            _interactionMapper = interactionsMapper;
            _projectQuery = projectQuery;
            _projectCommand = projectCommand;
        }

        public async Task<InteractionResponse> CreateInteraction(InteractionsRequest request, Guid projectId)
        {
            var project = await _projectQuery.GetProjectById(projectId);

            CheckInteractionRequest(request, project);

            var newInteraction = new Interactions
            {
                InteractionType = request.InteractionType,
                Notes = request.Notes,
                Date = request.Date,
                ProjectID = project.ProjectID,
                Projects = project,
                InteractionTypes = await _interactionTypeService.GetInteractionType(request.InteractionType)
            };

            project.UpdateDate = DateTime.Now;
            await _projectCommand.UpdateProject(project);

            await _command.CreateInteraction(newInteraction);
            return await _interactionMapper.GetInteractionResponse(newInteraction);      
        }

        public async Task<List<Interactions>> GetInteractionsList(Guid projectId)
        {
            return await _query.GetInteractionsList(projectId);
        }

        // FUNCTION TO CHECK DATA 

        private static bool CheckInteractionRequest(InteractionsRequest interaction, Domain.Entities.Projects project)
        {
            if (project == null)
            {
                throw new ExceptionBadRequest("Incorrect data entered, try again.");
            }
            if (string.IsNullOrWhiteSpace(interaction.Notes))
            {
                throw new ExceptionBadRequest("¡Please, you cannot enter only a space or null!");
            }
            if (interaction.Date < project.StartDate || interaction.Date > project.EndDate)
            {
                throw new ExceptionBadRequest("¡Enter an interaction between the start and end of the project!");
            }

            return true;
        }
    }
}
