using DISample.InroToDI.Services;

namespace DISample.InroToDI
{
    public class MyEndpoint
    {

        public static async Task NamePrinter(HttpContext context)
        {

            IResponseFormatter simpleResponseFormatter = context.RequestServices.GetRequiredService<IResponseFormatter>();

            await simpleResponseFormatter.Write(context, "Alireza Oroumand From Class Endpoint");

        }
    }
}
