using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EVALUACION.API.Infrastructure;
using EVALUACION.INFRASTRUCTURE;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace EVALUACION.API
{
    public class Program
    {
        public static int Main(string[] args)
        {
            var configuration = GetConfiguration();

            try
            {
                Log.Information("Configuring web host ({ApplicationContext})...", "");
                var host = BuildWebHost(configuration, args);

                Log.Information("Applying migrations ({ApplicationContext})...", "");
                host.MigrateDbContext<OCContext>((context, services) =>
                {
                    new OCContextSeed()
                        .SeedAsync(context)
                        .Wait();
                });

                host.Run();

                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Program terminated unexpectedly ({ApplicationContext})!", "");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
            //CreateWebHostBuilder(args).Build().Run();
        }

        private static IWebHost BuildWebHost(IConfiguration configuration, string[] args) =>
    WebHost.CreateDefaultBuilder(args)
        .CaptureStartupErrors(false)
        .UseStartup<Startup>()
        .UseContentRoot(Directory.GetCurrentDirectory())
        .UseConfiguration(configuration)
        .Build();

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            var config = builder.Build();
            return builder.Build();
        }

    }
}
