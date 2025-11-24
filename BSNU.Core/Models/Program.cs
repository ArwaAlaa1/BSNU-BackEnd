using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class Program:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }

        public AppUser User { get; set; }
    }
}
