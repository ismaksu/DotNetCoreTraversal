using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.ViewComponents.Default
{
    public class Subabout:ViewComponent
    {
        AboutManager abm = new AboutManager(new EFAboutDAL());
        public IViewComponentResult Invoke()
        {
            var values = abm.ListEntities();
            return View(values);
        }
    }
}
