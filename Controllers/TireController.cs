using indy_microservice.DTOs.BotPilot;
using indy_microservice.DTOs.Tire;
using indy_microservice.Services.TireService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace indy_microservice.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TireController : ControllerBase
    {
        private readonly ITireService _tireService;
        
        public TireController(ITireService tireService)
        {
            _tireService = tireService;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetBotPilotDTO>>> AddTire(AddTireDTO newTire) {
            return Ok(await _tireService.AddTire(newTire));
        }
    }
}