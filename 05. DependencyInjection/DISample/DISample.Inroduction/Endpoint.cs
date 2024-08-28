using DISample.Inroduction.Services;
using Microsoft.AspNetCore.Http;

namespace DISample.Inroduction
{
    public class MyEndpoint
    {

        public static async Task NamePrinter(HttpContext context)
        {
            IResponseFormatter simpleResponseFormatter = ResponseWriterTypeBroker.Get();

            await simpleResponseFormatter.Write(context,"Alireza Oroumand From Class Endpoint");

        }
    }
}
