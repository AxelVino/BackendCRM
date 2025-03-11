using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class ProjectMapper : IProjectMapper
    {
        private readonly ICampaignMapper _campaignMapper;
        private readonly IClientsMapper _clientsMapper;
        private readonly ITasksMapper _tasksMapper;
        private readonly IClientsService _serviceClient;
        private readonly ICampaignService _serviceCampaign;
        private readonly IInteractionsMapper _interactionsMapper;
        private readonly IInteractionService _interactionService;
        private readonly ITasksService _taskService;

        public ProjectMapper(ICampaignMapper campaignMapper, IClientsMapper clientsMapper, ITasksMapper mapper,
                             IInteractionsMapper interactionsMapper, ICampaignService campaignService, IClientsService clientsService,
                             IInteractionService interactionService, ITasksService taskService)
        {
            _campaignMapper = campaignMapper;
            _clientsMapper = clientsMapper;
            _tasksMapper = mapper;
            _interactionsMapper = interactionsMapper;
            _serviceClient = clientsService;
            _serviceCampaign = campaignService;
            _interactionService = interactionService;
            _taskService = taskService;
        }
        public async Task<List<ProjectResponse>> GetAllProjectsResponse(List<Projects> projects)
        {
            List<ProjectResponse> lista = new List<ProjectResponse>();
            foreach (var p in projects)
            {
                var response = new ProjectResponse
                {
                    Id = p.ProjectID,
                    Name = p.ProjectName,
                    Start = p.StartDate,
                    End = p.EndDate,
                    Client = await _clientsMapper.GetClientResponse(await _serviceClient.GetClientById(p.ClientID)),
                    CampaignType = await _campaignMapper.GetCampaignResponse(await _serviceCampaign.GetCampaignById(p.CampaignType))
                };
                lista.Add(response);
            }
            return lista;
        }

        public async Task<ProjectDetails> GetProjectResponse(Projects project)
        {
            var response = new ProjectDetails
            {
                Data = new ProjectResponse
                {
                    Id = project.ProjectID,
                    Name = project.ProjectName,
                    Start = project.StartDate,
                    End = project.EndDate,
                    Client = await _clientsMapper.GetClientResponse(await _serviceClient.GetClientById(project.ClientID)),
                    CampaignType = await _campaignMapper.GetCampaignResponse(await _serviceCampaign.GetCampaignById(project.CampaignType)),
                },
                Interaction = await _interactionsMapper.GetAllInteractionsResponse(await _interactionService.GetInteractionsList(project.ProjectID)),
                Tasks = await _tasksMapper.GetAllTasksResponse(await _taskService.GetTasksList(project.ProjectID)),
            };
            return await Task.FromResult(response);
        }
    }
}


