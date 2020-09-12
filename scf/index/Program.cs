using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Yhd.FindJob;
using Yhd.TencentCloud.SCF.Executors;

public class Index
{
    static async Task Main(string[] args)
    {
        var builder = new HostBuilder()
            .ConfigureSCF((context, scfbuilder) =>
            {
                var configuration = scfbuilder.Configuration;

                scfbuilder.Services.AddFindJob(configuration);
                scfbuilder.Services.AddEasyCaching(options =>
                {
                    options.UseInMemory();
                    //use redis cache that named redis
                    options.UseRedis(configuration)
                    .WithJson() 
                    ;
                });
                scfbuilder.Services.AddTransient<IFunctionInvoker, JobsHttpFunctionInvoker>();
               
            }) 
            .UseConsoleLifetime();


        var host = builder.Build();

        using (host)
        {
            await host.RunAsync();
        }

    }
}
