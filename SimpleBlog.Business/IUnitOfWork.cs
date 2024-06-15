using FluentValidation;
using SimpleBlog.Business.Service.Abstract;
using SimpleBlog.DAL.DTO;
using SimpleBlog.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Business
{
    public interface IUnitOfWork
    {
        public ICategoryRepository _categoryRepository { get; }
        public IPostRepository _postRepository { get; }
        public ICategoryService _categoryService { get; }
        public IPostService _postService { get; }
        public IValidator<AddPostDTO> _postValidator { get; }
        public IValidator<AddPostCategoryDTO> _categoryValidator { get; }
        public void SaveChanges();
    }
}
