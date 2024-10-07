using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Service.Services;

namespace Organizet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskForManySectorsController : Controller
    {
        private readonly ITaskForManySectorService _service;
        private readonly INotificationService _notificationService;
        private readonly IHubContext<SendNotification> _notificationHub;        

        // Construtor tradicional para injeção de dependência
        public TaskForManySectorsController(ITaskForManySectorService service,
                                            INotificationService notificationService,
                                            IHubContext<SendNotification> notificationHub)                                        
        {
            _service = service;
            _notificationService = notificationService;
            _notificationHub = notificationHub;
        }

        [HttpPost("RegisterNewTaskForManySector")]
        public async Task<IActionResult> PostTaskForManySector([FromBody] TaskForManySector taskForManySector)
        {
            var result = await _service.PostTaskForManySector(taskForManySector);
            var message = $"Nota tarefa em grupo criada Id:{taskForManySector.TaskId}";
            await NotificationsController.SendNotification(taskForManySector.SectorId,message);
            var notification = new Notification
            {
                SectorId = result.SectorId,
                Message = message,
                TaskId = taskForManySector.TaskId
            };
            await _notificationService.PostNotification(notification);
            return Ok(result);
        }

        [HttpGet("GetAllTasksForManySector")]
        public async Task<IActionResult> GetTaskForManySectors(int sectorId)
        {
            return Ok(await _service.GetTaskForManySector(sectorId));
        }

        [HttpGet("GetTaskForManySectorByIdTask")]
        public async Task<IActionResult> GetTaskForManySectorByTaskId(int idTask)
        {
            return Ok(await _service.GetTaskForManySectorByTaskId(idTask));
        }

        [HttpGet("GetSectorsByTaskId")]
        public async Task<IActionResult> GetSectorsByTaskId(int idTask)
        {
            return Ok(await _service.GetSectorsByTaskId(idTask));
        }

        [HttpGet("GetTasksForManySectorCompleted")]
        public async Task<IActionResult> GetTasksForManySectorCompleted(int sectorId, DateOnly initialDate, DateOnly endDate)
        {
            return Ok(await _service.GetTasksForManySectorCompleted(sectorId, initialDate, endDate));
        }
    }
}
