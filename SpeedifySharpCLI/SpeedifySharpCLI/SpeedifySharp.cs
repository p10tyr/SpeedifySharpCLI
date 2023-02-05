using SpeedifySharpCLI.Core;
using SpeedifySharpCLI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedifySharpCLI
{
    public class SpeedifySharp
    {
        public StateEngine States = new StateEngine();

        private string pathAndFileCli = string.Empty;

        //Todo Injectio IOptions
        //public SpeedifySharp(string pathAndFileNameToSpeedifyCli)
        //{
        //    pathAndFileCli = pathAndFileNameToSpeedifyCli;
        //}

        public void SetPathAndFileName(string pathAndFileNameToSpeedifyCli)
        {
            pathAndFileCli = pathAndFileNameToSpeedifyCli;
        }

        public void RefreshStats()
        {
            States.ReticulateSplines(GetStats());

            if (States.SpeedifyState.State.Equals("CONNECTED"))
            {
                States.SetConnectState(GetCurrentServerInfo());
            }
            else
            {
                States.SpeedifyConnectedServerInfo = new SpeedifyServerInfo();
            }
        }

        public virtual string GetStats()
        {
            return Run("stats 1");
        }
        public virtual string GetCurrentServerInfo()
        {
            return Run("show currentserver");
        }


        public virtual SpeedifyServers GetGetServers()
        {
            var resultJson = Run("show servers");
            return SpeedifyServers.Parse(resultJson);
        }


        /// <summary>
        /// This will connect Speedify to last know or find a new server. Calling it again will just return the current connect info
        /// </summary>
        public virtual SpeedifyServerInfo Connect()
        {
            var resultJson = Run("connect");
            return SpeedifyServerInfo.Parse(resultJson);
        }

        /// <summary>
        /// Connect to selected server by tag
        /// </summary>
        /// <param name="tag"><country>-city-number</param>
        /// <returns></returns>
        public virtual SpeedifyServerInfo Connect(string tag)
        {
            var locationTagParam = tag.Replace('-', ' ');
            var resultJson = Run($"connect {locationTagParam}");
            return SpeedifyServerInfo.Parse(resultJson);
        }

        /// <summary>
        /// This will connect Speedify to closest known server. Calling it again will RECONNECT the next closest server
        /// </summary>
        public virtual SpeedifyServerInfo ConnectClosest()
        {
            var resultJson = Run("connect closest");
            return SpeedifyServerInfo.Parse(resultJson);
        }


        public virtual string Run(string arguments)
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = pathAndFileCli,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    //RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };

            process.Start();

            //string output = process.StandardOutput.ReadToEnd();
            //Console.WriteLine(output);

            //string err = process.StandardError.ReadToEnd();
            //if (!string.IsNullOrWhiteSpace(err))
             //   ;
            //Console.WriteLine(err);
            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();


            return output;
        }
    }
}