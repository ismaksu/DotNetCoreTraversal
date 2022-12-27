using DotNetCoreTraversal.CQRS.Commands.DestinationCommands;
using DotNetCoreTraversal.CQRS.Handlers.DestinatonHandlers;
using DotNetCoreTraversal.CQRS.Queries.DestinationQueries;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreTraversal.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _destinationQueryHandler;
        private readonly GetDestinationByIDQueryHandler _destinationByIdQueryHandler;
        private readonly CreateDestinationCommandHandler _createDestinationHandler;
        private readonly RemoveDestinationCommandHandler _removeDestinationHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationHandler;

        public DestinationCQRSController(GetAllDestinationQueryHandler destinationQueryHandler,
                                         GetDestinationByIDQueryHandler destinationByIDQueryHandler,
                                         CreateDestinationCommandHandler createDestinationHandler,
                                         RemoveDestinationCommandHandler removeDestinationHandler,
                                         UpdateDestinationCommandHandler updateDestinationHandler)
        {
            _destinationQueryHandler = destinationQueryHandler;
            _destinationByIdQueryHandler = destinationByIDQueryHandler;
            _createDestinationHandler = createDestinationHandler;
            _removeDestinationHandler = removeDestinationHandler;
            _updateDestinationHandler = updateDestinationHandler;
        }

        public IActionResult Index()
        {
            var values = _destinationQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult GetDestination(int id)
        {
            var values = _destinationByIdQueryHandler.Handle(new GetDestinationByIDQuery(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult GetDestination(UpdateDestinationCommand command)
        {
            _updateDestinationHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(CreateDestinationCommand destination)
        {
            _createDestinationHandler.Handle(destination);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteDestination(int id)
        {
            _removeDestinationHandler.Handle(new RemoveDestinationCommand(id));
            return RedirectToAction("Index");
        }
    }
}
