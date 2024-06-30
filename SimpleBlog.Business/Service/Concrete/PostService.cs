using FluentValidation;
using FluentValidation.Results;
using SimpleBlog.Business.Service.Abstract;
using SimpleBlog.DAL.DTO;
using SimpleBlog.Entity;
using SimpleBlog.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Business.Service.Concrete
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _repository;
        private readonly IValidator<AddPostDTO> _dtoValidator;
        private readonly IValidator<Post> _postValidator;

        public PostService(IPostRepository repository, IValidator<AddPostDTO> dtoValidator, IValidator<Post> postValidator)
        {
            _repository = repository;
            _dtoValidator = dtoValidator;
            _postValidator = postValidator;
        }

        public void Add(Post post)
        {
            _repository.Add(post);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Delete(Post post)
        {
            
            _repository.Delete(post);
        }

        public Post Get(int id)
        {
            
            return _repository.Get(id);
        }

        public List<Post> GetAll()
        {
            return _repository.GetAll();
        }

        public void Update(Post post)
        {
            var query = _repository.Get(post.Id);
            if(query != null)
            {
                _repository.Update(post);
            }
        }

        public ValidationResult ValidatePost(AddPostDTO dto)
        {
            var result = _dtoValidator.Validate(dto);
            return result;
        }

        public ValidationResult ValidatePost(Post model)
        {
            var result = _postValidator.Validate(model);
            return result;
        }

    }
}
