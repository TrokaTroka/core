using System.Collections.Generic;

namespace TrokaTroka.Api.Notifications
{
    public interface INotifier
    {
        List<Notification> GetAllNotifications();
        void Handle(Notification notification);
        bool HaveNotification();
    }
}