using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class Sector
    {
        public int Id { get; set; }

        public string NameEn { get; set; } = null!;
        public string? NameAr { get; set; }

        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }

        public ICollection<Faculty> Faculties { get; set; } = [];
    }
}
