namespace SpeedifySharpCLI.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddHostedService<Worker>();

                    services.AddSingleton<SpeedifySharp>();
                })
                .Build();

            host.Run();
        }
    }
}