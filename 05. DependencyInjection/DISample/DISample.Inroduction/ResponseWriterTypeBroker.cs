using DISample.Inroduction.Services;

namespace DISample.Inroduction
{
    public class ResponseWriterTypeBroker
    {
        public static IResponseFormatter Get()
        {
            return JsonResponseFormatter.Instance();
        }
    }
}
