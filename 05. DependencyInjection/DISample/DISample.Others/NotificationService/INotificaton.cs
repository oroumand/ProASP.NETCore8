namespace DISample.Others.NotificationService
{
    public interface INotificaton
    {
        Task Notify(string message);
    }

    public class SmsNotification : INotificaton
    {
        public Task Notify(string message)
        {
            throw new NotImplementedException();
        }
    }

    public class EmailNotification : INotificaton
    {
        public Task Notify(string message)
        {
            throw new NotImplementedException();
        }
    }
}
