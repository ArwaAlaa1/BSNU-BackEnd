using BSNU.Core.Models;
using BSNU.Core.Repository.Contract;
using BSNU.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSNU.Repository.Repositories
{
    public class SectorRepository : GenericRepository<Sector>, ISectorRepository
    {
        public SectorRepository(BSNUDbContext db) : base(db)
        {
        }

        public Task<List<Sector>> GetAllSectorsWithDetails()
        {
            var sectors = _db.Sectors
                .Include(d=>d.Dean)
                .Include(s => s.Faculties)
                .ThenInclude(p=>p.Programs)
                .Where(s => !s.IsDeleted)
                .ToListAsync();

            return sectors;
        }

        public Task<Sector> GetSectorById(int id)
        {
            var sector = _db.Sectors
                .Where(s => s.Id == id && !s.IsDeleted)
                .Include(s => s.Faculties)
                .FirstOrDefaultAsync();

            return sector!;
        }
    }
}
