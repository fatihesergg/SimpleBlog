using FluentValidation;
using SimpleBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Business.Validations
{
    public class PostCategoryValidator : AbstractValidator<Category>
    {
        public PostCategoryValidator()
        {

            RuleFor(category => category.Name).NotEmpty().WithMessage("Kategori ismi boş olamaz");
            RuleFor(category => category.Name).Length(3, 10).WithMessage("Kateogori ismi en az 3, en fazla 10 karakter olmalı.");

        }
    }
}
