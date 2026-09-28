using BSNU.Core.Models;
using BSNU.Core.Repository.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSNU.Service
{
    public class SectorService : ISectorService
    {
        private readonly ISectorRepository _sectorRepository;

        public SectorService(ISectorRepository sectorRepository)
        {
            _sectorRepository = sectorRepository;
        }

        public async Task<IEnumerable<Sector>> GetAllAsync()
        {
            return await _sectorRepository.GetAllSectorsWithDetails();
        }

        public async Task<Sector?> GetByIdAsync(int id)
        {
            return await _sectorRepository.GetSectorById(id);
        }
    }
}
