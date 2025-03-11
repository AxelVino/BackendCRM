using Application.Request;
using Application.Response;

namespace Application.Interfaces
{
    public interface IProjectServices
    {
        Task<List<ProjectResponse>> GetProjectList(string? name, int? campaign, int? client, int? offset, int? size);
        Task<ProjectDetails> CreateProject(ProjectRequest project);
        Task<ProjectDetails> GetProjectByGUID(Guid guid);
    }
}
