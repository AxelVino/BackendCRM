using Application.Response;
using Domain.Entities;

namespace Application.Interfaces.IMappers
{
    public interface ITasksMapper
    {
        Task<List<TasksResponse>> GetAllTasksResponse(List<Tasks> tasks);
        Task<TasksResponse> GetTasksResponse(Tasks task);
    }
}
