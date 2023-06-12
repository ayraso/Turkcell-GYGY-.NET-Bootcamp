using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace TVRS.WebUI.Controllers
{
    [Authorize(Roles = "Admin, User")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var userRole = HttpContext.Session.GetString("UserRole");

            if (userRole == "Admin")
            {
                return RedirectToAction("AdminHomePage");
            }
            else if (userRole == "User")
            {
                return RedirectToAction("UserHomePage");
            }
            else
            {
                return RedirectToAction("Unauthorized");
            }
        }

        [Authorize(Roles = "Admin")]
        public IActionResult AdminHomePage()
        {
            return View();
        }

        [Authorize(Roles = "User")]
        public IActionResult UserHomePage()
        {
            return View();
        }

        public IActionResult Unauthorized()
        {
            return View();
        }

    }
}
