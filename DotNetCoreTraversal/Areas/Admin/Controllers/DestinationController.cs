using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _dsm;

        public DestinationController(IDestinationService dsm)
        {
            _dsm = dsm;
        }

        public IActionResult Index()
        {
            var values = _dsm.ListEntities();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination p)
        {
            p.Status = true;
            _dsm.AddEntity(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            var destination = _dsm.FindEntityByID(id);
            _dsm.DeleteEntity(destination);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var destination = _dsm.FindEntityByID(id);
            return View(destination);
        }

        [HttpPost]
        public IActionResult UpdateDestination(Destination p)
        {
            _dsm.UpdateEntity(p);
            return RedirectToAction("Index");
        }
    }
}
