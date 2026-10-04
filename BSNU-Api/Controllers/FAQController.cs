using BSNU.Core.Repository.Contract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSNU_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FAQController : ControllerBase
    {
        private readonly IFAQRepository _repository;

        public FAQController(IFAQRepository repository)
        {
            _repository = repository;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllFAQs()
        {
            var faqs = await _repository.GetAllAsync();
            if (faqs.Count() == 0)
            {
                return NotFound();
            }
            return Ok(faqs);
        }
    }
}
