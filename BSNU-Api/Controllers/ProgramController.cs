using BSNU.Core;
using BSNU.Core.Models ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSNU_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgramController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProgramController(IUnitOfWork unitOfWork )
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProgramEntite>>> GetallProgram() 
        {
            var Programs = await _unitOfWork.Repository<ProgramEntite>().GetAllAsync();

            return Ok(Programs);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProgramEntite>> GetProgram(int id)
        {
            var Program = await _unitOfWork.Repository<ProgramEntite>().GetByIdAsync(id);

            return Ok(Program);
        }

    }
}
