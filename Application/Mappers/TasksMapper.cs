using Application.Interfaces.IMappers;
using Application.Response;
using Domain.Entities;

namespace Application.Mappers
{
    public class TasksMapper : ITasksMapper
    {
        private readonly IStatusTaskMapper _statusTaskMapper;
        private readonly IUsersMapper _usersMapper;

        public TasksMapper(IStatusTaskMapper statusTaskMapper, IUsersMapper usersMapper)
        {
            _statusTaskMapper = statusTaskMapper;
            _usersMapper = usersMapper;
        }
        public async Task<List<TasksResponse>> GetAllTasksResponse(List<Tasks> task)
        {
            List<TasksResponse> lista = new List<TasksResponse>();
            foreach (var t in task)
            {
                var response = new TasksResponse
                {
                    Id = t.TaskID,
                    Name  = t.Name,
                    DueDate = t.DueDate,
                    ProjectId =  t.ProjectID,
                    Status = await _statusTaskMapper.GetStatusTaskResponse(t.TaskStatus),
                    UserAssigned =  await _usersMapper.GetUserResponse(t.Users),
                };
                lista.Add(response);
            }
            return await Task.FromResult(lista);
        }
        public async Task<TasksResponse> GetTasksResponse(Tasks task)
        {
            var response = new TasksResponse 
            { 
                Id = task.TaskID,
                Name = task.Name,
                DueDate = task.DueDate,
                ProjectId = task.ProjectID,
                Status = await _statusTaskMapper.GetStatusTaskResponse(task.TaskStatus),
                UserAssigned = await _usersMapper.GetUserResponse(task.Users),
            };
            return await Task.FromResult(response);
        }
    }
}
