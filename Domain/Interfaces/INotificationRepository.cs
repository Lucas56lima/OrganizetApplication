using Domain.Entities;

namespace Domain.Interfaces
{
    public interface INotificationRepository
    {
        Task<Notification> PostNotification(Notification notification);
        Task<Notification> GetNotificationById(int id);
        Task<Notification> GetNotificationBySectorId(int sectorId);
        Task<Notification> PutNotification(int id, Notification notification);

    }
}
