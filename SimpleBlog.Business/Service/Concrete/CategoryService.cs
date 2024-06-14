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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        public void Add(Category category)
        {
            _repository.Add(category);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public void Delete(Category category)
        {
            _repository.Delete(category);
        }

        public Category Get(int id)
        {
            return _repository.Get(id);
        }

        public void Update(Category category)
        {
            _repository.Update(category);
        }
    }
}
