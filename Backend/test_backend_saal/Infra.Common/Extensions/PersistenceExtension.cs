using Microsoft.Extensions.DependencyInjection;

namespace Infra.Common.Extensions
{
    public static class PersistenceExtension
    {
        public static IServiceCollection AddPersistenceDependencyInjection(this IServiceCollection services)
        {
            return services;
        }
    }
}
