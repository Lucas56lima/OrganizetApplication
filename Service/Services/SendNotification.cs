using Microsoft.AspNetCore.SignalR;

namespace Service.Services
{
    public class SendNotification : Hub
    {
        public async Task SendNotifications(int sectorId, string message)
        {
            await Clients.All.SendAsync("ReceivedMessage", sectorId, message).ConfigureAwait(false);
        }
    }
}
