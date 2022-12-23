using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.ViewComponents.AdminDashboard
{
    public class DashboardMiniCards:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
