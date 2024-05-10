using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using indy_microservice.DTOs.BotPilot;
using indy_microservice.DTOs.Characteristic;

namespace indy_microservice.Services.BotPilotService
{
    public interface IBotPilotService {
        Task<ServiceResponse<List<GetBotPilotDTO>>> GetAllBotPilots();
        Task<ServiceResponse<GetBotPilotDTO>> GetBotPilotById(int id);
        Task<ServiceResponse<List<GetBotPilotDTO>>> AddBotPilot(AddBotPilotDTO newBot);
        Task<ServiceResponse<GetBotPilotDTO>> UpdateBotPilot(UpdateBotPilotDTO updatedBot, int id);
        Task<ServiceResponse<GetBotPilotDTO>> DeleteBotPilot(int id);
        Task<ServiceResponse<GetBotPilotDTO>> AddCharacteristic(AddBotPilotCharacteristicDTO newCharacteristic);
    }
}