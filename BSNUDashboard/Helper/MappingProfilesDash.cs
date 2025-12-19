using AutoMapper;
using BSNU.Core.Models;
using BSNUDashboard.ViewsModels;

namespace BSNUDashboard.Helper
{
    public class MappingProfilesDash:Profile
    {
        public MappingProfilesDash()
        {
            CreateMap<Category, CategoryVM>().ForMember(d => d.Image,
     o => o.MapFrom(s => $"http://localhost:5235//images//Category/{s.Image}")).ReverseMap();
            CreateMap<News, NewsVM>().ReverseMap();
         

        }
    }
}
