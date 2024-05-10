using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using indy_microservice.Data;
using indy_microservice.DTOs.BotPilot;
using indy_microservice.DTOs.Tire;
using Microsoft.EntityFrameworkCore;

namespace indy_microservice.Services.TireService
{
    public class TireService : ITireService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TireService(IMapper mapper, DataContext dataContext, IHttpContextAccessor httpContextAccessor)
        {
            _context = dataContext;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserID() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(
            ClaimTypes.NameIdentifier
        ));

        public async Task<ServiceResponse<GetBotPilotDTO>> AddTire(AddTireDTO newTire)
        {
            ServiceResponse<GetBotPilotDTO> response = new ServiceResponse<GetBotPilotDTO>();

            try {
                BotPilot botPilot = await _context.BotPilots.FirstOrDefaultAsync(
                    pilot => pilot.Id == newTire.BotPilotId && pilot.User.Id == GetUserID()
                );

                if(botPilot == null) {
                    response.Success = false;
                    response.Message = "Pilot not found";

                    return response;
                }

                Tire tire = new Tire {
                    Grip = newTire.Grip,
                    Life = newTire.Life,
                    Type = newTire.Type,
                    BotPilot = botPilot
                };

                _context.Tires.Add(tire);
                await _context.SaveChangesAsync();

                response.Data = _mapper.Map<GetBotPilotDTO>(botPilot);
            } catch(Exception e) {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }
    }
}