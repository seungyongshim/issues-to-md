using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace issues_to_md
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Host.CreateDefaultBuilder()
                .ConfigureServices(sc =>
                {
                    sc.AddOptions<ConfigOptions>();
                    sc.AddSingleton<IssueService>();
                })
                .Build()
                .Services.GetService<IssueService>().Run();
        }
    }
}