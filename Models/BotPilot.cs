namespace indy_microservice.Models
{
    public class BotPilot
    {
        public int Id { get; set; }
        public string Name { get; set; } = String.Empty;
        public int Skill { get; set; } = 0;
        public int Downforce { get; set; } = 0;
        public int Luck { get; set; } = 0;
        public EngineModel Model { get; set; } = EngineModel.Chevrolet;
        public User? User { get; set; }
        public Tire Tire { get; set; }
        public List<Characteristic> Characteristics { get; set; }
        public int Racing { get; set; }
        public int Podiums { get; set; }
        public int Wins { get; set; }
    }
}