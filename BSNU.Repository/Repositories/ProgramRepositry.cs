using BSNU.Core.Models;
using BSNU.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Repository.Repositories
{
    public class ProgramRepositry : GenericRepository<ProgramEntite>
    {
        public ProgramRepositry(BSNUDbContext db) : base(db)
        {
        }
    }
}
