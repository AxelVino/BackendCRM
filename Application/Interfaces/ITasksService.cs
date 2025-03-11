using Application.Request;
using Application.Response;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface ITasksService
    {
        Task<List<Tasks>> GetTasksList(Guid projectId); 
        Task<TasksResponse> CreateTasks(TasksRequest request, Guid projectId);
        Task<TasksResponse> UpdateTasks(TasksRequest request, Guid id);
    }
}
