using AutoMapper;
using SimpleBlog.DAL.DTO;
using SimpleBlog.Entity;

namespace SimpleBlog.Web.Mapper
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<AddPostCategoryDTO, Category>();
            CreateMap<AddPostCategoryDTO, Category>().ReverseMap();
        }
    }
}
