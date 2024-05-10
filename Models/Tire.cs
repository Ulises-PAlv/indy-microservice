namespace indy_microservice.Models
{
    public class Tire
    {
        public int Id { get; set; }
        public TireType Type { get; set; } = TireType.Medium;
        public int Life { get; set; } = 9;
        public int Grip { get; set; } = 20;
        public BotPilot BotPilot { get; set; }
        public int BotPilotId { get; set; }
    }
}