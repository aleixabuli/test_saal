//using Domain.Service.Contracts.TextProcess;
//using Domain.Service.TextProcess;
using Domain.Service.Contracts.Delivery;
using Domain.Service.Delivery;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Common.Extensions
{
    public static class DomainExtension
    {
        public static IServiceCollection AddDomainDependencyInjection(this IServiceCollection services)
        {
            services
                .AddTransient<IProductService, ProductService>()
                .AddTransient<IDeliveryOrderService, DeliveryOrderService>()
                ;

            return services;
        }
    }
}
