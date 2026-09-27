using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class Faculty
    {
        public int Id { get; set; }

        public int SectorId { get; set; }

        public string NameEn { get; set; } = null!;
        public string? NameAr { get; set; }

        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }

        public int? DeanId { get; set; }

        public Sector Sector { get; set; } = null!;

        public StaffMember? Dean { get; set; }

        public ICollection<Programs> Programs { get; set; } = [];
        public ICollection<StaffMember> StaffMembers { get; set; } = [];
    }
}
