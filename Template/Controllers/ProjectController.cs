using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;

namespace CrmAPI.Controllers
{
    [Route("api/v1/")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectServices _projectService;
        private readonly IInteractionService _interactionService;
        private readonly ITasksService _tasksService;

        public ProjectController(IProjectServices service, IInteractionService interactionService, ITasksService tasksService)
        {
            _projectService = service;
            _interactionService = interactionService;
            _tasksService = tasksService;
        }

        [HttpGet("Project")]
        [ProducesResponseType(typeof(List<ProjectResponse>), 200)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> GetProjects(string? name, int? campaign, int? client, int? offset, int? size)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new ApiError { Message = "Invalid data entered" }) { StatusCode = 400 };
            }
            try
            {
                var result = await _projectService.GetProjectList(name, campaign, client, offset, size);

                return Ok(result);
            }
            catch (ExceptionBadRequest ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPost("Project")]
        [ProducesResponseType(typeof(ProjectDetails), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> CreateProjects(ProjectRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new ApiError { Message = "Invalid data entered" }) { StatusCode = 400 };
            }
            try
            {
                var result = await _projectService.CreateProject(request);
                return Created($"api/v1/Project", result);
            }
            catch (ExceptionBadRequest ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }

        }

        [HttpGet("Project/{id}")]
        [ProducesResponseType(typeof(ProjectDetails), 200)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> GetProjectByGUID(Guid id)
        {
            try
            {
                var result = await _projectService.GetProjectByGUID(id);
                return Ok(result);
            }
            catch (ExceptionBadRequest ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPatch("Project/{id}/Interactions")]
        [ProducesResponseType(typeof(InteractionResponse), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> CreateInteraction(Guid id, InteractionsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new ApiError { Message = "Invalid data entered" }) { StatusCode = 400 };
            }
            try
            {
                var result = await _interactionService.CreateInteraction(request, id);
                return Created($"api/v1/Project/{id}/Interactions", result);
            }
            catch (ExceptionBadRequest ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }

        }

        [HttpPatch("Project/{id}/Tasks")]
        [ProducesResponseType(typeof(TasksResponse), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> AddTasks(Guid id, TasksRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new ApiError { Message = "Invalid data entered" }) { StatusCode = 400 };
            }
            try
            {
                var result = await _tasksService.CreateTasks(request, id);
                return Created($"api/v1/Project/{id}/Tasks", result);
            }
            catch (ExceptionBadRequest ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }

        [HttpPut("Tasks/{id}")]
        [ProducesResponseType(typeof(TasksResponse), 200)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> UpdateTask(Guid id, TasksRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new ApiError { Message = "Invalid data entered" }) { StatusCode = 400 };
            }
            try
            {
                var result = await _tasksService.UpdateTasks(request, id);
                return Ok(result);
            }
            catch (ExceptionBadRequest ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }
        }
    }
}
