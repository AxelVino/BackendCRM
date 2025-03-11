using Application.Interfaces;
using Application.Response;
using Microsoft.AspNetCore.Mvc;

namespace Template.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CampaignTypeController : ControllerBase
    {
        private readonly ICampaignService _services;
        public CampaignTypeController(ICampaignService service)
        {
            _services = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CampaignResponse>), 200)]
        public async Task<IActionResult> GetCampaignList()
        {
            var result = await _services.GetCampaignList();
            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}
