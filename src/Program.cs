using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;

namespace AzureFunctionRabbitMQ
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = new HostBuilder()
               .UseEnvironment("Development")
               .ConfigureWebJobs(webJobsBuilder =>
               {
                   webJobsBuilder
                   .AddAzureStorageCoreServices()
                   .AddAzureStorage()
                   .AddRabbitMQ()
                   .AddTimers();
               })
               .ConfigureLogging(b =>
               {
                   b.SetMinimumLevel(LogLevel.Debug);
                   b.AddConsole();
               })
               .UseConsoleLifetime();

            var host = builder.Build();
            using (host)
            {
                var jobHost = (JobHost)host.Services.GetService<IJobHost>();

                await host.RunAsync();
            }
        }
    }
}