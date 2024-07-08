using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using SimpleBlog.Entity;
using SimpleBlog.Entity.ViewModels;

namespace SimpleBlog.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {

            var user = await _userManager.FindByEmailAsync(model.Email);
            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Post");
                }
                
            }
            }

            return View(model);
            
        }

        //
        // Already added an admin.
        //[HttpGet]
        //public IActionResult Signup()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public async Task<IActionResult> Signup(SignupViewModel model)
        //{
        //    var user = await _userManager.FindByEmailAsync(model.Email);
        //    if(user != null)
        //    {
        //        return RedirectToAction("Login");
        //    }

        //    var userObj = new User(){UserName=model.UserName, FirstName = model.FirstName, LastName = model.LastName,Email=model.Email };
        //    var result = await _userManager.CreateAsync(userObj, model.Password);
        //    if(!result.Succeeded)
        //    {
        //        foreach(var item in result.Errors)
        //        {
        //            ModelState.AddModelError("", item.Description);
        //        }
        //        return View(model);
        //    }
        //    return RedirectToAction("index", "post");
        //}

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }
            return RedirectToAction("index", "post");
        }
    }
}
