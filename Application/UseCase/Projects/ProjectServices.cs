using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Request;
using Application.Response;
using Domain.Entities;
using System.Text.RegularExpressions;
using System.Xml.Schema;

namespace Application.UseCase.Projects
{
    public class ProjectServices : IProjectServices
    {
        private readonly IProjectQuery _query;
        private readonly IProjectCommand _command;
        private readonly IProjectMapper _projectMapper;
        private readonly IClientsService _clientsService;
        private readonly ICampaignService _campaignService;

        public ProjectServices(IProjectQuery query, IProjectMapper projectMapper,
                               IProjectCommand command, IClientsService clientsService,
                               ICampaignService campaignService)
        {
            _query = query;
            _projectMapper = projectMapper;
            _command = command;
            _clientsService = clientsService;
            _campaignService = campaignService;
        }

        public async Task<ProjectDetails> CreateProject(ProjectRequest project)
        {
            var projectSearched = await _query.GetProjectByName(project.Name);

            if (projectSearched != null) 
            {
                throw new ExceptionBadRequest("Incorrect data entered, try again.");
            }

            CheckDataProjectRequest(project);
            var newProject = new Domain.Entities.Projects
            {
                ProjectName = project.Name,
                StartDate = project.Start,
                EndDate = project.End,
                ClientID = project.Client,
                CampaignType = project.CampaignType,
                UpdateDate = DateTime.Now,
                Tasks = new List<Domain.Entities.Tasks>(),
                Interactions = new List<Interactions>(),
                CreateDate = DateTime.Now,
                Clients = await _clientsService.GetClientById(project.Client),
                CampaignTypes = await _campaignService.GetCampaignById(project.CampaignType)
            };
            await _command.InsertProject(newProject);
            return await _projectMapper.GetProjectResponse(newProject);
        }
        public async Task<List<ProjectResponse>> GetProjectList(string? name, int? campaign, int? client, int? offset, int? size)
        {
            CheckDataGetProject(name, campaign, client, offset, size);
            var query = await _query.GetProjectsList(name, campaign, client, offset, size);

            return await _projectMapper.GetAllProjectsResponse(query);
        }

        public async Task<ProjectDetails> GetProjectByGUID(Guid guid)
        {
            var project = await _query.GetProjectById(guid);

            if (project == null)
            {
                throw new ExceptionBadRequest("Incorrect data entered, try again");
            }
            return await _projectMapper.GetProjectResponse(project);
        }

        // FUNCTIONS TO CHECK AND VALIDATE PROJECT DATA //

        private static bool CheckDataProjectRequest(ProjectRequest project)
        {

            if (project.Name == null)
            {
                throw new ExceptionBadRequest("Incorrect data entered, try again");
            }
            if (project.Start.Date < DateTime.Now.Date || project.Start >= project.End)
            {
                throw new ExceptionBadRequest("Incorrect data entered, try again");
            }
            if (project.End.Date < DateTime.Now.Date || project.End <= project.Start)
            {
                throw new ExceptionBadRequest("Incorrect data entered, try again");
            }
            return true;
        }

        private static bool CheckDataGetProject(string? name, int? campaign, int? client, int? offset, int? size)
        {
            string pattern = @"[!@#$%^&*(),.?""{}|<>~`_=+\[\]\\\/]";
            if (!string.IsNullOrWhiteSpace(name))
            {
                if (Regex.IsMatch(name, pattern))
                {
                    throw new ExceptionBadRequest("¡Please, you cannot enter a special characters!");
                }
            }
            if(campaign < 0 || client <= 0 || offset < 0 || size < 0)
            {
                throw new ExceptionBadRequest("¡Please, you cannot a negative number or 0!");
            }
            return true;
        }
    }
}
