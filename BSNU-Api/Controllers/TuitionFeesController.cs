using BSNU.Core.Repository.Contract;
using BSNU_Api.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSNU_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TuitionFeesController : ControllerBase
    {
        public readonly ITuitionFeesRepository _tuitionFeesRepository;
        public TuitionFeesController(ITuitionFeesRepository tuitionFeesRepository)
        {
            _tuitionFeesRepository = tuitionFeesRepository;
        }




        //[HttpGet]
        //public async Task<ActionResult<IReadOnlyList<TuitionFeesDTO>>> GetAllProduct()
        //{
        //    var result = await _tuitionFeesRepository.GetAllTuitionFeesWithProgramNameAsync();

        //    var TuitionFeesDTO = result.Select(x => new TuitionFeesDTO
        //    {
        //        ProgramName = x.Program!.NameAr,
        //        SectorName = x.Program.sector.NameAr,
        //        Fees = x.Program.TuitionFees.Select(f => f.Amount.ToString()).ToList()
        //    }).ToList();

        //    if (TuitionFeesDTO == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(TuitionFeesDTO);

        //}

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<TuitionFeesDTO>>> GetAllTuitionFees()
        {
            var tuitionFees = await _tuitionFeesRepository
                .GetAllTuitionFeesWithProgramNameAsync();

            if (tuitionFees is null || !tuitionFees.Any())
                return NotFound();

            var result = tuitionFees
                .Where(x => x.Program is not null)
                .Select(x => new TuitionFeesDTO
                {
                    ProgramName = x.Program!.NameAr,
                    SectorName = x.Program.sector!.NameAr,
                    Fees = x.Program.TuitionFees
                        .Select(f => f.Amount.ToString())
                        .ToList()
                })
                .ToList();

            return Ok(result);
        }
    }
}
