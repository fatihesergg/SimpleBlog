using AutoMapper;
using SimpleBlog.DAL.DTO;
using SimpleBlog.DAL.Models;

namespace SimpleBlog.Web.Mapper
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<AddPostCategoryDTO, Category>();
        }
    }
}
