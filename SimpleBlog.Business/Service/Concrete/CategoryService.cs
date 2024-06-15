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
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IValidator<AddPostCategoryDTO> _validator;
        public CategoryService(ICategoryRepository repository, IValidator<AddPostCategoryDTO> validator)
        {
            _repository = repository;
            _validator = validator;
        }

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

        public Category? GetByName(string name)
        {
            return _repository.GetByName(name);
        }

        public void ReplaceByExists(List<Category> categories)
        {
            for (int i = 0; i < categories.Count(); i++)
            {
                Category category = categories[i];
                var isExists = GetByName(category.Name);
                if(isExists is not null)
                {
                    categories[i] = isExists;
                }
            }
        }

        public void Update(Category category)
        {
            _repository.Update(category);
        }

        public ValidationResult ValidateCategory(AddPostCategoryDTO dto)
        {
            var result = _validator.Validate(dto);
            return result;
        }
    }
}
