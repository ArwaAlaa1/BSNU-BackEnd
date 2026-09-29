using BSNU.Core.Models;
using BSNU.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSNU.Repository.Repositories
{
    public class EventsRepositry :GenericRepository<Events>
    {
        private readonly BSNUDbContext dbContext;

        public EventsRepositry(BSNUDbContext dbContext ): base(dbContext)    
        {
            this.dbContext = dbContext;
        }
    }
}
