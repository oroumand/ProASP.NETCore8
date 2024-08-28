namespace DISample.InroToDI.Services
{
    public class SimpleResponseFormatter : IResponseFormatter
    {
        private int _counter = 0;
        private readonly Guid guid = Guid.NewGuid();
        private static SimpleResponseFormatter _instance;
        public async Task Write(HttpContext httpContext, string message)
        {
            await httpContext.Response.WriteAsync($"Id: {guid},Response Wirter used for {++_counter}. Text is:{message}");
        }

        public static SimpleResponseFormatter Instance()
        {
            if (_instance == null)
            {
                _instance = new SimpleResponseFormatter();
            }
            return _instance;
        }
    }

    public class JsonResponseFormatter : IResponseFormatter
    {
        private int _counter = 0;

        private static JsonResponseFormatter _instance;
        public async Task Write(HttpContext httpContext, string message)
        {
            httpContext.Response.ContentType = "application/json";

            await httpContext.Response.WriteAsync($"JSON Response Wirter used for {++_counter}. Text is:{message}");
        }

        public static JsonResponseFormatter Instance()
        {
            if (_instance == null)
            {
                _instance = new JsonResponseFormatter();
            }
            return _instance;
        }
    }
}
