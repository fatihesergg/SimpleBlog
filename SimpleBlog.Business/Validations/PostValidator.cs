using FluentValidation;
using SimpleBlog.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlog.Business.Validations
{
    public class PostValidator:AbstractValidator<Post>
    {
        public PostValidator()
        {
            {
                RuleFor(post => post.Title).NotEmpty().WithMessage("Başlık boş olamaz.");
                RuleFor(post => post.Title).Length(10, 25).WithMessage("Başlık en az 10,en fazla 25 karakter olmalı.");
                RuleFor(post => post.Categories).NotEmpty().WithMessage("Kategori boş olamaz.");
            }
        }
    }
}
