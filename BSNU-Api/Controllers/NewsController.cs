using AutoMapper;
using BSNU.Core;
using BSNU.Core.Models;
using BSNU.Core.Repository.Contract;
using BSNU_Api.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSNU_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly INewsRepository _newsRepository;

        public NewsController(IUnitOfWork unitOfWork, IMapper mapper,INewsRepository newsRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _newsRepository = newsRepository;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NewsDto>>> GetAll()
        {
            var news = await _newsRepository
                .GetAllNewsWithDetails();

            var result = _mapper.Map<IEnumerable<NewsDto>>(news);

            return Ok(result);
        }

      
        [HttpGet("{id}")]
        public async Task<ActionResult<NewsDto>> GetById(int id)
        {
            var news = await _unitOfWork.Repository<News>()
                .GetByIdAsync(id);

            if (news == null)
                return NotFound(new { message = "News not found" });

            return Ok(_mapper.Map<NewsDto>(news));
        }
    }
}
