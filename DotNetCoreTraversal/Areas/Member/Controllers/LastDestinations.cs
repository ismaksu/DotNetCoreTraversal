using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.Areas.Member.Controllers
{
    [Area("Member")]
    public class LastDestinations : Controller
    {
        private IDestinationService _destinationService;

        public LastDestinations(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.GetLast4Destinations();
            return View(values);
        }
    }
}
