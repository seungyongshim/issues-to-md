using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;

namespace issues_to_md
{
    public class IssueService
    {
        public IssueService(IOptions<ConfigOptions> configApp, ILogger<IssueService> logger)
        {
            ConfigOptions = configApp;
            Logger = logger;
        }

        public IOptions<ConfigOptions> ConfigOptions { get; }
        public ILogger<IssueService> Logger { get; }

        public void Run()
        {
            //Logger.LogInformation("hello");

            Logger.LogInformation(Environment.GetEnvironmentVariable("DOTNET_Config__OAuth"));

            Logger.LogInformation(ConfigOptions.Value.OAuth);
        }
    }
}