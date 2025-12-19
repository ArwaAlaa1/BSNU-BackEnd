using BSNU.Core.Helper;
using BSNU.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Repository.Contract
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
            Task<PagedResult<Category>> GetFilteredAsync(
        Expression<Func<Category, bool>> filter = null,
        int page = 1,
        int pageSize = 5);
    }
}
