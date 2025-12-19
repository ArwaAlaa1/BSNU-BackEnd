using Microsoft.AspNetCore.Mvc.Rendering;

namespace BSNUDashboard.ViewsModels
{
    public class NewsVM
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public int CategoryId { get; set; }
        public int? ProgramId { get; set; }
        public string? Image { get; set; }
        public IFormFile ImageFile { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Programs { get; set; }
    }

}
