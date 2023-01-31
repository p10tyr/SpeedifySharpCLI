using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpeedifySharpCLI.Models;

public class SpeedifyAdapters
{
    public static SpeedifyAdapters Parse(string json)
    {
        json += "]";

        var objectList = JsonSerializer.Deserialize<List<object>>(json)!;

        if (objectList.Count < 2)
            return new();

        var stateObject = objectList[1].ToString();
        if (stateObject is null)
            return new();

        var array = JsonSerializer.Deserialize<SpeedifyAdaptersStats[]>(stateObject.ToString())!;
        
        return new SpeedifyAdapters() { adapters = array };
    }

    public SpeedifyAdaptersStats[] adapters { get; set; } = new SpeedifyAdaptersStats[0];
}


public class SpeedifyAdaptersStats
{
    public override string ToString()
    {
        return $"{Description} {State} {Priority} {WorkingPriority}";
    }

    [JsonPropertyName("adapterID")]
    public string AdapterID { get; set; } = String.Empty;

    [JsonPropertyName("connectedNetworkBSSID")]
    public string ConnectedNetworkBSSID { get; set; } = String.Empty;

    [JsonPropertyName("connectedNetworkName")]
    public string ConnectedNetworkName { get; set; } = String.Empty;

    [JsonPropertyName("dataUsage")]
    public DataUsageStats DataUsage { get; set; } = new();

    [JsonPropertyName("description")]
    public string Description { get; set; } = String.Empty;

    [JsonPropertyName("isp")]
    public string Isp { get; set; } = String.Empty;

    [JsonPropertyName("name")]
    public string Name { get; set; } = String.Empty;

    [JsonPropertyName("priority")]
    public string Priority { get; set; } = String.Empty;

    [JsonPropertyName("rateLimit")]
    public long RateLimit { get; set; }

    [JsonPropertyName("state")]
    public string State { get; set; } = String.Empty;

    [JsonPropertyName("type")]
    public string Type { get; set; } = String.Empty;

    [JsonPropertyName("workingPriority")]
    public string WorkingPriority { get; set; } = String.Empty;

    public class DataUsageStats
    {
        [JsonPropertyName("overlimitRatelimit")]
        public long OverlimitRatelimit { get; set; }

        [JsonPropertyName("usageDaily")]
        public long UsageDaily { get; set; }

        [JsonPropertyName("usageDailyBoost")]
        public long UsageDailyBoost { get; set; }

        [JsonPropertyName("usageDailyLimit")]
        public long UsageDailyLimit { get; set; }

        [JsonPropertyName("usageMonthly")]
        public long UsageMonthly { get; set; }

        [JsonPropertyName("usageMonthlyLimit")]
        public long UsageMonthlyLimit { get; set; }

        [JsonPropertyName("usageMonthlyResetDay")]
        public long UsageMonthlyResetDay { get; set; }
    }

}
