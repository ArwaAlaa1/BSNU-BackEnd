using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class News : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public int? ProgramId { get; set; }
        public Program Program { get; set; }

       
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }

}
