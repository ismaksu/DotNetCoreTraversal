using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.ViewComponents.AdminDashboard
{
    public class DashboardBanner:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
