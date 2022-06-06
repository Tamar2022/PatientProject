using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CoronaApp.Middlewares
{
    public class ErrorMiddleware
    {       
            private readonly RequestDelegate _next;

            public ErrorMiddleware(RequestDelegate next)
            {
                _next = next;
            }

            public async Task Invoke(HttpContext httpContext, ILogger<ErrorMiddleware> logger)
            {
                try
                {
                    await _next(httpContext);
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message + "Stack Trace is: " + ex.StackTrace);
                    httpContext.Response.StatusCode = 500;
                }
            }
        }


        public static class ErrorMiddlewareExtensions
        {
            public static IApplicationBuilder UseErrorMiddleware(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<ErrorMiddleware>();
            }
        }
    }

