using System;
using System.Collections.Generic;
using System.Text;

namespace BSNU.Core.Models
{
    public class ProgramImage : BaseEntity
    {
        public int ProgramId { get; set; }

        public string ImagePath { get; set; } = null!;

        public int DisplayOrder { get; set; }

        public bool IsMain { get; set; }

        public Programs Program { get; set; } = null!;
    }
}
