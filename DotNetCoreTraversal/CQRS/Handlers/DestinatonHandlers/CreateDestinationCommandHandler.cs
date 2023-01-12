using DataAccessLayer.Concrete;
using DotNetCoreTraversal.CQRS.Commands.DestinationCommands;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.CQRS.Handlers.DestinatonHandlers
{
    public class CreateDestinationCommandHandler
    {
        private readonly Context _context;

        public CreateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateDestinationCommand command)
        {
            _context.Destinations.Add(new Destination
            {
                CityName = command.City,
                DayNight = command.DayNight,
                Price = command.Price,
                Capacity = command.Capacity,
                Status = command.Status
            });
            _context.SaveChanges();
        }
    }
}
