using Application.Response;

namespace Application.Interfaces.IMappers
{
    public interface IStatusTaskMapper
    {
        Task<List<TaskStatusResponse>> GetAllStatusTaskResponse(List<Domain.Entities.TaskStatus> statusTask);
        Task<TaskStatusResponse> GetStatusTaskResponse(Domain.Entities.TaskStatus statusTask);
    }
}
