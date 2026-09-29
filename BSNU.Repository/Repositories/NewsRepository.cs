using BSNU.Core.Models;
using BSNU.Core.Repository.Contract;
using BSNU.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Repository.Repositories
{
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        public NewsRepository(BSNUDbContext bSNUDbContext):base(bSNUDbContext)
        {
            
        }
        public Task<List<News>> GetAllNewsWithDetails()
        {
           var newsWithDetails =  _db.News
                .ToListAsync();
            return newsWithDetails;
        }

        public Task<News> GetNewsById(int id)
        {
            var news = _db.News
                .Where( i=>i.Id==id)
                .FirstOrDefaultAsync();
            return news;
        }
    }
}
