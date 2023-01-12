using DataAccessLayer.Concrete;
using DotNetCoreTraversal.CQRS.Queries.DestinationQueries;
using DotNetCoreTraversal.CQRS.Results.DestinationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreTraversal.CQRS.Handlers.DestinatonHandlers
{
    public class GetDestinationByIDQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIDQueryResult Handle(GetDestinationByIDQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationByIDQueryResult
            {
                DestinationID = values.DestinationID,
                City = values.CityName,
                DayNight = values.DayNight,
                Price = values.Price
            };
        }
    }
}
