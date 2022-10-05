using UmbrellaTrading.MVC.Helpers;
using UmbrellaTrading.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using System.Security.Claims;
using UmbrellaTrading.ViewModels;

namespace UmbrellaTrading.MVC
{
    public class UseAsVendorController : Controller
    {
        public readonly UnitOfWork unit;
        public readonly UserRepository UserRep;
        public readonly RoleRepository role;

        public UseAsVendorController(UserRepository _UserRep, UnitOfWork _unit, RoleRepository role)
        {
            unit = _unit;
            UserRep = _UserRep;
            this.role = role;
        }

        [HttpGet]
        [Route("/Vendor/Edit")]
        public IActionResult edit()
        {
            var userinfo = UserRep.GetByID(User.FindFirstValue(ClaimTypes.NameIdentifier));
           var result= userinfo.ChangeUserToUserControllersViewModel();
        
            return View(result);
        }
        [HttpPost]
        [Route("/Vendor/Edit")]
        public async Task<IActionResult> edit(UserControllersViewModel obj)
        {
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            obj.ID = userid;
            string Uploade = "/Content/Uploads/UserImage/";

            IFormFile s = obj.uploadedimg;

            if (obj.uploadedimg != null)
            {
                string NewFileName = Guid.NewGuid().ToString() + s.FileName;
                obj.Img = Uploade + NewFileName;


                FileStream fs = new FileStream(Path.Combine(
                    Directory.GetCurrentDirectory(), "Content", "Uploads", "UserImage", NewFileName
                    ), FileMode.Create);

                s.CopyTo(fs);
                fs.Position = 0;
            }
            await UserRep.Update(obj);
            unit.Submit();
            return RedirectToAction("VendorGet","Product");
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            model.id = User.FindFirstValue(ClaimTypes.NameIdentifier);
           var res = await UserRep.ChangePassword(model);
            if (res.Succeeded)
                ModelState.Clear();
            
            return RedirectToAction("SignIn");
        }




    }



}
