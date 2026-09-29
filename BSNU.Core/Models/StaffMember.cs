using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class StaffMember : IdentityUser
    {
            public string JobTitleAr{ get; set; } = null!;
            public string JobTitleEn { get; set; } = null!;
            public string? DescriptionEn { get; set; }
            public string? DescriptionAr { get; set; }
            public string? BioEn { get; set; }
            public string? BioAr { get; set; }

            public string? ImagePath { get; set; }
            public string? FullName { get; set; }

            public ICollection<Programs> ManagedPrograms { get; set; } = [];
        
    }
}
