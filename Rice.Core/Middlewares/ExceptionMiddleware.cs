using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Rice.Core.CustomExceptions;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace Rice.Core.Middlewares
{

    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ILogger<ExceptionMiddleware> logger)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e, logger);
            }
        }

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception e, ILogger<ExceptionMiddleware> logger)
        {
            httpContext.Response.ContentType = "application/json";

            string message = ""; 

            if (e is ValidationException )
            {
                message = e.Message;
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                logger.LogTrace(message);
            }
            else if (e is ProjectException)
            {
                message = e.Message;
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                logger.LogTrace(message);
            }
            else
            {
                var errorGuid = Guid.NewGuid().ToString();
                message = $"Beklenmedik bir hata oluştu. Hata kayıt bilgisi :  " + errorGuid;
                logger.LogCritical(e, message);
            }
            await httpContext.Response.WriteAsJsonAsync(new { success = false, message = message });
        }
    }

}
