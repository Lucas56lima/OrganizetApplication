using Domain.Entities;

namespace Domain.Interfaces
{
    public interface INotificationService
    {
        Task<Notification> PostNotification(Notification notification);
        Task<Notification> GetNotificationById(int id);
        Task<Notification> GetNotificationBySectorId(int sectorId);
        Task<Notification> PutNotification(int id,Notification notification);
        Task<IEnumerable<Notification>> GetNotificationsBySectorId(int sectorId);
    }
}
