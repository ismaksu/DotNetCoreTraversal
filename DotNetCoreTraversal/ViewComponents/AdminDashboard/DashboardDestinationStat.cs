using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.ViewComponents.AdminDashboard
{
    public class DashboardDestinationStat:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
