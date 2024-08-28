namespace DISample.InroToDI.Services
{
    public interface IResponseFormatter
    {
        Task Write(HttpContext httpContext, string message);
    }
}
