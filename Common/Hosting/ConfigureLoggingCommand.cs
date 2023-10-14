using System.Diagnostics.CodeAnalysis;
using Destructurama;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Common.Hosting;

[ExcludeFromCodeCoverage]
public class ConfigureLoggingCommand
{
    public virtual void Execute(IServiceCollection services, IConfiguration configuration)
    {
        services.AddLogging(logging =>
        {
            logging.ClearProviders();
            logging.AddSerilog();
        });
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .Destructure.UsingAttributes()
            .Enrich.FromLogContext()
            .CreateLogger();
    }
}