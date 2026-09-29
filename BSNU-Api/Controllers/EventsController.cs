using BSNU.Core.Models;
using BSNU.Repository.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BSNU_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly EventsRepositry _EventsRepositry;

        public EventsController(EventsRepositry eventsRepositry)
        {
            _EventsRepositry = eventsRepositry;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Events>>> GetAllEvents()
        {
            var events = await _EventsRepositry.GetAllAsync();
            return Ok(events);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Events>> GetEventById(int id)
        {
            var eventItem = await _EventsRepositry.GetByIdAsync(id);
            if (eventItem == null)
            {
                return NotFound();
            }
            return Ok(eventItem);
        }
    }
}
