using DotNetCoreTraversal.Areas.Member.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]/{id?}")]
    public class UserProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UserProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.Name = values.Name;
            userEditViewModel.Surname = values.Surname;
            userEditViewModel.Phone = values.PhoneNumber;
            userEditViewModel.Email = values.Email;

            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Image.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/userImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await p.Image.CopyToAsync(stream);
                user.ImageUrl = imageName;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PhoneNumber = p.Phone;
            user.Email = p.Email;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserPasswordEditViewModel p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (ModelState.IsValid)
            {
                bool passValidation = p.ConfirmPassword == p.NewPassword ? true : false;

                if (passValidation)
                {
                    var result = await _userManager.ChangePasswordAsync(user, p.CurrentPassword, p.NewPassword);
                    if (result.Succeeded)
                    {
                        return Json(new { redirectToUrl = Url.Action("Index", "Login") });
                    }
                    else
                    {
                        foreach (var errors in result.Errors)
                        {
                            ModelState.AddModelError(errors.Code, errors.Description);
                        }
                        return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors) });
                    }
                }
                else
                {
                    return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors) });
                }
            }
            else
            {
                return BadRequest(new { errors = ModelState.Values.SelectMany(v => v.Errors) });
            }
        }
    }
}
