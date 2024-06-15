using FluentValidation;
using FluentValidation.Results;
using SimpleBlog.Business.Service.Abstract;
using SimpleBlog.DAL.DTO;
using SimpleBlog.DAL.Models;
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
        private readonly IValidator<AddPostDTO> _validator;

        public PostService(IPostRepository repository, IValidator<AddPostDTO> validator)
        {
            _repository = repository;
            _validator = validator;
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
            _repository.Update(post);
        }

        public ValidationResult ValidatePost(AddPostDTO dto)
        {
            var result = _validator.Validate(dto);
            return result;
        }

    }
}
