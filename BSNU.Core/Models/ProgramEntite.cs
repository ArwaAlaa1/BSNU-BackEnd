using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class ProgramEntite:BaseEntity
    {
        public string Name { get; set; }

        public string Mission { get; set; }

        public string Vision { get; set; }

        public string Goals { get; set; }

        public string Duration { get; set; }

        public string jopTitel { get; set; }

        public string CreditHour { get; set; }

        public string AcadamicDegree { get; set; }

        public string NumberOfStudents { get; set; }

       
        public string UserId { get; set; }

        public AppUser User { get; set; }

        public ICollection<Programtabel> Programtabels { get; set; } = new List<Programtabel>();
    }
}
