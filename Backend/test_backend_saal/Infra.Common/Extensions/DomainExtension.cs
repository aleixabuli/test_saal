//using Domain.Service.Contracts.TextProcess;
//using Domain.Service.TextProcess;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Common.Extensions
{
    public static class DomainExtension
    {
        public static IServiceCollection AddDomainDependencyInjection(this IServiceCollection services)
        {
            //services
            //    .AddTransient<ITextProcessService, TextProcessService>()
            //    ;

            return services;
        }
    }
}
