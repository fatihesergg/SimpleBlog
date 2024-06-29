using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Business;
using SimpleBlog.Business.Service.Abstract;
using SimpleBlog.DAL.DTO;
using SimpleBlog.Entity;
using SimpleBlog.Web.Validations;

namespace SimpleBlog.Web.Controllers
{
    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostController(IMapper mapper,IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
           var result =  _unitOfWork._postService.GetAll();
            return View(result);
        }

        [HttpGet]
        public IActionResult View(int id)
        {
            var result = _unitOfWork._postService.Get(id);
            if(result == null)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] AddPostDTO model)
        {
            var postValidation = _unitOfWork._postService.ValidatePost(model);

            if(!postValidation.IsValid)
            {
                foreach(var err in postValidation.Errors)
                {
                    ModelState.AddModelError("", err.ErrorMessage);
                }
            }

            foreach(var category in model.Categories)
            {
                var categoryValidation = _unitOfWork._categoryService.ValidateCategory(category);
                if (!categoryValidation.IsValid)
                {
                    foreach(var err in categoryValidation.Errors)
                    {
                        ModelState.AddModelError("",err.ErrorMessage);
                    }
                }
            }
            if (ModelState.ErrorCount > 0)
            {
                return View(model);
            }

            Post post = _mapper.Map<Post>(model);
            _unitOfWork._categoryService.ReplaceByExists(post.Categories);


            _unitOfWork._postService.Add(post);
            _unitOfWork.SaveChanges();
            return RedirectToAction("Index","Post");
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
