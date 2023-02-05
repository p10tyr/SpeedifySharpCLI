using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpeedifySharpCLI.Models;

public class SpeedifyServerInfo
{
    public static SpeedifyServerInfo Parse(string json)
    {
        return JsonSerializer.Deserialize<SpeedifyServerInfo>(json)!;
    }

    [JsonPropertyName("city")]
    public string City { get; set; } = string.Empty;

    [JsonPropertyName("country")]
    public string Country { get; set; } = string.Empty;

    [JsonPropertyName("friendlyName")]
    public string FriendlyName { get; set; } = "Not Connected";

    [JsonPropertyName("isPrivate")]
    public bool IsPrivate { get; set; }

    [JsonPropertyName("num")]
    public int Num { get; set; }

    [JsonPropertyName("publicIP")]
    public List<string> PublicIP { get; set; } = new List<string>();

    [JsonPropertyName("tag")]
    public string Tag { get; set; } = string.Empty;

    [JsonPropertyName("torrentAllowed")]
    public bool TorrentAllowed { get; set; }
}