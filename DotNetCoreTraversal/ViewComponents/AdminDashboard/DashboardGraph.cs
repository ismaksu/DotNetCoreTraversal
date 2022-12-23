using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.ViewComponents.AdminDashboard
{
    public class DashboardGraph:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
