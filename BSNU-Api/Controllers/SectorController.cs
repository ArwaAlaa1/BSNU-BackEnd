using Microsoft.AspNetCore.Mvc;
using BSNU.Service;
using System.Threading.Tasks;

namespace BSNU_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SectorController : ControllerBase
    {
        private readonly ISectorService _sectorService;

        public SectorController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var sectors = await _sectorService.GetAllAsync();
            return Ok(sectors);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sector = await _sectorService.GetByIdAsync(id);
            if (sector == null) return NotFound();
            return Ok(sector);
        }
    }
}
