using BSNU.Core.Models;
using BSNU.Core.Repository.Contract;
using BSNU.Repository.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BSNU.Repository.Repositories
{
    public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(BSNUDbContext db) : base(db)
        {
        }

        public Task<List<Faculty>> GetAllFacultiesWithDetails()
        {
            var faculties = _db.Faculties
                .Include(f => f.Sector)
                .Include(f => f.Dean)
                .Include(f => f.Programs)
                .Include(f => f.StaffMembers)
                .Where(f => !f.IsDeleted)
                .ToListAsync();

            return faculties;
        }

        public Task<Faculty> GetFacultyById(int id)
        {
            var faculty = _db.Faculties
                .Where(f => f.Id == id && !f.IsDeleted)
                .Include(f => f.Sector)
                .Include(f => f.Dean)
                .Include(f => f.Programs)
                .Include(f => f.StaffMembers)
                .FirstOrDefaultAsync();

            return faculty!;
        }
    }
}
