using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class NotificationRepository(OrganizetContextDbServer contextServer) : INotificationRepository
    {
        private readonly OrganizetContextDbServer _contextServer = contextServer;

        public async Task<Notification> GetNotificationBySectorId(int sectorId)
        {
            var notifications = await _contextServer.Notifications
                                .Where(u => u.SectorId == sectorId && u.IsActive == true && u.IsNew == true)
                                .FirstOrDefaultAsync();
            return notifications;
        }

        public async Task<Notification> GetNotificationById(int id)
        {
            var notifications = await _contextServer.Notifications
                                .Where(u =>u.Id == id && u.IsActive == true)
                                .FirstOrDefaultAsync();
            return notifications;
        }

        public async Task<Notification> PostNotification(Notification notification)
        {
           await _contextServer.Notifications.AddAsync(notification);
           await _contextServer.SaveChangesAsync();
           return notification;
        }

        public async Task<Notification> PutNotification(int id, Notification notification)
        {
            // Verifica se a notificação passada é válida
            if (notification == null)
            {
                throw new ArgumentNullException(nameof(notification), "A notificação não pode ser nula.");
            }

            // Busca a notificação no banco de dados
            var notificationDb = await GetNotificationById(id);

            // Verifica se a notificação existe
            if (notificationDb == null)
            {
                throw new KeyNotFoundException($"Notificação com ID {id} não foi encontrada.");
            }

            // Atualiza os valores da notificação do banco de dados com os valores da notificação passada
            _contextServer.Entry(notificationDb).CurrentValues.SetValues(notification);
            _contextServer.Entry(notificationDb).State = EntityState.Modified;

            // Tenta salvar as mudanças no banco de dados
            try
            {
                await _contextServer.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                // Lida com erros de atualização no banco de dados
                Console.WriteLine($"Erro ao atualizar a notificação: {ex.Message}");
                throw; // Relança a exceção para tratamento externo, se necessário
            }

            // Retorna o objeto atualizado a partir do banco de dados
            return notificationDb;
        }

    }
}
