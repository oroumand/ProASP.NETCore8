namespace DISample.Inroduction.Services
{
    public interface IResponseFormatter
    {
        Task Write(HttpContext httpContext, string message);
    }
}
