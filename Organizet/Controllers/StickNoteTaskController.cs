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
        public async Task<IActionResult> PostStickNoteTask([FromBody] StickNoteTask stickNoteTask)
        {
            return Ok(await _service.PostStickNoteTask(stickNoteTask));
        }

        [HttpGet("GetStickNotesTasksById")]
        public async Task<IActionResult> GetStickNoteByTaskId(int id)
        {
            return Ok(await _service.GetStickNoteByTaskId(id));
        }

        [HttpGet("GetStickNotesTasksByStatus")]
        public async Task<IActionResult> GetStickNoteTaskForStatus(string status)
        {
            return Ok(await _service.GetStickNoteTaskForStatus(status));
        }
        [HttpGet("GetAllStickNotes")]
        public async Task<IActionResult> GetAllStickNoteTask()
        {
            return Ok(await _service.GetAllStickNote());
        }
        [HttpPut("PutStickNotesTasksById")]
        public async Task<IActionResult> PutStickNoteById(int id,StickNoteTask newStickNote)
        {
            return Ok(await _service.PutStickNoteById(id,newStickNote));
        }
    }
}
