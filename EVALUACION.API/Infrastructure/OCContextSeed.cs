using EVALUACION.INFRASTRUCTURE;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EVALUACION.API.Infrastructure
{
    public class OCContextSeed
    {
        public async Task SeedAsync(OCContext context
    //IHostingEnvironment env,
    //ILogger<OCContextSeed> logger
            )
        {
            var policy = CreatePolicy(
                //(logger, 
                nameof(OCContextSeed)
                );

            await policy.Execute(async () =>
            {
                using (context)
                {
                    context.Database.Migrate();

                    await context.SaveChangesAsync();
                }
            });
        }

        private Policy CreatePolicy(
            //ILogger<OCContextSeed> logger,
            string prefix, int retries = 3)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetry(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        //logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", prefix
                        //    , exception.GetType().Name, exception.Message, retry, retries);
                    }
                );
        }
    }
}
