using FluentValidation.Results;
using SimpleBlog.DAL.DTO;
using SimpleBlog.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Business.Service.Abstract
{
    public interface ICategoryService
    {
        public Category Get(int id);
        public Category GetByName(string name);
        public void ReplaceByExists(List<Category> categories);
        public void Add(Category category);
        public void Update(Category category);
        public void Delete(int id);
        public void Delete(Category category);
        public ValidationResult ValidateCategory(AddPostCategoryDTO dto);
    }
}
