using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.ViewComponents.Default
{
    public class Testimonials:ViewComponent
    {
        TestimonialManager tm = new TestimonialManager(new EFTestimonialDAL());
        public IViewComponentResult Invoke()
        {
            var values = tm.ListEntities();
            return View(values);
        }
    }
}
