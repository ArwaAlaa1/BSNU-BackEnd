using BSNU.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core.Repository.Contract
{
    public  interface INewsRepository:IGenericRepository<News>
    {
        public Task<List<News>> GetAllNewsWithDetails();
        public Task<News> GetNewsById(int id);
    }
}
