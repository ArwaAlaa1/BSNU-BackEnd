using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class StaffMember
    {
            public int Id { get; set; }

            public string UserId { get; set; } = null!;

            public string JobTitle { get; set; } = null!;
            public string? DescriptionEn { get; set; }
            public string? DescriptionAr { get; set; }
            public string? BioEn { get; set; }
            public string? BioAr { get; set; }

            public string? ImagePath { get; set; }

            public AppUser User { get; set; } = null!;

            public ICollection<Programs> ManagedPrograms { get; set; } = [];
        
    }
}
