using BSNU.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSNU.Core.Repository.Contract
{
    public interface ISectorRepository : IGenericRepository<Sector>
    {
        Task<List<Sector>> GetAllSectorsWithDetails();
        Task<Sector> GetSectorById(int id);
    }
}
