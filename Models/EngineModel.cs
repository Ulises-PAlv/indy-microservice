using System.Text.Json.Serialization;

namespace indy_microservice.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum EngineModel {
        Honda = 1,
        Chevrolet = 2
    }
}