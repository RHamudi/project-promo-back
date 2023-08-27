using Promocoes.Domain.Notifications;

namespace Promocoes.Domain.Entities
{
    public abstract class BaseEntity
    {
        List<Notification> _notifications;

        protected BaseEntity()
        {
            this._notifications = new List<Notification>();
        }
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }
        public static DateTime CreatedOn => DateTime.Now;
    }
}