using BSNU.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSNU.Service
{
    public interface IFacultyService
    {
        Task<IEnumerable<Faculty>> GetAllAsync();
        Task<Faculty?> GetByIdAsync(int id);
    }
}
