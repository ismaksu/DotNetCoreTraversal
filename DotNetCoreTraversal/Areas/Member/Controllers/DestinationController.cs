using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DotNetCoreTraversal.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
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

        public IActionResult Search(string searchString)
        {
            ViewData["CurrentFilter"] = searchString;
            var values = from x in _destinationService.ListDestination() select x;
            if (!string.IsNullOrEmpty(searchString))
            {
                values = values.Where(y => y.City.CityName.ToLower().Contains(searchString.ToLower()));
            }
            return View(values.ToList());
        }
    }
}
