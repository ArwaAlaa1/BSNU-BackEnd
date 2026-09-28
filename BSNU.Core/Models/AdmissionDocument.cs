using System;
using System.Collections.Generic;
using System.Text;

namespace BSNU.Core.Models
{
    public class AdmissionDocument :BaseEntity
    {
        public int AdmissionRuleId { get; set; }

        public string DescriptionEn { get; set; } = null!;
        public string? DescriptionAr { get; set; }

        public int DisplayOrder { get; set; }

        public AdmissionRule AdmissionRule { get; set; } = null!;
    }
}
