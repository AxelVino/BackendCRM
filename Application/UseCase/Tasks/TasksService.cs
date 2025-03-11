using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.IMappers;
using Application.Request;
using Application.Response;
using Microsoft.VisualBasic;

namespace Application.UseCase.Tasks
{
    public class TasksService : ITasksService
    {
        private readonly ITasksQuery _query;
        private readonly ITasksCommand _command;
        private readonly ITasksMapper _taskMapper;
        private readonly IUserServices _userServices;
        private readonly ITaskStatusServices _taskStatusServices;
        private readonly IProjectQuery _projectQuery;
        private readonly IProjectCommand _projectCommand;
        public  TasksService(ITasksQuery tasksQuery, ITasksCommand command, ITasksMapper tasksMapper,
                            IUserServices userServices, ITaskStatusServices taskStatusServices, 
                            IProjectQuery projectQuery, IProjectCommand projectCommand)
        {
            _query = tasksQuery;
            _command = command;
            _userServices = userServices;
            _taskStatusServices = taskStatusServices;
            _taskMapper = tasksMapper;
            _projectQuery = projectQuery;
            _projectCommand = projectCommand;
        }

        public async Task<TasksResponse> CreateTasks(TasksRequest request, Guid projectId)
        {
            var project = await _projectQuery.GetProjectById(projectId);

            CheckTasksRequestData(request, project);

            var newTask = new Domain.Entities.Tasks
            {
                Name = request.Name,
                DueDate = request.DueDate,
                AssignedTo = request.User,
                Status = request.Status,
                ProjectID = project.ProjectID,
                Projects = project,
                CreateDate = DateTime.Now,
                UpdateDate = DateTime.Now,
                Users = await _userServices.GetUserById(request.User),
                TaskStatus = await _taskStatusServices.GetTaskStatusById(request.Status),
            };

            project.UpdateDate = DateTime.Now;
            await _projectCommand.UpdateProject(project);

            await _command.CreateTask(newTask);
            return await _taskMapper.GetTasksResponse(newTask);
        }

        public async Task<TasksResponse> UpdateTasks(TasksRequest request, Guid id)
        {
            var task = await _query.GetTaskById(id);
            if (task == null)
            {
                throw new ExceptionBadRequest("Incorrect data entered, try again.");
            }

            task.Name = request.Name;
            task.DueDate = request.DueDate;
            task.Users = await _userServices.GetUserById(request.User);
            task.AssignedTo = request.User;
            task.TaskStatus = await _taskStatusServices.GetTaskStatusById(request.Status);
            task.Status = request.Status;
            task.UpdateDate = DateTime.Now;

            Domain.Entities.Projects searchedProject = await _projectQuery.GetProjectByTaskId(id);
            searchedProject.UpdateDate = DateTime.Now;
            await _projectCommand.UpdateProject(searchedProject);

            CheckTasksRequestData(request, searchedProject);

            await _command.UpdateTask(task);
            return await _taskMapper.GetTasksResponse(task);
        }

        public async Task<List<Domain.Entities.Tasks>> GetTasksList(Guid projectId)
        {
            return await _query.GetTasksList(projectId);
        }

        // FUNCTIONS TO CHECK DATA //

        private static bool CheckTasksRequestData(TasksRequest request, Domain.Entities.Projects project)
        {
            if (project == null)
            {
                throw new ExceptionBadRequest("Incorrect data entered, try again.");
            }
            if (string.IsNullOrWhiteSpace(request.Name))
            {
                throw new ExceptionBadRequest("¡Please, you cannot enter only a space or null!");
            }
            if (request.DueDate < project.StartDate || request.DueDate > project.EndDate)
            {
                throw new ExceptionBadRequest("¡Enter an interaction between the start and end of the project!");
            }

            return true;
        }
    }
}
