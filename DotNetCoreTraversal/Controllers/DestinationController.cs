using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationManager dm = new DestinationManager(new EFDestinationDAL());
        public IActionResult Index()
        {
            var values = dm.ListEntities();
            return View(values);
        }

        public IActionResult DestinationDetails(int id = 1)
        {
            ViewBag.i = id;
            ViewBag.isAuthenticated = User.Identity.IsAuthenticated;
            var values = dm.FindEntityByID(id);
            return View(values);
        }
    }
}
