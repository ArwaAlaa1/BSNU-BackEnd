using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Models
{
    public class Banner : BaseEntity
    {
        public string Title { get; set; }

        public string ImageUrl { get; set; }

        public int OrderBanner { get; set; }
    }
}
