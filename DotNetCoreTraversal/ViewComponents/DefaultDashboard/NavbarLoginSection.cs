using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.ViewComponents.DefaultDashboard
{
    public class NavbarLoginSection : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public NavbarLoginSection(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.username = user.UserName;
                ViewBag.NameSurname = user.Name + " " + user.Surname;
                ViewBag.Url = "/userImages/" + user.ImageUrl;
            }
            return View();
        }
    }
}
