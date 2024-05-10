using System.Text.Json.Serialization;

namespace indy_microservice.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TireType {
        Soft = 1,
        Medium = 2,
        Hard = 3
    }
}