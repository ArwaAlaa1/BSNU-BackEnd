using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class ProgramGoal
    {
        public int Id { get; set; }

        public int ProgramId { get; set; }

        public string Description { get; set; } = null!;

        public int DisplayOrder { get; set; }

        public Programs Program { get; set; } = null!;
    }
}
