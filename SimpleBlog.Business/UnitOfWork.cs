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
using SimpleBlog.Entity;

namespace SimpleBlog.Business
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICategoryRepository _categoryRepository { get; }
        public IPostRepository _postRepository { get; }
        public ICategoryService _categoryService { get; }
        public IPostService _postService { get; }
        public IValidator<AddPostDTO> _postDTOValidator { get; }
        public IValidator<AddPostCategoryDTO> _categoryDTOValidator { get; }
        public IValidator<Post> _postValidator { get; }
        public IValidator<Category> _categoryValidator { get; }

        private readonly BlogDbContext _context;
        public UnitOfWork(BlogDbContext context):base()
        {
            _context = context;
            if(this._postValidator == null)
            {
                _postValidator = new PostValidator();
            }
            if (this._categoryValidator == null)
            {
                _categoryValidator = new PostCategoryValidator();
            }

            if(this._postDTOValidator == null)
            {
                _postDTOValidator = new AddPostDTOValidator();
            }

            if(this._categoryDTOValidator == null)
            {
                _categoryDTOValidator  = new AddPostCategoryDTOValidator();
            }

            if (this._categoryRepository == null)
            {
                _categoryRepository = new CategoryRepository(context);
            }
            if (this._categoryService == null)
            {
                _categoryService = new CategoryService(_categoryRepository, _categoryDTOValidator);
            }
            if(this._postRepository == null)
            {
                _postRepository = new PostRepository(context);
            }
            if(this._postService == null)
            {
                _postService = new PostService(_postRepository, _postDTOValidator,_postValidator);
            }
            
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
