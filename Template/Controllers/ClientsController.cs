using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientsService _services;

        public ClientController(IClientsService service)
        {
            _services = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ClientResponse>), 200)]
        public async Task<IActionResult> GetClients()
        {
            var result = await _services.GetClients();
            return new JsonResult(result) { StatusCode = 200 };
        }

        [HttpPost]
        [ProducesResponseType(typeof(ClientResponse), 201)]
        [ProducesResponseType(typeof(ApiError), 400)]
        public async Task<IActionResult> CreateClient(ClientsRequest request)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new ApiError { Message = "Invalid data entered" }) { StatusCode = 400 };
            }
            try
            {
                var result = await _services.CreateClient(request);
                return Created($"api/v1/Client", result);
            }
            catch (ExceptionBadRequest ex)
            {
                return new JsonResult(new ApiError { Message = ex.Message }) { StatusCode = 400 };
            }         
        } 
    }
}
