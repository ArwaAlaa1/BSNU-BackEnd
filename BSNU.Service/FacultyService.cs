using BSNU.Core.Models;
using BSNU.Core.Repository.Contract;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BSNU.Service
{
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _facultyRepository;

        public FacultyService(IFacultyRepository facultyRepository)
        {
            _facultyRepository = facultyRepository;
        }

        public async Task<IEnumerable<Faculty>> GetAllAsync()
        {
            return await _facultyRepository.GetAllFacultiesWithDetails();
        }

        public async Task<Faculty?> GetByIdAsync(int id)
        {
            return await _facultyRepository.GetFacultyById(id);
        }
    }
}
