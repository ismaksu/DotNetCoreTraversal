using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.ViewComponents.Default
{
    public class PopularDestinations:ViewComponent
    {
        DestinationManager dm = new DestinationManager(new EFDestinationDAL());
        public IViewComponentResult Invoke()
        {
            var values = dm.ListEntities();
            return View(values);
        }
    }
}
