using BSNU.Core.Models;

namespace BSNU_Api.Dtos
{
    public class BannerDto:BaseEntity
    {
            public string Title { get; set; }
            public string ImageUrl { get; set; }
            public int Order { get; set; }
        
    }
}
