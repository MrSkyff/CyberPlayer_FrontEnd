using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_FrontEnd.Areas.Identity.Interfaces;
using MVC_FrontEnd.Areas.Identity.Models;
using MVC_FrontEnd.Areas.Identity.ViewModels;
using System.Security.Claims;

namespace MVC_FrontEnd.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class HomeController : Controller
    {
        private readonly IUser userRepository;

        public HomeController(IUser userRepository)
        {
            this.userRepository = userRepository;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(UserModel model)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var claims = await userRepository.GetClaimsAsync(model);
                if (claims != null)
                {
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claims));
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email not exist");
                }

            }

            return View(model);
        }

        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }
    }
}
