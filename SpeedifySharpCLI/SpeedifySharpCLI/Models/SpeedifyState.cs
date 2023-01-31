using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpeedifySharpCLI.Models;

public class SpeedifyState
{
    public static SpeedifyState Parse(string json)
    {
        //json = json.Replace("[\"state\",", "") + "}";
        json = json.Replace("[\"state\",", "");

        return JsonSerializer.Deserialize<SpeedifyState>(json)!;
    }

    [JsonPropertyName("state")]
    public string State { get; set; } = "Unset";
}