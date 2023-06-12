using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TVRS.Application.DTOs.Responses;
using TVRS.Application.Services;
using TVRS.WebUI.Extensions;
using TVRS.WebUI.Models;

namespace TVRS.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginUser loginUser)
        {
            var user = await _userService.ValidateUserForLoginAsync(loginUser.Tin, loginUser.Password);
            if (user != null)
            {
                var claims = new List<Claim>
                {
                    new Claim("Id", user.Id.ToString()), 
                    new Claim(ClaimTypes.Role, user.Role) 
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                await HttpContext.SignInAsync(claimsPrincipal);

                HttpContext.Session.SetString("UserId", user.Id.ToString());
                HttpContext.Session.SetString("UserRole", user.Role);

                return RedirectToAction("Index", "User", new { preserveSession = true });
            }
            else
            {
                ViewBag.ErrorMessage = "Geçersiz TC Kimlik Numarası veya Şifre";
                return View("Index", loginUser);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync("CustomAuthScheme");

            return RedirectToAction("Index", "User");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            int userId = HttpContext.GetUserId();
            DisplayUserResponse user = await _userService.GetUserInfoByUserIdAsync(userId);

            return View(user);
        }
    }
}
