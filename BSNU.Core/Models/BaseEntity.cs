using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class BaseEntity :Primarykey
    {
     

        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime ModifiedDate { get; set; } 

        public bool IsDeleted { get; set; } = false;
        public bool IsActive { get; set; } = true;
    }
}
