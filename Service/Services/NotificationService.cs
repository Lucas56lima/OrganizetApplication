using Domain.Entities;
using Domain.Interfaces;

namespace Service.Services
{
    public class NotificationService(INotificationRepository repository) : INotificationService
    {
        private readonly INotificationRepository _repository = repository;

        public async Task<Notification> GetNotificationBySectorId(int sectorId)
        {
            var notifcation = await _repository.GetNotificationBySectorId(sectorId);
            if(notifcation == null)
                return null;
            return notifcation;
        }

        public async Task<Notification> GetNotificationById(int sectorId)
        {
            var notifications = await _repository.GetNotificationById(sectorId);
            if(notifications == null)
                return null;

            return notifications;
        }

        public async Task<Notification> PostNotification(Notification notification)
        {
            notification.CreateDate = DateOnly.FromDateTime(DateTime.Now);
            notification.CreateHour = DateTime.Now.TimeOfDay.ToString();
            return await _repository.PostNotification(notification);
        }

        public async Task<Notification> PutNotification(int id, Notification notification)
        {
            var notificationId = await _repository.GetNotificationById(id);
            if(notificationId == null)
                 return null;

            Notification newNotification = new Notification
            {
                Id = notificationId.Id,
                Message = notificationId.Message,
                Color = notificationId.Color,
                ColorHover = notificationId.ColorHover,
                SectorId = notificationId.SectorId,
                CreateDate = notificationId.CreateDate,
                CreateHour = notificationId.CreateHour,
                TaskId = notificationId.TaskId,
                IsRead = notificationId.IsRead,
                IsNew = false,
                IsActive = notificationId.IsActive
            };

            return await _repository.PutNotification(id,newNotification);
        }

        public async Task<IEnumerable<Notification>> GetNotificationsBySectorId(int sectorId)
        {
            var notifications = await _repository.GetNotificationsBySectorId(sectorId);
            if(notifications == null)
                return Enumerable.Empty<Notification>();

            return notifications;
        }
    }
}
