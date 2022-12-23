using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.ViewComponents.AdminDashboard
{
    public class DashboardGraph1:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
