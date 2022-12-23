using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.ViewComponents.AdminDashboard
{
    public class DashboardCard:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
