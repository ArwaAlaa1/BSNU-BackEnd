using BSNU.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSNU.Core.Repository.Contract
{
    public interface IFacultyRepository : IGenericRepository<Faculty>
    {
        public Task<List<Faculty>> GetAllFacultiesWithDetails();
        public Task<Faculty> GetFacultyById(int id);
    }
}
