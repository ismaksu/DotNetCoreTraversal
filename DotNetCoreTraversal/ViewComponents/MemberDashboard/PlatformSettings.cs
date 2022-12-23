using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.ViewComponents.MemberDashboard
{
    public class PlatformSettings:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
