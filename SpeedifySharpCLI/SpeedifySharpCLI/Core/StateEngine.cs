using SpeedifySharpCLI.Models;
using System.Text.RegularExpressions;

namespace SpeedifySharpCLI.Core;

public class StateEngine
{
    public SpeedifyAdapters SpeedifyAdapters { get; set; } = new();
    public SpeedifyConnection SpeedifyConnection { get; set; } = new();
    public SpeedifySession SpeedifySession { get; set; } = new();
    public SpeedifyState SpeedifyState { get; set; } = new();

    public SpeedifyServerInfo SpeedifyConnectedServerInfo { get; set; } = new();

    public virtual void ReticulateSplines(string stateJson)
    {
        var matches = Regex.Matches(stateJson, @"\[""(.*?)\]\r", RegexOptions.Singleline);

        for (int i = 0; i < matches.Count; i++)
        {
            var s = matches[i].ToString();

            if (s.StartsWith("[\"state\""))
            {
                SpeedifyState = SpeedifyState.Parse(s);
            }
            if (s.StartsWith("[\"session_stats\""))
            {
                SpeedifySession = SpeedifySession.Parse(s);
            }
            if (s.StartsWith("[\"connection_stats\""))
            {
                SpeedifyConnection = SpeedifyConnection.Parse(s);
            }
            if (s.StartsWith("[\"adapters\""))
            {
                SpeedifyAdapters = SpeedifyAdapters.Parse(s);
            }
        }
    }

    public virtual void SetConnectState(string connectJson)
    {
        SpeedifyConnectedServerInfo = SpeedifyServerInfo.Parse(connectJson);
    }
}