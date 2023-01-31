using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SpeedifySharpCLI.Models;

public class SpeedifySession
{
    public static SpeedifySession Parse(string json)
    {
        json += "]";

        var objectList = JsonSerializer.Deserialize<List<object>>(json)!;

        if (objectList.Count < 2)
            return new();

        var stateObject = objectList[1].ToString();
        if (stateObject is null)
            return new();

        return JsonSerializer.Deserialize<SpeedifySession>(stateObject.ToString())!;
    }

    public SpeedifySessionStats current { get; set; } = new();
    public SpeedifySessionStats day { get; set; } = new();
    public SpeedifySessionStats week { get; set; } = new();
    public SpeedifySessionStats month { get; set; } = new();
    public SpeedifySessionStats total { get; set; } = new();

}


public class SpeedifySessionStats
{
    [JsonPropertyName("bytesReceived")]
    public int bytesReceived { get; set; }

    [JsonPropertyName("bytesSent")]
    public int bytesSent { get; set; }

    [JsonPropertyName("captivePortal")]
    public CaptivePortal captivePortal { get; set; } = new();

    [JsonPropertyName("daysSinceFirst")]
    public int daysSinceFirst { get; set; }

    [JsonPropertyName("encryptedBytesReceived")]
    public int encryptedBytesReceived { get; set; }

    [JsonPropertyName("encryptedBytesSent")]
    public int encryptedBytesSent { get; set; }

    [JsonPropertyName("maxDownloadSpeed")]
    public double maxDownloadSpeed { get; set; }

    [JsonPropertyName("maxUploadSpeed")]
    public double maxUploadSpeed { get; set; }

    [JsonPropertyName("mbpsDownBenefit")]
    public double mbpsDownBenefit { get; set; }

    [JsonPropertyName("mbpsUpBenefit")]
    public double mbpsUpBenefit { get; set; }

    [JsonPropertyName("numFailovers")]
    public int numFailovers { get; set; }

    [JsonPropertyName("numSessions")]
    public int numSessions { get; set; }

    [JsonPropertyName("packetHandler")]
    public PacketHandler packetHandler { get; set; } = new();

    [JsonPropertyName("periodStartTime")]
    public int periodStartTime { get; set; }

    [JsonPropertyName("retransBytes")]
    public int retransBytes { get; set; }

    [JsonPropertyName("streaming")]
    public Streaming streaming { get; set; } = new();

    [JsonPropertyName("totalConnectedMinutes")]
    public int totalConnectedMinutes { get; set; }

    [JsonPropertyName("tun")]
    public Tun tun { get; set; } = new();


    public class CaptivePortal
    {
        [JsonPropertyName("detections")]
        public int detections { get; set; }

        [JsonPropertyName("successes")]
        public int successes { get; set; }
    }

    public class PacketHandler
    {
        [JsonPropertyName("bytesIn")]
        public int bytesIn { get; set; }

        [JsonPropertyName("bytesOut")]
        public int bytesOut { get; set; }

        [JsonPropertyName("packetsIn")]
        public int packetsIn { get; set; }

        [JsonPropertyName("packetsOut")]
        public int packetsOut { get; set; }

        [JsonPropertyName("retries")]
        public int retries { get; set; }
    }



    public class Streaming
    {
        [JsonPropertyName("totalFailoverSaves")]
        public int totalFailoverSaves { get; set; }

        [JsonPropertyName("totalRedundantModeSaves")]
        public int totalRedundantModeSaves { get; set; }

        [JsonPropertyName("totalSpeedModeSaves")]
        public int totalSpeedModeSaves { get; set; }

        [JsonPropertyName("totalStreams")]
        public int totalStreams { get; set; }

        [JsonPropertyName("uniqueSaves")]
        public int uniqueSaves { get; set; }
    }

    public class Tun
    {
        [JsonPropertyName("bufferWaits")]
        public int bufferWaits { get; set; }

        [JsonPropertyName("bytesIn")]
        public int bytesIn { get; set; }

        [JsonPropertyName("bytesOut")]
        public int bytesOut { get; set; }

        [JsonPropertyName("droppedIncoming")]
        public int droppedIncoming { get; set; }

        [JsonPropertyName("packetWaits")]
        public int packetWaits { get; set; }

        [JsonPropertyName("packetsIn")]
        public int packetsIn { get; set; }

        [JsonPropertyName("packetsOut")]
        public int packetsOut { get; set; }

        [JsonPropertyName("readQueue")]
        public int readQueue { get; set; }
    }

}