using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Organizet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskForManyController : ControllerBase
    {
        private readonly ITaskForManyService _service;
        public TaskForManyController(ITaskForManyService service)
        {
            _service = service;
        }
        [HttpPost("RegisterNewTaskForMany")]
        public async Task<IActionResult> PostTaskForMany([FromBody] TaskForMany taskForMany)
        {
            return Ok(await _service.PostTaskForMany(taskForMany));
        }

        [HttpGet("GetAllTasksForMany")]
        public async Task<IActionResult> GetTasksForMany()
        {
            return Ok(await _service.GetTasksForMany());
        }

        [HttpGet("GetTaskForManyById")]
        public async Task<IActionResult> GetTaskForManyById(int idTaskForMany)
        {
            return Ok(await _service.GetTaskForManyById(idTaskForMany));
        }
        [HttpGet("GetTaskForManyByTitle")]
        public async Task<IActionResult> GetTaskForManyByTitle(string titleTaskForMany)
        {
            return Ok(await _service.GetTaskForManyByTitle(titleTaskForMany));
        }
    }
}
