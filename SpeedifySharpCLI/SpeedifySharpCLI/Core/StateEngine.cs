using SpeedifySharpCLI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedifySharpCLI.Core
{
    public class StateEngine
    {
        public SpeedifyConnection SpeedifyConnection { get; set; } = new();
        public SpeedifySession SpeedifySession { get; set; } = new();
        public SpeedifyState SpeedifyState { get; set; } = new();

        public virtual void ReticulateSplines(string stateJson)
        {

            //var states = stateJson.Split("}]");
            var states = stateJson.Split("]\r\n\r\n");
            //states = states.Select(s => s += "]").ToArray();

            foreach (var s in states)
            {
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
            }

        }
    }
}
