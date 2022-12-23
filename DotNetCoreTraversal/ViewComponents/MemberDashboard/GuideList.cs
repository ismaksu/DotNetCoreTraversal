using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.ViewComponents.MemberDashboard
{
    public class GuideList:ViewComponent
    {
        GuideManager gm = new GuideManager(new EFGuideDAL());

        public IViewComponentResult Invoke()
        {
            var values = gm.ListEntities();
            return View(values);
        }
    }
}
