using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Infra.FoodDelivery.Api.ErrorExceptionHandler
{
    public class DefaultExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<DefaultExceptionHandler> _logger;

        public DefaultExceptionHandler(ILogger<DefaultExceptionHandler> logger)
        {
            _logger = logger;
        }

        public async ValueTask<bool> TryHandleAsync(
            HttpContext httpContext,
            Exception exception,
            CancellationToken cancellationToken
            )
        {
            _logger.LogError(
                exception,
                "An unhandled exception has occurred: {Message}",
                exception.Message
                );

#if DEBUG
            var problemDetails = new ProblemDetails()
            {
                Status = httpContext.Response.StatusCode,
                Title = "An unhandled exception has occurred",
                Detail = $@"Message: {exception.Message}
Stack trace: {exception.StackTrace}"
            };
#else
            var problemDetails = new ProblemDetails() 
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "An unhandled exceptions has occurred"
            };
            httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
#endif

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
