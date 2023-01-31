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

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _speedify.SetPathAndFileName(@"C:\Program Files (x86)\Speedify\speedify_cli.exe");

            while (!stoppingToken.IsCancellationRequested)
            {
                //_logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                _speedify.RefreshStats();

                var s = _speedify.States;

                Console.Clear();

                Console.WriteLine($"{DateTimeOffset.Now}");

                Console.WriteLine($"State: {s.SpeedifyState.State}");
                Console.WriteLine($"Sent: {s.SpeedifySession.current.bytesSent}");
                Console.WriteLine($"Recieved: {s.SpeedifySession.current.bytesReceived}");
                foreach (var c in s.SpeedifyConnection.connections.Where(x => x.Protocol != "proxy"))
                {
                    Console.WriteLine($"");
                    Console.WriteLine($"Connection: {c.ConnectionID} {c.PrivateIp} -> {c.LocalIp} ==> {c.RemoteIp}");
                    Console.WriteLine($"Download: {c.ReceiveEstimateMbps}Mbps");
                    Console.WriteLine($"Upload: {c.SendEstimateMbps}Mpbs");
                    Console.WriteLine($"Jitter: {c.JitterMs} Latency: {c.LatencyMs} Protocol: {c.Protocol}");
                }

                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}