using SimpleBlog.Business.Service.Abstract;
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
        private IPostRepository _repository;

        public PostService(IPostRepository repository)
        {
            _repository = repository;
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
    }
}
