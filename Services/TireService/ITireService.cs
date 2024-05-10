using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Threading.Tasks;
using indy_microservice.DTOs.BotPilot;
using indy_microservice.DTOs.Tire;

namespace indy_microservice.Services.TireService
{
    public interface ITireService 
    {
        Task<ServiceResponse<GetBotPilotDTO>> AddTire(AddTireDTO newTire);
    }
}