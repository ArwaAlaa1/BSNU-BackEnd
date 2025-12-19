using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class Programtabel : Primarykey
    {

        public int CreditsHours { get; set; }

        public int ProgramId { get; set; }  

        public ProgramEntite Program { get; set; }
    }
}
