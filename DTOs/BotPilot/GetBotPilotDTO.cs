using indy_microservice.DTOs.Tire;

namespace indy_microservice.DTOs.BotPilot
{
    public class GetBotPilotDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = "Bot";
        public int Skill { get; set; } = 70;
        public int Downforce { get; set; } = 50;
        public int Luck { get; set; } = 5;
        public EngineModel Model { get; set; } = EngineModel.Chevrolet;
        public GetTireDTO Tire { get; set; }
    }
}