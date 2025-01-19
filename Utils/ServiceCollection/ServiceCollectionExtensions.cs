using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Utils.ServiceCollection
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, Assembly assembly, IConfiguration configuration)
        {
            services.Configure<DataverseConfig>(config => configuration.GetRequiredSection(nameof(DataverseConfig)).Bind(config));

            services.AddDbContext<FutebolDbContext>((serviceProvider, options) =>
            {
                options.UseSqlServer();
            });

            return services;
        }
    }
}
