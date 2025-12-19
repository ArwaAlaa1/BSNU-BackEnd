using AutoMapper;
using BSNU.Core;
using BSNU.Core.Repository.Contract;
using BSNU_Api.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSNU_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannerController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IBannerRepository _bannerRepository;

        public BannerController(IUnitOfWork unitOfWork, IMapper mapper, IBannerRepository bannerRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _bannerRepository = bannerRepository;
        }

        // Get All Active Banners Ordered
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BannerDto>>> GetAllBanners()
        {
            try
            {
                var banners = await _bannerRepository.GetAllBannersSortedAsync();
                if (banners == null || !banners.Any())
                {
                    return NotFound("");
                }

                var mappedBanners = _mapper.Map<IEnumerable<BannerDto>>(banners);
                return Ok("");
            }
            catch (Exception ex)
            {

                return StatusCode(500, new { message = "Not Banners Exsist ", error = ex.Message });
            }
        }
    }
}
