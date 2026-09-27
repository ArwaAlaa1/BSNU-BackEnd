using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class ProgramSchedule
    {
        public int Id { get; set; }

        public int ProgramId { get; set; }

        public int AcademicYear { get; set; }

        public int? Semester { get; set; }

        public string? CourseName { get; set; }

        public string? CourseCode { get; set; }

        public decimal? CreditHours { get; set; }

        public int DisplayOrder { get; set; }

        public Programs Program { get; set; } = null!;
    }
}
