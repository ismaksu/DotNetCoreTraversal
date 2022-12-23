using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.ViewComponents.MemberDashboard
{
    public class ProfileInformation:ViewComponent
    {
        UserManager<AppUser> _userManager;

        public ProfileInformation(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.nameSurname = user.Name + " " + user.Surname;
            ViewBag.phone = user.PhoneNumber;
            ViewBag.mail = user.Email;
            return View();
        }
    }
}
