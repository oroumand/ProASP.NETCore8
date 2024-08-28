namespace DISample.Others.NotificationService
{
    public class SimpleNotif
    {
        private readonly INotificaton notificaton;

        public SimpleNotif(INotificaton notificaton)
        {
            this.notificaton = notificaton;
        }
    }

    public class ListNotif
    {
        private readonly IEnumerable<INotificaton> notificaton;

        public ListNotif(IEnumerable<INotificaton> notificaton)
        {
            this.notificaton = notificaton;
        }
    }

    public class KeyedNotif
    {
        private readonly INotificaton notificaton;

        public KeyedNotif([FromKeyedServices("sms")] INotificaton notificaton)
        {
            this.notificaton = notificaton;
        }
    }
}
