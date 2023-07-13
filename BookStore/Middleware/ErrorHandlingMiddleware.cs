using System.Text;
using System.Threading.Tasks;
using BookStore.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
namespace BookStore.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);

            }

            catch (BadHttpRequestException badHttpRequestException)
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync(badHttpRequestException.Message);
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
                context.Response.StatusCode = 500;
                await context.Response.WriteAsync("Something went wrong");
            }
        }
    }
}






