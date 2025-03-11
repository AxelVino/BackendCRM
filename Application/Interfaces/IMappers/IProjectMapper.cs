
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public  interface IProjectMapper
    {
        Task<List<ProjectResponse>> GetAllProjectsResponse(List<Projects> projects);
        Task<ProjectDetails> GetProjectResponse(Projects project);
    }
}
