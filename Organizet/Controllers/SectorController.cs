using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Organizet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectorController : Controller
    {
        private readonly ISectorService _sectorService;
        public SectorController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        [HttpGet("GetAllSectors")]
        public async Task<IActionResult> GetAllSectors()
        {
            return Ok(await _sectorService.GetAllSectors());
        }

        [HttpGet("GetSectorByName")]
        public async Task<IActionResult> GetSectorByName(string name)
        {
            return Ok(await _sectorService.GetSectorByName(name));
        }

        [HttpGet("GetSectorById")]
        public async Task<IActionResult> GetSectorById(int id)
        {
            return Ok(await _sectorService.GetSectorById(id));
        }
    }
}
