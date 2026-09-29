using BSNU.Core.Models;

namespace BSNU_Api.Dtos
{
    public class TuitionFeesDTO
    {


        public string ProgramName   { get; set; } = null!;

        public string SectorName { get; set; } = null!;

        public ICollection<string> Fees { get; set; } = [];
    }
}
