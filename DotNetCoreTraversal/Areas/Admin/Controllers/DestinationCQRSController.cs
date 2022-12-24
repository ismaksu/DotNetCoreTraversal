using DotNetCoreTraversal.CQRS.Handlers.DestinatonHandlers;
using DotNetCoreTraversal.CQRS.Queries.DestinationQueries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _destinationQueryHandler;
        private readonly GetDestinationByIDQueryHandler _destinationByIdQueryHandler;

        public DestinationCQRSController(GetAllDestinationQueryHandler destinationQueryHandler, GetDestinationByIDQueryHandler destinationByIdQueryHandler)
        {
            _destinationQueryHandler = destinationQueryHandler;
            _destinationByIdQueryHandler = destinationByIdQueryHandler;
        }

        public IActionResult Index()
        {
            var values = _destinationQueryHandler.Handle();
            return View(values);
        }

        public IActionResult GetDestination(int id)
        {
            var values = _destinationByIdQueryHandler.Handle(new GetDestinationByIDQuery(id));
            return View(values);
        }
    }
}
