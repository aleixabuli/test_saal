using Domain.Repository.Contracts.FoodDelivery;
using Infra.FoodDelivery.Persistence.Model;
using Infra.FoodDelivery.Persistence.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Common.Extensions
{
    public static class PersistenceExtension
    {
        public static IServiceCollection AddPersistenceDependencyInjection(this IServiceCollection services)
        {
            services
                .AddTransient<IProductRepository, ProductRepository>()
                .AddTransient<IDeliveryOrderRepository, DeliveryOrderRepository>()
                .AddDbContext<IFoodDeliveryContext, FoodDeliveryContext>();
                ;

            return services;
        }
    }
}
