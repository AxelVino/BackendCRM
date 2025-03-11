using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaskStatusController : ControllerBase
    {
        private readonly ITaskStatusServices _services;
        public TaskStatusController(ITaskStatusServices service)
        {
            _services = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<TaskStatusResponse>), 200)]
        public async Task<IActionResult> GetTaskStatusList()
        {
            var result = await _services.GetTaskStatusList();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
