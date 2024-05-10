
using System.Diagnostics;
using System.Reflection;
using System.Security.Claims;
using System.Text.Json;
using AutoMapper;
using indy_microservice.Data;
using indy_microservice.DTOs.BotPilot;
using indy_microservice.DTOs.Characteristic;
using Microsoft.EntityFrameworkCore;

namespace indy_microservice.Services.BotPilotService
{
    public class BotPilotService : IBotPilotService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public BotPilotService(IMapper mapper, DataContext context, IHttpContextAccessor httpContextAccessor) {
            _mapper = mapper;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        private int GetUserID() => int.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(
            ClaimTypes.NameIdentifier
        ));

        public async Task<ServiceResponse<List<GetBotPilotDTO>>> AddBotPilot(AddBotPilotDTO newBot)
        {
            var response = new ServiceResponse<List<GetBotPilotDTO>>();
            BotPilot botPilot = _mapper.Map<BotPilot>(newBot);

            botPilot.User = await _context.Users.FirstOrDefaultAsync(user => user.Id == GetUserID());

            _context.BotPilots.Add(botPilot);
            await _context.SaveChangesAsync();

            response.Data = await _context.BotPilots.Where(
                pilot => pilot.User.Id == GetUserID()
            ).Select(
                pilot => _mapper.Map<GetBotPilotDTO>(pilot)
            ).ToListAsync();

            return response;
        }

        public async Task<ServiceResponse<GetBotPilotDTO>> DeleteBotPilot(int id)
        {
            ServiceResponse<GetBotPilotDTO> response = new ServiceResponse<GetBotPilotDTO>();

            try {
                BotPilot botPilot = await _context.BotPilots.FirstOrDefaultAsync(
                    pilot => pilot.Id == id && pilot.User.Id == GetUserID()
                );

                if (botPilot != null) {
                    response.Data = _mapper.Map<GetBotPilotDTO>(botPilot);
                    _context.BotPilots.Remove(botPilot);

                    await _context.SaveChangesAsync();
                    response.Message = "The pilot has been eliminated";
                } else {
                    response.Success = false;
                    response.Message = "Pilot not found";
                }
                
            } catch (Exception e) {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }


        public async Task<ServiceResponse<List<GetBotPilotDTO>>> GetAllBotPilots()
        {
            var response = new ServiceResponse<List<GetBotPilotDTO>>();
            List<BotPilot> botPilots = await _context.BotPilots.Include(
                    pilot => pilot.Tire
                ).Include(
                    pilot =>  pilot.Characteristics
                ).Where(pilot => pilot.User.Id == GetUserID()).ToListAsync();

            response.Data = botPilots.Select(pilot => _mapper.Map<GetBotPilotDTO>(pilot)).ToList();

            return response;
        }

        public async Task<ServiceResponse<GetBotPilotDTO>> GetBotPilotById(int id)
        {
            var response = new ServiceResponse<GetBotPilotDTO>();
            var botPilot = await _context.BotPilots.Include(
                    pilot => pilot.Tire
                ).Include(
                    pilot =>  pilot.Characteristics
                ).FirstOrDefaultAsync(
                pilot => pilot.Id == id && pilot.User.Id == GetUserID()
            );

            if (botPilot != null) {
                response.Data = _mapper.Map<GetBotPilotDTO>(botPilot);
            } else {
                response.Success = false;
                response.Message = "Pilot not found";
            }
            
            return response;
        }

        public async Task<ServiceResponse<GetBotPilotDTO>> UpdateBotPilot(UpdateBotPilotDTO updatedBot, int id)
        {
            ServiceResponse<GetBotPilotDTO> response = new ServiceResponse<GetBotPilotDTO>();

            try {
                var botPilot = await _context.BotPilots.FirstOrDefaultAsync(
                    pilot => pilot.Id == id && pilot.User.Id == GetUserID()
                );

                if(botPilot != null) {
                    botPilot.Name = updatedBot.Name;
                    botPilot.Downforce = updatedBot.Downforce;
                    botPilot.Luck = updatedBot.Luck;
                    botPilot.Skill = updatedBot.Skill;
                    botPilot.Model = updatedBot.Model;

                    /*
                    if(updatedBot != null) {
                        Type t = typeof(UpdateBotPilotDTO);
                        PropertyInfo[] propInfos = t.GetProperties();

                        foreach(var item in propInfos) {
                            var fieldValue = item.GetValue(updatedBot);

                            if (fieldValue != null)
                            {
                                item.SetValue(botPilot, fieldValue);
                            }
                        }
                    }
                    */

                    await _context.SaveChangesAsync();
                    response.Data = _mapper.Map<GetBotPilotDTO>(botPilot);
                } else {
                    response.Success = false;
                    response.Message = "Pilot not found";
                }
            } catch (Exception e) {
                response.Success = false;
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<GetBotPilotDTO>> AddCharacteristic(AddBotPilotCharacteristicDTO newCharacteristic)
        {
            var response = new ServiceResponse<GetBotPilotDTO>();

            try {
                var botPilot = await _context.BotPilots.Include(
                    pilot => pilot.Tire
                ).Include(
                    pilot =>  pilot.Characteristics
                ).FirstOrDefaultAsync(
                    pilot => pilot.Id == newCharacteristic.BotPilotId && pilot.User.Id == GetUserID()
                );

                if(botPilot == null) {
                    response.Success = false;
                    response.Message = "Pilot not found";

                    return response;
                }

                var characteristic = await _context.Characteristics.FirstOrDefaultAsync(
                    c => c.Id == newCharacteristic.CharacteristicId
                );

                if(characteristic == null) {
                    response.Success = false;
                    response.Message = "Characteristic not found";

                    return response;
                }

                botPilot.Characteristics.Add(characteristic);
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