using BSNU.Core.Helper;
using BSNU.Core.Models;
using BSNU.Core.Repository.Contract;
using BSNU.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Repository.Repositories
{
    public class CategoryRepository: GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(BSNUDbContext bSNUDbContext):base(bSNUDbContext)
        {
            
        }
        public async Task<PagedResult<Category>> GetFilteredAsync(
   Expression<Func<Category, bool>> filter = null,
   int page = 1,
   int pageSize = 5)
        {
            IQueryable<Category> query = _db.Set<Category>();

            if (filter != null)
                query = query.Where(filter);

            var totalItems = await query.CountAsync();

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PagedResult<Category>
            {
                Items = items,
                PageNumber = page,
                PageSize = pageSize,
                TotalItems = totalItems,
                TotalPages = (int)Math.Ceiling((double)totalItems / pageSize)
            };
        }
    }
}
