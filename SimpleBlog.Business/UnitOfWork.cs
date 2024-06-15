using FluentValidation;
using SimpleBlog.Business.Service.Abstract;
using SimpleBlog.Business.Service.Concrete;
using SimpleBlog.DAL;
using SimpleBlog.DAL.DTO;
using SimpleBlog.DAL.Repository.Abstract;
using SimpleBlog.DAL.Repository.Concrete;
using SimpleBlog.Business.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Business
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository _categoryRepository { get; }
        public IPostRepository _postRepository { get; }
        public ICategoryService _categoryService { get; }
        public IPostService _postService { get; }
        public IValidator<AddPostDTO> _postValidator { get; }
        public IValidator<AddPostCategoryDTO> _categoryValidator { get; }

        private readonly BlogDbContext _context;
        public UnitOfWork(BlogDbContext context):base()
        {
            _context = context;

            if(this._postValidator == null)
            {
                _postValidator = new AddPostDTOValidator();
            }

            if(this._categoryValidator == null)
            {
                _categoryValidator  = new AddPostCategoryDTOValidator();
            }

            if (this._categoryRepository == null)
            {
                _categoryRepository = new CategoryRepository(context);
            }
            if (this._categoryService == null)
            {
                _categoryService = new CategoryService(_categoryRepository, _categoryValidator);
            }
            if(this._postRepository == null)
            {
                _postRepository = new PostRepository(context);
            }
            if(this._postService == null)
            {
                _postService = new PostService(_postRepository, _postValidator);
            }
            
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
