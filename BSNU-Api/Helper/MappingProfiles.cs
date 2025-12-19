using AutoMapper;
using BSNU.Core.Models;
using BSNU_Api.Dtos;

namespace BSNU_Api.Helper
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<News, NewsDto>()
 .ForMember(d => d.CategoryName,
     o => o.MapFrom(s => s.Category.Name))
 .ForMember(d => d.ImageUrl,
     o => o.MapFrom(s => $"http://localhost:5028//images//News/{s.ImageUrl}"))
 .ForMember(d => d.ProgramName,
     o => o.MapFrom(s => s.Program != null ? s.Program.Name : null));

        }

    }
}
