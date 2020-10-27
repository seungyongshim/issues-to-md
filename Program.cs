using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace issues_to_md
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Host.CreateDefaultBuilder()
                .ConfigureServices(services =>
                {
                    var configuration = services.BuildServiceProvider().GetService<IConfiguration>();

                    services.AddOptions();
                    services.Configure<AppOptions>(configuration.GetSection("App"));
                    services.AddSingleton<IssueService>();
                })
                .Build()
                .Services
                .GetService<IssueService>()
                .Run();
        }
    }
}