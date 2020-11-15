using System;
using ClubApp.Api.MiddleWare;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;


namespace ClubApp.Api.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseApiExceptionHandler(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ApiExceptionHandlerMiddleware>();
        }

        public static IApplicationBuilder UseReadableRequestBody(this IApplicationBuilder app)
        {
            return app.Use( async (httpContext, next) => {
                httpContext.Request.EnableBuffering();

                await next();
            });
        }
    }
}
