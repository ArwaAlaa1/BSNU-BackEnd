using System.ComponentModel.DataAnnotations;

namespace BSNUDashboard.ViewsModels
{
    public class BannerVM
    {
            public int? Id { get; set; }
            [Required]
            public string Title { get; set; }
            public bool IsActive { get; set; }
            public string? ImageUrl { get; set; }
            public IFormFile? Photo { get; set; }
            [Required]
            public int OrderBanner { get; set; }
        
    }
}
