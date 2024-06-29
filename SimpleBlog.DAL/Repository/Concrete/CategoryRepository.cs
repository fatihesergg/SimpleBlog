using SimpleBlog.Entity;
using SimpleBlog.DAL.Repository.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.DAL.Repository.Concrete
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BlogDbContext _context;

        public CategoryRepository(BlogDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
        }

        public void Delete(int id)
        {

            Category category = Get(id);
            if ( category  is not null)
            {
                _context.Categories.Remove(category);
            }
        }

        public void Delete(Category category)
        {
            
            _context.Categories.Remove(category);
        }

        public void DeleteByName(string name)
        {
            var result = _context.Categories.Where(category => category.Name == name).FirstOrDefault();
            if (result is not null)
            {
                _context.Categories.Remove(result);
            }
        }

        public Category Get(int id)
        {
            var result = _context.Categories.Find(id);
            return result;
        }

        public Category? GetByName(string name)
        {
            var result = _context.Categories.Where(category => category.Name == name).FirstOrDefault();
            return result;
        }

        public void Update(Category category)
        {
            _context.Categories.Update(category);
        }
    }
}
