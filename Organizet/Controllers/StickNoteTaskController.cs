using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Organizet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StickNoteTaskController : Controller
    {
        private readonly IStickNoteTaskService _service;
        public StickNoteTaskController(IStickNoteTaskService service)
        {
            _service = service;
        }
        [HttpPost("RegisterStickNoteTask")]
        public async Task<IActionResult> PostStickNoteTask([FromBody] StickNoteTaskForMany stickNoteTask)
        {
            return Ok(await _service.PostStickNoteTask(stickNoteTask));
        }

        [HttpGet("GetStickNoteByTaskId")]
        public async Task<IActionResult> GetStickNoteByTaskId(int id)
        {
            return Ok(await _service.GetStickNoteByTaskId(id));
        }

        [HttpGet("GetStickNoteById")]
        public async Task<IActionResult> GetStickNoteById(int id)
        {
            return Ok(await _service.GetStickNoteById(id));
        }

        [HttpGet("GetStickNotesTasksByStatus")]
        public async Task<IActionResult> GetStickNoteTaskForStatus(int taskId,string status)
        {
            return Ok(await _service.GetStickNoteTaskForStatus(taskId,status));
        }
        [HttpGet("GetStickNotesTasksByStatusAndSector")]
        public async Task<IActionResult> GetStickNoteTaskForStatusAndSector(int taskId, string status, int sectorId)
        {
            return Ok(await _service.GetStickNoteTaskForStatusAndSector(taskId, status,sectorId));
        }

        [HttpGet("GetAllStickNotes")]
        public async Task<IActionResult> GetAllStickNoteTask()
        {
            return Ok(await _service.GetAllStickNote());
        }
        [HttpPut("PutStickNotesTasksById")]
        public async Task<IActionResult> PutStickNoteById(int id,StickNoteTaskForMany newStickNote)
        {
            return Ok(await _service.PutStickNoteById(id,newStickNote));
        }
    }
}
