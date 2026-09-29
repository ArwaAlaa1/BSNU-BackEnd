using System;
using System.Collections.Generic;
using System.Text;

namespace BSNU.Core.Models
{
    public class Events : BaseEntity
    {
        public string TitleEn { get; set; } = null!;
        public string? TitleAr { get; set; }

        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }

        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public string? Location { get; set; }

        public string? ImagePath { get; set; }

        public bool IsPublished { get; set; }
    }
}
