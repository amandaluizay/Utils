using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Utils.ServiceCollection
{
    internal static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, Assembly assembly, IConfiguration configuration)
        {
            return services;
        }
    }
}
