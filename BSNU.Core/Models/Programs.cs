using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class Programs:BaseEntity
    {

        public int FacultyId { get; set; }

        public string? ProgramManagerId { get; set; }

        public string NameEn { get; set; } = null!;
        public string? NameAr { get; set; }

        public string? DescriptionEn { get; set; }
        public string? DescriptionAr { get; set; }

        public string? DurationEn { get; set; }
        public string? DurationAr { get; set; }
        public string? StudySystemEn { get; set; }
        public string? StudySystemAr { get; set; }
        public decimal? CreditHoursEn { get; set; }
        public decimal? CreditHoursAr { get; set; }
        public string? AcademicDegreeEn { get; set; }
        public string? AcademicDegreeAr { get; set; }
        public int? StudentsCount { get; set; }

        public string? JobTitlesEn { get; set; }
        public string? JobTitlesAr { get; set; }

        public string? MissionEn { get; set; }
        public string? MissionAr { get; set; }
        public string? VisionEn { get; set; }
        public string? VisionAr { get; set; }
        public string? VideoPath { get; set; }
        public Faculty Faculty { get; set; } = null!;

        public StaffMember? ProgramManager { get; set; }
        public ICollection<ProgramImage> Images { get; set; } = [];
        public ICollection<ProgramGoal> Goals { get; set; } = [];
        public ICollection<ProgramBeneficiary> Beneficiaries { get; set; } = [];
        public ICollection<ProgramRequirement> Requirements { get; set; } = [];
        public ICollection<ProgramSchedule> Schedules { get; set; } = [];
        //public ICollection<ProgramEvent> Events { get; set; } = [];
        //public ICollection<TuitionFee> TuitionFees { get; set; } = [];
    }
}
