using SimpleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.DAL.Repository.Abstract
{
    public interface ICategoryRepository
    {
        public Category Get(int id);
        public Category? GetByName(string name);
        public void Add(Category category);
        public void Update(Category category);
        public void Delete(int id);
        public void DeleteByName(string name);
        public void Delete(Category category);
    }
}
