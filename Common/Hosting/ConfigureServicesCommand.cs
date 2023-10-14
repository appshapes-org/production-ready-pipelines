using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Common.Hosting;

public class ConfigureServicesCommand
{
    public virtual void Execute(IServiceCollection services, IConfiguration configuration)
    {
        new ConfigureLoggingCommand().Execute(services, configuration);
    }
}