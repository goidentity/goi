using Microsoft.AspNetCore.Hosting;
using Serilog;
using System.IO;

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
                .UseSerilog()
                .Build();

            host.Run();
        }
    }
}
