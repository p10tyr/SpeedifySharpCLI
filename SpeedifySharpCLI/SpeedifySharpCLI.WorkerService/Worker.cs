using SpeedifySharpCLI.Helpers;

namespace SpeedifySharpCLI.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly SpeedifySharp _speedify;

        public Worker(ILogger<Worker> logger, SpeedifySharp speedify)
        {
            _logger = logger;
            _speedify = speedify;
        }

        int counter = 0;

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Console.Clear();

            _speedify.SetPathAndFileName(@"C:\Program Files (x86)\Speedify\speedify_cli.exe");

            var servers = _speedify.GetGetServers();
            //_speedify.ConnectClosest();
            var randomServer = servers.Public.OrderBy(su => Guid.NewGuid()).First();
            _speedify.Connect(randomServer.Tag);

            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _speedify.RefreshStats();

                var s = _speedify.States;

                Console.Clear();

                Console.WriteLine($"{DateTimeOffset.Now} - Reconnect {counter}/10");
                Console.WriteLine($"");

                Console.WriteLine($"State: {s.SpeedifyState.State}");
                Console.WriteLine($"Server {s.SpeedifyConnectedServerInfo.FriendlyName} [{s.SpeedifyConnectedServerInfo.Tag}] ");
                Console.WriteLine($"Sent: {BytesHelper.ToMegabyte(s.SpeedifySession.current.bytesSent):F2}Mb");
                Console.WriteLine($"Recieved: {BytesHelper.ToMegabyte(s.SpeedifySession.current.bytesReceived):F2}Mb");
                foreach (var c in s.SpeedifyConnection.connections.Where(x => x.Protocol != "proxy"))
                {
                    Console.WriteLine($"");
                    Console.WriteLine($"Connection: {c.ConnectionID} {c.PrivateIp} -> {c.LocalIp} ==> {c.RemoteIp}");
                    Console.WriteLine($"Download: { BitsHelper.ToMbps(c.ReceiveBps):F2}Mbps");
                    Console.WriteLine($"Upload: { BitsHelper.ToMbps(c.SendBps):F2}Mpbs");
                    Console.WriteLine($"Jitter: {c.JitterMs} Latency: {c.LatencyMs} Protocol: {c.Protocol}");
                }

                counter++;
                await Task.Delay(1200, stoppingToken);

                //test reconnect
                if (counter > 10)
                {
                    counter = 0;
                    _speedify.ConnectClosest();
                }
            }
        }
    }
}