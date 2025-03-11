using Application.Interfaces.IMappers;
using Application.Response;

namespace Application.Mappers
{
    public class StatusTaskMapper : IStatusTaskMapper
    {
        public Task<List<TaskStatusResponse>> GetAllStatusTaskResponse(List<Domain.Entities.TaskStatus> statusTask)
        {
            List<TaskStatusResponse> lista = new List<TaskStatusResponse>();
            foreach (var c in statusTask)
            {
                var response = new TaskStatusResponse
                {
                    Id = c.Id,
                    Name = c.Name,
                };
                lista.Add(response);
            }
            return Task.FromResult(lista);
        }

        public Task<TaskStatusResponse> GetStatusTaskResponse(Domain.Entities.TaskStatus statusTask)
        {
            var response = new TaskStatusResponse
            {
                Id = statusTask.Id,
                Name = statusTask.Name,
            };
            return Task.FromResult(response);
        }
    }
}
