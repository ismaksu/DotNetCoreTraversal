using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.ViewComponents.MemberDashboard
{
    public class Last4Destinations:ViewComponent
    {
        private IDestinationService _destinationService;

        public Last4Destinations(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.GetLast4Destinations();
            return View(values);
        }
    }
}
