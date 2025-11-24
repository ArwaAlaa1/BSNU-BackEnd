using BSNU.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Core
{
    public interface IUnitOfWork : IDisposable
    {

      

        IGenericRepository<T> Repository<T>() where T : BaseEntity;
        Task<int> SaveAsync();

    }
}
