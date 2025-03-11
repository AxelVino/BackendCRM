using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Response;

namespace Application.UseCase.TaskStatus
{
    public class TaskStatusServices : ITaskStatusServices
    {
        private readonly ITaskStatusQuerys _query;
        private readonly IStatusTaskMapper _mapper;
        public TaskStatusServices(ITaskStatusQuerys query, IStatusTaskMapper mapper)
        {
            _query = query;
            _mapper = mapper;
        }

        public async Task<Domain.Entities.TaskStatus> GetTaskStatusById(int statusId)
        {
            var taskStatus = await _query.GetTaskStatusById(statusId);
            if (taskStatus == null)
            {
                throw new ExceptionBadRequest("Incorrect data entered, try again.");
            }
            return taskStatus;
        }

        public async Task<List<TaskStatusResponse>> GetTaskStatusList()
        {
            return await _mapper.GetAllStatusTaskResponse(await _query.GetTaskStatusList());
        }
    }
}
