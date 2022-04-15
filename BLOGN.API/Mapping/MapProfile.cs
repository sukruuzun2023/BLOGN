using AutoMapper;
using BLOGN.Models;
using BLOGN.Models.Dto;

namespace BLOGN.API.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Category,CategoryDto>().ReverseMap(); // Reversemap Category ve CategoryDto birbirleri içersinden veri almalarını sağlar yazmasaydık sadece category category dto maplenebilirdi
            CreateMap<Article,ArticleDto>().ReverseMap();// article oluşturduktan sonra yazıyoruz
        }
    }
}
