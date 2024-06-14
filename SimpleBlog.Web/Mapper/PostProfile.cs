using AutoMapper;
using SimpleBlog.DAL.DTO;
using SimpleBlog.DAL.Models;

namespace SimpleBlog.Web.Mapper
{
    public class PostProfile: Profile
    {
        public PostProfile()
        {
            CreateMap<AddPostDTO, Post>();
        }
    }
}
