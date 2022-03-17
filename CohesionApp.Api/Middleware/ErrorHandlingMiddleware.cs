using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using CohesionApp.Domain.Exceptions;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;

namespace CohesionApp.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;
        private readonly RequestDelegate _next;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger, RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            string message;

            var exceptionType = exception.GetType();

            switch (exceptionType.Name)
            {
                case nameof(BadRequestException):
                    message = exception.Message;
                    status = HttpStatusCode.BadRequest;
                    break;
                case nameof(NotFoundException):
                    message = exception.Message;
                    status = HttpStatusCode.NotFound;
                    break;
                default:
                    status = HttpStatusCode.InternalServerError;
                    message = exception.Message;
                    break;
            }

            var result = JsonConvert.SerializeObject(new { error = message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;
            return context.Response.WriteAsync(result);
        }
    }
}
