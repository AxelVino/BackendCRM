using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InteractionTypesController : ControllerBase
    {
        private readonly IInteractionTypeServices _service;
        public InteractionTypesController(IInteractionTypeServices service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<InteractionTypeResponse>), 200)]
        public async Task<IActionResult> GetInteractionTypeList()
        {
            var result = await _service.GetInteractionTypesList();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
