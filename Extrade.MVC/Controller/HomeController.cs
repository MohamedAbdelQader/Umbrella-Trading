using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.Security.Claims;
using UmbrellaTrading.Models;

namespace UmbrellaTrading.MVC
{

    public class HomeController : Controller
    {
        private readonly UserManager<User> manager;
        public HomeController(UserManager<User> _manager)
        {
            manager = _manager;
        }
        [Authorize]
        public IActionResult Index()
        {
            if (User.FindFirstValue(ClaimTypes.NameIdentifier) == null)
            {
                var user = manager.FindByIdAsync(User.FindFirstValue(ClaimTypes.NameIdentifier)).Result;
                if (manager.GetRolesAsync(user).Result.FirstOrDefault() == "Vendor") { return RedirectToAction("VendorGet", "Product"); }

                else if (manager.GetRolesAsync(user).Result.FirstOrDefault() == "Admin") { return RedirectToAction("AllUsers", "User"); }
                else return RedirectToAction("SignIn","User");
            }
            else return RedirectToAction("SignIn", "User");
        }
    }
}
