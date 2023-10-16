using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Common.Hosting;

[ExcludeFromCodeCoverage]
public class ConfigureServicesCommand
{
    public virtual void Execute(IServiceCollection services, IConfiguration configuration)
    {
        new ConfigureLoggingCommand().Execute(services, configuration);
    }
}