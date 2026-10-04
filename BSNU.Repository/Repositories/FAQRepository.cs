using BSNU.Core.Models;
using BSNU.Core.Repository.Contract;
using BSNU.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSNU.Repository.Repositories
{
    public class FAQRepository : GenericRepository<FAQ>, IFAQRepository
    {

        public FAQRepository(BSNUDbContext dbContext) : base(dbContext)
        {
            
        }
    }
}
