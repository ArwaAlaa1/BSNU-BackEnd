using BSNU.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BSNU_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService _facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _facultyService.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var item = await _facultyService.GetByIdAsync(id);
            if (item == null) return NotFound();
            return Ok(item);
        }
    }
}
