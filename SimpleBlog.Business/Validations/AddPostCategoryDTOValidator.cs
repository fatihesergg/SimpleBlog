using FluentValidation;
using SimpleBlog.DAL.DTO;

namespace SimpleBlog.Business.Validations
{
    public class AddPostCategoryDTOValidator:AbstractValidator<AddPostCategoryDTO>
    {
        public AddPostCategoryDTOValidator()
        {
            RuleFor(category => category.Name).NotEmpty().WithMessage("Kategori ismi boş olamaz");
            RuleFor(category => category.Name).Length(3, 10).WithMessage("Kateogori ismi en az 3, en fazla 10 karakter olmalı.");
        }
    }
}
