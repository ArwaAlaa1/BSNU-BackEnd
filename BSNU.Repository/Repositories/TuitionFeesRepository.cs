using BSNU.Core.Models;
using BSNU.Core.Repository.Contract;
using BSNU.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSNU.Repository.Repositories
{
     public class TuitionFeesRepository :GenericRepository<TuitionFees> , ITuitionFeesRepository
    {
        private readonly BSNUDbContext _dbcontext;
        public TuitionFeesRepository(BSNUDbContext dbcontext): base(dbcontext)
        {
            _dbcontext = dbcontext;
        }
        
        public async Task<IReadOnlyList<TuitionFees>?> GetAllTuitionFeesWithProgramNameAsync()
        {
            
            var AllTuitionFees = await _dbcontext.TuitionFee.Include(x => x.Program)
                                                             .ThenInclude(p => p.sector)
                                                             .ToListAsync();
            return AllTuitionFees ;
        }
    }
}
