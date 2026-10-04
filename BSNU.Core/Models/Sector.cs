using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class Sector:BaseEntity
    {
        public string NameEn { get; set; } = null!;
        public string? NameAr { get; set; }
        public string SubTitleAr { get; set; } = null!;
        public string SubTitleEn { get; set; } = null!;
        public string Image { get; set; }
        public string? DeanId { get; set; }
        public StaffMember? Dean { get; set; }
        public ICollection<Faculty> Faculties { get; set; } = [];
    }
}
