using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.Controllers
{
    public class ReportsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
