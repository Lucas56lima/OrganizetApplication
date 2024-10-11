using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Organizet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationsController : Controller
    {
        private static readonly Dictionary<int, HttpResponse> _clients = new();
        private readonly INotificationService _notificationService;
        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        [HttpGet("events")]
        public async Task Events(int clientId)
        {
            Response.ContentType = "text/event-stream";
            var response = Response;
            _clients[clientId] = response;
            try
            {
                while (true)
                {
                    await Task.Delay(5000); // Aguarda um intervalo antes de enviar uma nova mensagem
                    await response.WriteAsync($"data: Nova tarefa em grupo criada!\n\n"); // Exemplo de envio de data/hora
                    await response.Body.FlushAsync();
                }
            }
            catch
            {
                // Remover cliente em caso de desconexão
                _clients.Remove(clientId);
            }

        }

        [HttpPost("RegisterNotification")]
        public async Task<IActionResult> PostNotificationAsync([FromBody] Notification notification)
        {
            return Ok(await _notificationService.PostNotification(notification));
        }

        [HttpGet("GetNotificationById")]
        public async Task<IActionResult> GetNotificationById(int id)
        {
            return Ok(await _notificationService.GetNotificationById(id));
        }
        [HttpGet("GetNotificationBySectorId")]
        public async Task<IActionResult> GetNotificationBySectorId(int sectorId)
        {
            return Ok(await _notificationService.GetNotificationBySectorId(sectorId));
        }
        [HttpGet("GetNotificationsBySectorId")]
        public async Task<IActionResult> GetNotificationsBySectorId(int sectorId)
        {
            return Ok(await _notificationService.GetNotificationsBySectorId(sectorId));
        }

        [HttpPut("PutNotificationById")]
        public async Task<IActionResult> PutNotificationById(int id, Notification notification)
        {
            return Ok(await _notificationService.PutNotification(id, notification));
        }


        public static async Task SendNotification(int clientId, string message)
        {
            if (_clients.TryGetValue(clientId, out var client))
            {
                await client.WriteAsync($"data: {message}\n\n");
                await client.Body.FlushAsync();
            }
        }
    }

}