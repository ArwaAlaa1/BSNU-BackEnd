using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class News : BaseEntity
    {
            public string TitleEn { get; set; } = null!;
            public string? TitleAr { get; set; }

            public string DescriptionEn { get; set; } = null!;
            public string? DescriptionAr { get; set; }

            public string? ImagePath { get; set; }

            public DateTime? PublishedAt { get; set; }

            public bool IsPublished { get; set; }

            public int DisplayOrder { get; set; }
    }

}
