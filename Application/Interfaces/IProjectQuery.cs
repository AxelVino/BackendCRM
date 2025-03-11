using Domain.Entities;

namespace Application.Interfaces
{
    public interface IProjectQuery
    {
        Task<List<Projects>> GetProjects();
        Task<List<Projects>> GetProjectsList(string? name, int? campaign, int? client, int? offset, int? size);
        Task<Projects> GetProjectById(Guid id);

        Task<Projects> GetProjectByName(string name);
        Task<Projects> GetProjectByTaskId(Guid id);
    }
}