using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Yhd.TencentCloud.SCF.Executors;
using Yhd.FindJobStat;

public class Stat
{
    static async Task Main(string[] args)
    {
        var builder = new HostBuilder()
            .ConfigureSCF((context, scfbuilder) =>
            {
                var configuration = scfbuilder.Configuration;
                scfbuilder.Services.AddEasyCaching(options =>
                {
                    options.UseInMemory();
                    //use redis cache that named redis
                    options.UseRedis(configuration).WithJson();
                });
                scfbuilder.Services.AddSingleton(configuration);
                scfbuilder.Services.AddFindJobStat(configuration);
                scfbuilder.Services.AddTransient<IFunctionInvoker, StatsHttpFunctionInvoker>();

            })
            .UseConsoleLifetime();


        var host = builder.Build();

        using (host)
        {
            await host.RunAsync();
        }

    }
}