using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using indy_microservice.DTOs.BotPilot;
using indy_microservice.Services.BotPilotService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace indy_microservice.Controllers 
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class BotPilotController : ControllerBase {
        private readonly IBotPilotService _botPilotService;

        public BotPilotController(IBotPilotService botPilotService) {
            _botPilotService = botPilotService;
        }

        // ?? [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetBotPilotDTO>>>> GetAll() {
            return Ok(await _botPilotService.GetAllBotPilots());
        }

        [HttpGet("{id}")] 
        public async Task<ActionResult<ServiceResponse<GetBotPilotDTO>>> GetSingle(int id) {
            return Ok(await _botPilotService.GetBotPilotById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetBotPilotDTO>>>> AddPilot(AddBotPilotDTO newPilot) {
            return Ok(await _botPilotService.AddBotPilot(newPilot));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetBotPilotDTO>>> UpdatePilot(UpdateBotPilotDTO updatedPilot, int id) {
            var response = await _botPilotService.UpdateBotPilot(updatedPilot, id);

            if(response.Data == null) return NotFound(response);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetBotPilotDTO>>> DeletePilot(int id) {
            var response = await _botPilotService.DeleteBotPilot(id);

            if(response.Data == null) return NotFound(response);
            return Ok(response);
        }

        [HttpPost("characteristic")]
        public async Task<ActionResult<ServiceResponse<GetBotPilotDTO>>> AddCharacteristicToPilot(AddBotPilotCharacteristicDTO newCharacteristic) {
            return Ok(await _botPilotService.AddCharacteristic(newCharacteristic));
        }
    }
}