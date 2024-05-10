namespace indy_microservice.Models
{
    public class Characteristic
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Boost { get; set; }
        public List<BotPilot> BotPilots { get; set; }
    }
}