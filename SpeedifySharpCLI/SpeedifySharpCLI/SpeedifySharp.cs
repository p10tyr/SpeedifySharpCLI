using SpeedifySharpCLI.Core;
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
            var stateJson = Run("stats 1");
            States.ReticulateSplines(stateJson);
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
            //Console.WriteLine(err);
            string output = process.StandardOutput.ReadToEnd();

            process.WaitForExit();



            return output;
        }
    }
}