using System;
using System.Collections.Generic;
using System.Text;

namespace BSNU.Core.Models
{
    public class TuitionFees :BaseEntity
    {
      

        public int ProgramId { get; set; }

        public string AcademicYear { get; set; } = null!;

        public int Level { get; set; }

        public decimal Amount { get; set; }

        public string Currency { get; set; } = "EGP";

        public Programs Program { get; set; } = null!;
    }
}
