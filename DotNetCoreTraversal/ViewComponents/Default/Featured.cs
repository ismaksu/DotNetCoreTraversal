using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.ViewComponents.Default
{
    public class Featured:ViewComponent
    {
        FeaturedManager fm = new FeaturedManager(new EFFeaturedDAL());
        public IViewComponentResult Invoke()
        {
            var values = fm.ListEntities();
            return View(values);
        }
    }
}
