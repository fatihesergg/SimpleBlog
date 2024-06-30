using AutoMapper;
using SimpleBlog.DAL.DTO;
using SimpleBlog.Entity;

namespace SimpleBlog.Web.Mapper
{
    public class PostProfile: Profile
    {
        public PostProfile()
        {
            CreateMap<AddPostDTO, Post>();
            CreateMap<EditPostDTO, Post>();
        }
    }
}
