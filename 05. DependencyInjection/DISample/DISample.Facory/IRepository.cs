namespace DISample.Facory
{
    public interface IRepository
    {
        public string Get();
    }

    public class IntReposiory : IRepository
    {
        public string Get()
        {
            return "1";
        }
    }

    public class DateTimeRepository : IRepository
    {
        public string Get()
        {
            return DateTime.Now.ToString();
        }
    }
}
