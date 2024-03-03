//using Application.TextProcess.UseCase;
//using Application.TextProcess.UseCaseContracts;
using Application.FoodDelivery.UseCase;
using Application.FoodDelivery.UseCaseContracts;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Common.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection service)
        {
            service
                .AddTransient<IGetAllProductsUseCase, GetAllProductsUseCase>()
                ;

            return service;
        }
    }
}
