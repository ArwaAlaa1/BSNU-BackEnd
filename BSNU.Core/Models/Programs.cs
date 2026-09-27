using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class Programs
    {
        public int Id { get; set; }

        public int FacultyId { get; set; }

        public int? ProgramManagerId { get; set; }

        public string NameEn { get; set; } = null!;
        public string? NameAr { get; set; }

        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }

        public string? Duration { get; set; }

        public string? StudySystem { get; set; }

        public decimal? CreditHours { get; set; }

        public string? AcademicDegree { get; set; }

        public int? StudentsCount { get; set; }

        public string? JobTitles { get; set; }

        public string? Mission { get; set; }

        public string? Vision { get; set; }

        public string? ImagePath { get; set; }

        public Faculty Faculty { get; set; } = null!;

        public StaffMember? ProgramManager { get; set; }

        public ICollection<ProgramGoal> Goals { get; set; } = [];
        public ICollection<ProgramBeneficiary> Beneficiaries { get; set; } = [];
        public ICollection<ProgramRequirement> Requirements { get; set; } = [];
        public ICollection<ProgramSchedule> Schedules { get; set; } = [];
        //public ICollection<ProgramEvent> Events { get; set; } = [];
        //public ICollection<TuitionFee> TuitionFees { get; set; } = [];
    }
}
