using DISample.Inroduction.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DISample.Inroduction
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class NamePrinter
    {
        private readonly RequestDelegate _next;

        public NamePrinter(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            IResponseFormatter simpleResponseFormatter = ResponseWriterTypeBroker.Get();
            if (httpContext.Request.Path == "/print/mw")
            {
                await simpleResponseFormatter.Write(httpContext, "Alireza Oroumand");
            }
            else
            {
                await _next(httpContext);

            }

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class NamePrinterExtensions
    {
        public static IApplicationBuilder UseNamePrinter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NamePrinter>();
        }
    }
}
