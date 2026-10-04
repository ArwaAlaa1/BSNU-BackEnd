using System;
using System.Collections.Generic;
using System.Text;

namespace BSNU.Core.Models
{
    public class FAQ :BaseEntity
    {
        public string QuestionEn { get; set; } = null!;
        public string? QuestionAr { get; set; }

        public string AnswerEn { get; set; } = null!;
        public string? AnswerAr { get; set; }

        public int DisplayOrder { get; set; }

        public bool IsActive { get; set; }
    }
}
