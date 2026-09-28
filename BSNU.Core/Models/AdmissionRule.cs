using System;
using System.Collections.Generic;
using System.Text;

namespace BSNU.Core.Models
{
    public class AdmissionRule :BaseEntity
    {
        public string NameEn { get; set; } = null!;
        public string? NameAr { get; set; }

        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }

        public int DisplayOrder { get; set; }

        public ICollection<AdmissionDocument> Documents { get; set; } = [];
    }
}
