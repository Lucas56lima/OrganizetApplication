using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Organizet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskForUserController : ControllerBase
    {
        private readonly ITaskForUserService _service;
        public TaskForUserController(ITaskForUserService service)
        {
            _service = service;
        }
        [HttpPost("RegisterNewTaskForUser")]
        public async Task<IActionResult> PostTaskForUser([FromBody] TaskForUser taskForUser)
        {
            return Ok(await _service.PostTaskForUser(taskForUser));
        }

        [HttpGet("GetAllTasksForUser")]
        public async Task<IActionResult> GetTasksForUser()
        {
            return Ok(await _service.GetTasksForUser());
        }

        [HttpGet("GetTaskForUserById")]
        public async Task<IActionResult> GetTaskForUserById(int idTaskForUser)
        {
            return Ok(await _service.GetTaskForUserById(idTaskForUser));
        }
        [HttpGet("GetTaskForUserByTitle")]
        public async Task<IActionResult> GetTaskForUserByTitle(string titleTaskForUser)
        {
            return Ok(await _service.GetTaskForUserByTitle(titleTaskForUser));
        }
    }
}
