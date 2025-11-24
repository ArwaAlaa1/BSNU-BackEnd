using BSNU.Core;
using BSNU.Core.Models;
using BSNU.Repository.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSNU.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BSNUDbContext _db;
  
        private Hashtable _repositories;

        public UnitOfWork(BSNUDbContext db)

        {
            _db = db;
          
            _repositories = new Hashtable();
        }

        public IGenericRepository<T> Repository<T>() where T : BaseEntity
        {
            var key = typeof(T).Name;
            if (!_repositories.ContainsKey(key))
            {
                var repository = new GenericRepository<T>(_db);
                _repositories.Add(key, repository);
            }
            return _repositories[key] as IGenericRepository<T>;
        }

        public async Task<int> SaveAsync()
        {
            return await _db.SaveChangesAsync();

        }
        public void Dispose()
        {
            _db.Dispose();
        }

    
}
}
