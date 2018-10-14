using Microsoft.AspNetCore.Hosting;
using Serilog;
using Serilog.Configuration;
using System.IO;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace GoIdentity.Web.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Warning()
                        .WriteTo.Console()
                        .WriteTo.File(@"\logs\goidentity-{Date}.txt", rollingInterval: RollingInterval.Day)
                        .CreateLogger();

            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .ConfigureLogging((hostingContext, logging) =>
                {
                    logging.ClearProviders();
                    logging.AddDebug();
                })
                .Build();

            host.Run();
        }
    }
}
