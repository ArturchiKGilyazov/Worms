using System.Threading;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheWorms_CS_lab_Windows.services;

namespace TheWorms_CS_lab_Windows
{
    internal static class TheWormsApplication
    {
        public static int Main(string[] args)
        {
            
            var cancellationTokenSource = new CancellationTokenSource(5000);
            CreateHostBuilder(args).Build().StartAsync(cancellationTokenSource.Token);
            // CreateHostBuilder(args).Build().Run();
            return 0;
        }
        
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(serviceCollection =>
                {
                    serviceCollection.AddHostedService<Xelnaga>();
                    serviceCollection.AddSingleton<FoodService>();
                    serviceCollection.AddSingleton<NameService>();
                    serviceCollection.AddSingleton<ReportService>();
                    serviceCollection.AddSingleton<DirectionService>();
                    serviceCollection.AddSingleton<NegotiatingService>();
                    serviceCollection.AddSingleton<IntellectualService>();
                });
        }
    }
}