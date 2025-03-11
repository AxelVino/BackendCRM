using Application.Response;

namespace Application.Interfaces
{
    public interface ITaskStatusServices
    {
        Task<List<TaskStatusResponse>> GetTaskStatusList();
        Task<Domain.Entities.TaskStatus> GetTaskStatusById(int statusId);
    }
}
