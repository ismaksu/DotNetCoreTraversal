using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.Areas.Member.Controllers
{
    [Area("Member")]
    public class DestinationController : Controller
    {
        DestinationManager dm = new DestinationManager(new EFDestinationDAL());

        public IActionResult Index()
        {
            var values = dm.ListEntities();
            return View(values);
        }
    }
}
