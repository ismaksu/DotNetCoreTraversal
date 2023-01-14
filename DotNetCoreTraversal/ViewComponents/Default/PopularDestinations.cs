using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.ViewComponents.Default
{
    public class PopularDestinations:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public PopularDestinations(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.ListDestination();
            return View(values);
        }
    }
}
