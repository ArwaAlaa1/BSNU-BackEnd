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
  
        private Hashtable _Repos;

        public UnitOfWork(BSNUDbContext db)

        {
            _db = db;

            _Repos = new Hashtable();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
            var key = typeof(TEntity).Name;

            if (!_Repos.ContainsKey(key))
            {
                var repo = new GenericRepository<TEntity>(_db);
                _Repos.Add(key,repo);
            }

            
            return _Repos[key] as IGenericRepository<TEntity>;
        }
        public async Task<int> CompleteAsync()
        {
            return await _db.SaveChangesAsync();
        }
        public void Dispose()
        {
            _db.Dispose();
        }

    
}
}
