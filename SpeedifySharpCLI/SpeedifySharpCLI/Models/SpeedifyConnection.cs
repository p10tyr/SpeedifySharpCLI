using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpeedifySharpCLI.Models;

public class SpeedifyConnection
{
    public static SpeedifyConnection Parse(string json)
    {
        json += "]";

        var objectList = JsonSerializer.Deserialize<List<object>>(json)!;

        if (objectList.Count < 2)
            return new();

        var stateObject = objectList[1].ToString();
        if (stateObject is null)
            return new();

        return JsonSerializer.Deserialize<SpeedifyConnection>(stateObject.ToString())!;
    }

    public SpeedifyConnectionStats[] connections { get; set; } = new SpeedifyConnectionStats[0];
    public long time { get; set; }
}


public class SpeedifyConnectionStats
{

    public override string ToString()
    {
        return ConnectionID.ToString();
    }

    [JsonPropertyName("adapterID")]
    public string AdapterID { get; set; } = string.Empty;

    [JsonPropertyName("connected")]
    public bool Connected { get; set; }

    [JsonPropertyName("connectionID")]
    public string ConnectionID { get; set; } = string.Empty;

    [JsonPropertyName("inFlight")]
    public int InFlight { get; set; }

    [JsonPropertyName("inFlightWindow")]
    public int InFlightWindow { get; set; }

    [JsonPropertyName("jitterMs")]
    public int JitterMs { get; set; }

    [JsonPropertyName("latencyMs")]
    public int LatencyMs { get; set; }

    [JsonPropertyName("localIp")]
    public string LocalIp { get; set; } = string.Empty;

    [JsonPropertyName("lossReceive")]
    public double LossReceive { get; set; }

    [JsonPropertyName("lossSend")]
    public double LossSend { get; set; }

    [JsonPropertyName("mos")]
    public double Mos { get; set; }

    [JsonPropertyName("numberOfSockets")]
    public int NumberOfSockets { get; set; }

    [JsonPropertyName("privateIp")]
    public string PrivateIp { get; set; } = string.Empty;

    [JsonPropertyName("protocol")]
    public string Protocol { get; set; } = string.Empty;

    [JsonPropertyName("receiveBps")]
    public int ReceiveBps { get; set; }

    [JsonPropertyName("receiveEstimateMbps")]
    public double ReceiveEstimateMbps { get; set; }

    [JsonPropertyName("remoteIp")]
    public string RemoteIp { get; set; } = string.Empty;

    [JsonPropertyName("sendBps")]
    public int SendBps { get; set; }

    [JsonPropertyName("sendEstimateMbps")]
    public double SendEstimateMbps { get; set; }

    [JsonPropertyName("sleeping")]
    public bool Sleeping { get; set; }

    [JsonPropertyName("totalBps")]
    public int TotalBps { get; set; }

}
