using BSNU.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BSNU.Core.Repository.Contract
{
    public  interface ITuitionFeesRepository : IGenericRepository<TuitionFees>
    {
        public Task<IReadOnlyList<TuitionFees>?> GetAllTuitionFeesWithProgramNameAsync();
    }
}
