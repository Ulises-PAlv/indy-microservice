using AutoMapper;
using indy_microservice.DTOs.BotPilot;
using indy_microservice.DTOs.Characteristic;
using indy_microservice.DTOs.Tire;

namespace indy_microservice
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<BotPilot, GetBotPilotDTO>();
            CreateMap<AddBotPilotDTO, BotPilot>();
            CreateMap<UpdateBotPilotDTO, BotPilot>();
            CreateMap<Tire, GetTireDTO>();
            CreateMap<Characteristic, GetCharacteristicDTO>();
        }
    }
}