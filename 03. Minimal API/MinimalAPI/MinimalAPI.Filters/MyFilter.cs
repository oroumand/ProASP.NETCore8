
namespace MinimalAPI.Filters
{
    public class MyFilter : IEndpointFilter
    {
        public async ValueTask<object?>
            InvokeAsync(EndpointFilterInvocationContext context,
            EndpointFilterDelegate next)
        {
            var result = await next(context);
            return result;
        }
    }
}
