namespace indy_microservice.DTOs.Tire
{
    public class GetTireDTO
    {
        public TireType Type { get; set; } = TireType.Medium;
        public int Life { get; set; } = 9;
        public int Grip { get; set; } = 20;
    }
}