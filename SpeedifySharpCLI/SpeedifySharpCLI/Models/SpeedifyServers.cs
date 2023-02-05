using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpeedifySharpCLI.Models;

public class SpeedifyServers
{
    public static SpeedifyServers Parse(string json)
    {
        return JsonSerializer.Deserialize<SpeedifyServers>(json)!;
    }

    [JsonPropertyName("private")]
    public List<SpeedifyServer> Private { get; set; } = new();

    [JsonPropertyName("public")]
    public List<SpeedifyServer> Public { get; set; } = new();

    public class SpeedifyServer
    {
        [JsonPropertyName("city")]
        public string City { get; set; } = string.Empty;

        [JsonPropertyName("country")]
        public string Country { get; set; } = string.Empty;

        [JsonPropertyName("isPrivate")]
        public bool IsPrivate { get; set; }

        [JsonPropertyName("num")]
        public int Num { get; set; }

        [JsonPropertyName("tag")]
        public string Tag { get; set; } = string.Empty;
    }
}