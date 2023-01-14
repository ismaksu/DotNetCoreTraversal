using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.ListDestination();
            return View(values);
        }

        public IActionResult DestinationDetails(int id = 1)
        {
            ViewBag.i = id;
            ViewBag.isAuthenticated = User.Identity.IsAuthenticated;
            var values = _destinationService.GetDestinationByID(id);
            return View(values);
        }
    }
}
