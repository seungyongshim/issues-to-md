using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;
using System;

namespace issues_to_md
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Host.CreateDefaultBuilder()
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                })
                .ConfigureServices(services =>
                {
                    var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

                    services.AddOptions();
                    services.Configure<AppOptions>(configuration.GetSection("App"));
                    services.AddSingleton<IssueService>();
                })
                .UseSerilog((h, s, l) =>
                {
                    l.ReadFrom.Configuration(h.Configuration);
                })
                .Build()
                .Services
                .GetService<IssueService>()
                .Run();

            Log.CloseAndFlush();
        }
    }
}