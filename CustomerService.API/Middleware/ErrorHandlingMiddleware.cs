using System.Net;
using System.Text.Json;

namespace CustomerService.API.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(RequestDelegate next, ILogger<ErrorHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.HasValue &&
                (context.Request.Path.StartsWithSegments("/swagger") ||
                 context.Request.Path.StartsWithSegments("/favicon.ico") ||
                 context.Request.Path.Value.EndsWith(".js") ||
                 context.Request.Path.Value.EndsWith(".css") ||
                 context.Request.Path.Value.EndsWith(".html")))
            {
                await _next(context);
                return;
            }

            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Unhandled exception: {Message}", ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var (statusCode, message) = exception switch
            {
                KeyNotFoundException => (HttpStatusCode.NotFound, exception.Message),
                ArgumentException => (HttpStatusCode.BadRequest, exception.Message),
                _ => (HttpStatusCode.InternalServerError, "Unexpected error occurred.")
            };

            response.StatusCode = (int)statusCode;

            var error = new
            {
                error = message,
                status = response.StatusCode
            };

            var json = JsonSerializer.Serialize(error);
            return response.WriteAsync(json);
        }
    }
}
