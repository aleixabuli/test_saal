//using Application.TextProcess.UseCase;
//using Application.TextProcess.UseCaseContracts;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Common.Extensions
{
    public static class ApplicationExtension
    {
        public static IServiceCollection AddApplicationDependencyInjection(this IServiceCollection service)
        {
            //service
            //    .AddTransient<IGetOrderOptions, GetOrderOptions>()
            //    .AddTransient<IGetOrderedText, GetOrderedText>()
            //    .AddTransient<IGetStatistics, GetStatistics>()
            //    ;

            return service;
        }
    }
}
