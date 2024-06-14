using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Business.Service.Abstract;
using SimpleBlog.DAL.DTO;
using SimpleBlog.DAL.Models;
using SimpleBlog.Web.Validations;

namespace SimpleBlog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IValidator<AddPostCategoryDTO> _categoryValidator;
        private readonly IValidator<AddPostDTO> _postValidator;
        private readonly IMapper _mapper;

        public PostController(IPostService postService, IValidator<AddPostCategoryDTO> categoryValidator, IValidator<AddPostDTO> postValidator, IMapper mapper)
        {
            _postService = postService;
            _categoryValidator = categoryValidator;
            _postValidator = postValidator;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddPostDTO model)
        {
            var postValidation = _postValidator.Validate(model);

            if(!postValidation.IsValid)
            {
                foreach(var err in postValidation.Errors)
                {
                    ModelState.AddModelError("", err.ErrorMessage);
                }
            }

            foreach(var category in model.Categories)
            {
                var categoryValidation = _categoryValidator.Validate(category);
                if (!categoryValidation.IsValid)
                {
                    foreach(var err in categoryValidation.Errors)
                    {
                        ModelState.AddModelError("",err.ErrorMessage);
                    }
                }
            }

            if(ModelState.ErrorCount > 0)
            {
                return View(model);
            }

            Post post = _mapper.Map<Post>(model);
            _postService.Add(post);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpPost]
        public IActionResult Edit()
        {
            return View();
        }
    }
}
