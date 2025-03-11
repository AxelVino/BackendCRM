using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _services;

        public UserController(IUserServices services) 
        {
            _services = services;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UserResponse>), 200)]
        public async Task<IActionResult> GetUserList()
        {
            var result = await _services.GetUserList();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
