using FluentValidation;
using SimpleBlog.DAL.DTO;
using System.Data;

namespace SimpleBlog.Business.Validations
{
    public class AddPostDTOValidator:AbstractValidator<AddPostDTO>
    {
        public AddPostDTOValidator()
        {
            RuleFor(post => post.Title).NotEmpty().WithMessage("Başlık boş olamaz.");
            RuleFor(post => post.Title).Length(10, 25).WithMessage("Başlık en az 10,en fazla 25 karakter olmalı.");
            RuleFor(post => post.Categories).NotEmpty().WithMessage("Kategori boş olamaz.");
        }
    }
}
