using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        [ForeignKey("Program")]
        public int Programid { get; set; }
        public Programs Program { get; set; } = null!;

       
    }
}
