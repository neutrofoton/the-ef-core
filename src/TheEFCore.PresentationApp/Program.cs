using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TheEFCore.Repository.EFContext;

namespace TheEFCore.PresentationApp
{
    public class Program
    {
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            var hostBuilder = Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                        .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
                        .AddEnvironmentVariables();
                })
                .ConfigureServices(EFConfiguration.Configure)
                .ConfigureServices((context, services) =>
                {
                    //add your service registrations
                    //services.AddSingleton<IHelloService, HelloService>();

                    services.AddHostedService<Startup>();
                });

            return hostBuilder;
        }

        public static Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            //var helloService = host.Services.GetService<IHelloService>();
            
            host.Run();
            return Task.CompletedTask;
        }
    }
}

