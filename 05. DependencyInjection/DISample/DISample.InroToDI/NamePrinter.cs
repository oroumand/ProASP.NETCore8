using DISample.InroToDI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DISample.InroToDI
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class NamePrinter
    {
        private readonly RequestDelegate _next;
        private readonly IResponseFormatter responseFormatter;

        public NamePrinter(RequestDelegate next, IResponseFormatter responseFormatter)
        {
            _next = next;
            this.responseFormatter = responseFormatter;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext.Request.Path == "/print/mw")
            {
                await responseFormatter.Write(httpContext, "Alireza Oroumand");
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
