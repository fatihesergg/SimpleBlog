using FluentValidation;
using SimpleBlog.Business.Service.Abstract;
using SimpleBlog.DAL.DTO;
using SimpleBlog.DAL.Repository.Abstract;
using SimpleBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Business
{
    public interface IUnitOfWork
    {
        public ICategoryService _categoryService { get; }
        public IPostService _postService { get; }
        public IValidator<AddPostDTO> _postDTOValidator { get; }
        public IValidator<AddPostCategoryDTO> _categoryDTOValidator { get; }
        public IValidator<Post> _postValidator { get; }
        public IValidator<Category> _categoryValidator { get; }
        public void SaveChanges();
    }
}
