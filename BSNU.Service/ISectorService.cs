using BSNU.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSNU.Service
{
    public interface ISectorService
    {
        Task<IEnumerable<Sector>> GetAllAsync();
        Task<Sector?> GetByIdAsync(int id);
    }
}
